public class MultiThreading()
{
    static Queue<int> que = new Queue<int>();
    static SemaphoreSlim items = new SemaphoreSlim(0);
    static SemaphoreSlim slots = new SemaphoreSlim(5);
    object locker = new object();

    public async Task Producer(int id)
    {
        for (var i = 1; i <= 10; i++)
        {
            await ss.WaitAsync();
            lock (locker)
            {
                que.Enqueue(i);
            }

            items.Release;
            await Task.Delay(50);
        }
    }

    public async Task Consumer(int id)
    {
        while (true)
        {
            await items.WaitAsync();
            int value = 0;
            lock (locker)
            {
                if (que.Count == 0)
                    continue;

                value = que.Dequeue();
            }

            ss.Release;
            await Task.Delay(50);
        }
    }

    static async Task Main()
    {
        var producers = new[] { Producer(1), Producer(2) };
        var consumers = new[] { Consumer(1), Consumer(2) };

        await Task.WhenAll(producers); // wait for all producers
        Console.WriteLine("Producers finished.");
    }
}
