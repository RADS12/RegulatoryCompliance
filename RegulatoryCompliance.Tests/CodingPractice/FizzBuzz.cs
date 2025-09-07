using System;

namespace CodingPractice
{
    public class FizzBuzz
    {
        public static string IsFizzBuzz(int number)
        {
            if (number % 5 == 0)
                return "FizzBuzz";
            else if (number % 3 == 0)
                return "Buzz";

            return "Not FizzBuz";
        }

        public static bool IsPalindrome(string str)
        {
            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (str[left] != str[right])
                    return false;

                left++;
                right--;
            }
            return true;
        }

        public static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        public static string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static int IsPair(int[] num)
        {
            var unmatched = new Hashset<int>();
            var pair = 0;

            foreach (var num in num)
            {
                if (unmatched.contains(num))
                {
                    pair++;
                    unmatched.remove(num);
                }
                else
                {
                    unmatched.Add(num);
                }
            }

            return pairs;
        }



    }
}
