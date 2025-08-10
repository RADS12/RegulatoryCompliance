namespace RegulatoryCompliance.Infrastructure.RegulatoryComplianceSql
{
    public class Test
    {
        public bool IsPrimeNumber(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return false;

            for (int i = 3; i < Math.Sqrt(num); i++)
            {
                if (num % 2 == 0)
                    return false;
            }

            return true;
        }

        public bool IsPalindrome(string str)
        {
            var left = 0;
            var right = str.Length - 1;

            while (left < right)
            {
                if (str[left] != str[right])
                    return false;

                left++;
                right--;
            };

            return true;
        }

        public string ReverseSentence(string str)
        {
            var reversedStr = str.ToCharArray();
            Array.Reverse(reversedStr);

            return new string(reversedStr);
        }

        public string ReverseWord(string str)
        {
            var arr = str.Split(' ');
            Array.Reverse(arr);

            return string.Join(" ", arr);
        }

        public void FizZBuzz(int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (n % 3 == 0 && n % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (n % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (n % 3 == 0 && n % 5 == 0)
                    Console.WriteLine("uzz");
                else
                    Console.WriteLine("Not Fizz or Buzz");
            }
        }

        public int SockPairs(int[] arr)
        {
            var unmatched = new HashSet<int>();
            int pairs = 0;

            foreach (int n in arr)
            {
                if (!unmatched.Add(n))
                {
                    unmatched.Remove(n);
                    pairs++;
                }
            }

            return pairs;
        }

        static List<int> FindSumEqualToTarget(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (i < target)
                {
                    for (int j = 1; j < arr.Length; j++)
                    {
                        if (arr[i] + arr[j] == target)
                        {
                            var result = new List<int> { arr[i], arr[j] };
                            return result;
                        }
                    }
                }

            return new List<int>();
        }
    }
}
