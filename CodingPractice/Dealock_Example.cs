using System;
using System.Threading;

class DeadLock
{
    static readonly object LockA = new object();
    static readonly object LockB = new object();

    static void Main()
    {
        var t1 = new Thread(Thread1Work);
        var t2 = new Thread(Thread2Work);

        Console.WriteLine("Starting DEADLOCK demo...");
        t1.Start();
        t2.Start();

        // This join will hang because of the deadlock
        t1.Join();
        t2.Join();
    }

    static void Thread1Work()
    {
        lock (LockA)
        {
            Console.WriteLine("T1: locked A");
            Thread.Sleep(200); // simulate work
            lock (LockB)
            {
                Console.WriteLine("T1: locked B");
            }
        }
    }

    static void Thread2Work()
    {
        lock (LockB)
        {
            Console.WriteLine("T2: locked B");
            Thread.Sleep(200); // simulate work
            lock (LockA)
            {
                Console.WriteLine("T2: locked A");
            }
        }
    }
}

//Fix
class ProgramDeadlockFix
{
    static readonly object LockA = new object();
    static readonly object LockB = new object();

    static void Main()
    {
        var t1 = new Thread(() => Work(LockA, LockB, "T1"));
        var t2 = new Thread(() => Work(LockB, LockA, "T2"));

        Console.WriteLine("Starting RESOLVED demo...");
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
        Console.WriteLine("Done without deadlock.");
    }

    static void Work(object first, object second, string name)
    {
        // Order the locks by a stable key (object identity hash here).
        // Any consistent global ordering rule works.
        OrderAndLock(first, second,
        () =>
        {
            Console.WriteLine($"{name}: in critical section using both resources");
            Thread.Sleep(100);
        });
    }

    static void OrderAndLock(object a, object b, Action body)
    {
        // Use RuntimeHelpers.GetHashCode to get identity-based hash (doesn't call overridden GetHashCode)
        int ha = RuntimeHelpers.GetHashCode(a);
        int hb = RuntimeHelpers.GetHashCode(b);

        object first = ha <= hb ? a : b;
        object second = ha <= hb ? b : a;

        lock (first)
        {
            // Optional small delay to make interleavings more likely when testing
            Thread.Sleep(50);
            lock (second)
            {
                body();
            }
        }
    }
}


class DeadLockFix2
{
    static readonly SemaphoreSlim ResA = new SemaphoreSlim(1, 1);
    static readonly SemaphoreSlim ResB = new SemaphoreSlim(1, 1);
    static readonly Random Rng = new Random();

    static async Task Main()
    {
        Console.WriteLine("Starting SemaphoreSlim deadlock-avoidance demo...");

        // Two tasks attempt to use A and B in opposite order
        var t1 = Task.Run(() => UseBothAsync(ResA, ResB, "T1"));
        var t2 = Task.Run(() => UseBothAsync(ResB, ResA, "T2"));

        await Task.WhenAll(t1, t2);
        Console.WriteLine("Done without deadlock.");
    }

    // Try to acquire both semaphores. If second one times out, release first and retry.
    static async Task UseBothAsync(SemaphoreSlim first, SemaphoreSlim second, string name, CancellationToken ct = default)
    {
        var backoffMs = 50;

        while (true)
        {
            ct.ThrowIfCancellationRequested();

            // Acquire the first resource (wait indefinitely or choose a timeout if you prefer)
            await first.WaitAsync(ct);
            Console.WriteLine($"{name}: acquired first");

            try
            {
                // Try to acquire the second with a timeout to avoid deadlock
                if (await second.WaitAsync(TimeSpan.FromMilliseconds(200), ct))
                {
                    Console.WriteLine($"{name}: acquired second");
                    try
                    {
                        // Critical section: safely holds both
                        await Task.Delay(100, ct); // simulate work
                        Console.WriteLine($"{name}: completed work");
                        return; // success, exit loop
                    }
                    finally
                    {
                        second.Release();
                        Console.WriteLine($"{name}: released second");
                    }
                }
                else
                {
                    // Couldn’t get the second; back off, release first, and retry
                    Console.WriteLine($"{name}: timeout on second -> backing off");
                }
            }
            finally
            {
                first.Release();
                Console.WriteLine($"{name}: released first");
            }

            // Jittered backoff to reduce contention
            await Task.Delay(backoffMs + Rng.Next(0, 50), ct);
            // Optional: exponential backoff cap
            if (backoffMs < 400) backoffMs *= 2;
        }
    }
}

