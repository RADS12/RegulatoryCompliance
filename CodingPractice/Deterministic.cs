using System;
using System.Text;

public class StringKeyGenerator
{
    public static string GenerateKey(string input)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in input)
        {
            // Example custom logic: take ASCII value, mod 10
            int value = (int)c % 10; 
            sb.Append(value);
        }

        return sb.ToString();
    }

    public static void Main()
    {
        Console.WriteLine(GenerateKey("Python"));  // e.g. "218596"
        Console.WriteLine(GenerateKey("Java"));    // e.g. "0747"
    }
}
