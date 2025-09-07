using System;

class Program
{
    static void Main()
    {
        Func<int> counter = Counter();

        Console.WriteLine(counter()); // 1
        Console.WriteLine(counter()); // 2
        Console.WriteLine(counter()); // 3
    }

    static Func<int> Counter()
    {
        int count = 0;

        // lambda closes over "count"
        return () =>
        {
            count++;
            return count;
        };
    }
}
