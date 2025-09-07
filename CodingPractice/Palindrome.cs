public class codingPractice {

    public bool IsPalindrome(string str) {

        if (string.IsNullOrEmpty(str))
            return false;

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

    public bool IsPrimeNumber(int num)
    {
        if (num == 1) return false;
        if (num == 2 ) return true;

        for (i = 3; i < (int)Math.Sqrt(num); i++)
        {
            if (num % i == 0) return false;
        }

        return true;
    }

     static string ReverseString(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    
    //n square issue
    public string GetFirstNonRepeatingChar(string str)
	{
		if (string.IsNullOrEmpty(str)) return null;
		
		for (var i = 0; i < str.Length; i++)
		{
            var newString = str.Substring(i + 1);

			if (!newString.Contains(str[i]) && str.IndexOf(str[i]) == i)
				return str[i].ToString();
				
		}
		
		return null;
	}
    // Just n time
    public static string GetFirstNonRepeatingCharUnicode(string str)
    {
        if (string.IsNullOrEmpty(str)) return null;

        var freq = new Dictionary<char, int>();

        // Count frequencies
        foreach (char c in str)
        {
            if (freq.ContainsKey(c))
                freq[c]++;              // update existing key
            else
                freq[c] = 1;            // insert new key
        }

        // Find first with count == 1
        for (int i = 0; i < str.Length; i++)
            if (freq[str[i]] == 1)
                return str[i].ToString();

        return null;
    }

    // Example Inputs and Outputs:
    // Input: [3, 4, -1, 1] → Output: 2
    // Input: [1, 2, 0] → Output: 3
    // Input: [7, 8, 9, 11, 12] → Output: 1
    public int GetFirstMissingPositiveNumber(int[] ints)
    {
        if (ints == null || ints.Length == 0)
            return 1;

        var set = new HashSet<int>(ints);
        int i = 1;

        while (set.Contains(i))
            i++;

        return i;   
    }

    // Input: "abcabcbb" → Output: 3 (substring "abc")
    // Input: "bbbbb" → Output: 1 (substring "b")
    // Input: "pwwkew" → Output: 3 (substring "wke")
    // Input: "" → Output: 0
    public static int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        var window = new HashSet<char>();
        int left = 0, maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // If duplicate, shrink from the left until it's gone
            while (window.Contains(s[right]))
            {
                window.Remove(s[left]);
                left++;
            }

            // Add current char and update max length
            window.Add(s[right]);
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }

    // Input: nums = [2,7,11,15], target = 9
    // Output: [0,1] (because nums[0] + nums[1] = 2 + 7 = 9)
    // Input: nums = [3,2,4], target = 6
    // Output: [1,2]
    // Input: nums = [3,3], target = 6
    // Output: [0,1]
    public static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>(); // number → index

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
                return new int[] { map[complement], i };

            if (!map.ContainsKey(nums[i])) // avoid duplicates
                map[nums[i]] = i;
        }

        return Array.Empty<int>(); // no solution found
    }

    Input: "()" → Output: true

    // Input: "()[]{}" → Output: true
    // Input: "(]" → Output: false
    // Input: "([)]" → Output: false
    // Input: "{[]}" → Output: true
    public static bool IsValid(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;

        var stack = new Stack<char>();

        foreach (char c in s)
        {
            // Push opening brackets
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0) return false;

                char top = stack.Pop();

                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0; // must be empty if valid
    }

    
    //Given an array of integers, calculate the ratios of its elements that are , , and . 
    // Print the decimal value of each fraction on a new line with 6 places after the decimal.
    //-4 3 -9 0 4 1
    public static void plusMinus(List<int> arr)
    {
        var count = arr.Count;
        
        int pos = 0;
        int zero = 0;
        int neg = 0; 
        
        for(var i = 0; i < count; i++)
        {
            if (arr[i] > 0)
                pos++;
            else if (arr[i] == 0) 
                zero++;
            else
                neg++;
        }
        
        decimal posRatio = (decimal)pos / count;
        decimal zeroRatio = (decimal)neg / count;
        decimal negRatio = (decimal)zero / count;
                
        Console.WriteLine(posRatio.ToString("F6"));
        Console.WriteLine(zeroRatio.ToString("F6"));
        Console.WriteLine(negRatio.ToString("F6"));
    }

    /*
     * Complete the 'staircase' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void staircase(int n)
    {
        string sym = "";
        for(var i = n; i >= 1; i--)
        {
            sym += "#";
            Console.WriteLine(sym.PadLeft(n));
        }

    }

    /*
     * Complete the 'miniMaxSum' function below.
     * 
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        arr.Sort();
        
        long sum = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            sum += arr[i];
        }
        
        
        Console.WriteLine($"{sum - arr[arr.Count-1]} {sum - arr[0]}");
    }

    /*
     * Complete the 'birthdayCakeCandles' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY candles as parameter.
     * [3 2 1 3]
     */
    public static int birthdayCakeCandles(List<int> candles)
    {
        //candles.Reverse();
        var cnt = 0;
        var highest = candles.Max();
        
        for(var i = 0; i < candles.Count; i++)
        {
            if (candles[i] == highest)
                cnt++;
        }
        
        return cnt;
    }

    public static string timeConversion(string s)
    {
        var lastTwo = s.Substring(s.Length - 2);
        int num = 0;
        
        s = s.Substring(0, s.Length - 2);
        
        if (lastTwo == "AM" && s.Substring(0, 2) == "12")
            s = "00" + s.Substring(2);

        if (lastTwo == "PM" && s.Substring(0, 2) != "12")
        {
            num = int.Parse(s.Substring(0, 2)) + 12;
            s = num.ToString() + s.Substring(2);
        }
        
        return s;
    }

    public static string TimeConversion(string s)
    {
        // Parse input time (handles AM/PM)
        DateTime time = DateTime.ParseExact(s, "hh:mm:sstt", null);

        // Format as 24-hour military time
        return time.ToString("HH:mm:ss");
    }

    public static void Main(string[] args)
    {
        string s = Console.ReadLine();   // e.g. "07:05:45PM"
        string result = TimeConversion(s);
        Console.WriteLine(result);
    }

    public static string TimeConversion(string s)
    {
        string period = s.Substring(s.Length - 2);  // AM or PM
        string[] parts = s.Substring(0, s.Length - 2).Split(':');

        int hour = int.Parse(parts[0]);
        int minute = int.Parse(parts[1]);
        int second = int.Parse(parts[2]);

        if (period == "AM")
        {
            if (hour == 12) hour = 0;  // midnight case
        }
        else // PM
        {
            if (hour != 12) hour += 12; // afternoon/evening case
        }

        // Format into military time with leading zeros
        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }

    /*
    🔹 Numeric Format Specifiers (for int, double, decimal)
    Format	Example (1234.5678m)	            Meaning
    F2	    1234.57	Fixed-point,            2 decimals
    F6	    1234.567800	Fixed-point,        6 decimals
    N2	    1,234.57	                    Number with thousands separator
    C2	    $1,234.57 (depends on culture)	Currency, 2 decimals
    P2	    123,456.78 %	                Percentage
    E2	    1.23E+003	                    Scientific notation
    G	    1234.5678	                    General (shortest possible)

    Format	        Example (2025-09-06 19:05:45)	                Meaning
    HH:mm:ss	        19:05:45	                            24-hour clock
    hh:mm:ss tt	        07:05:45 PM	                            12-hour clock with AM/PM
    yyyy-MM-dd	        2025-09-06	                            Year-Month-Day
    dd/MM/yyyy	        06/09/2025	                            Day/Month/Year
    MMMM dd, yyyy	    September 06, 2025	                    Full month name
    ddd, dd MMM yyyy	Sat, 06 Sep 2025	                    Short day + short month
    dddd	Saturday	Full day name
    f	                Saturday, September 6, 2025 7:05 PM	    Full date & short time
    F	                Saturday, September 6, 2025 7:05:45     PM	Full date & long time

    */





    public void AddNote(String state, String name) {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception ("Name cannot be empty");
                
            if (string.IsNullOrWhiteSpace(state))
                throw new Exception ("State cannot be empty");
            else if (state != "completed" || state != "active" || state != "others")
                throw new Exception ("Invalid state {state}");
            
            var dic = new Dictionary<string, string>();
            
            dic.Add(name, state);
            
            
        }
        
    
        public List<String> GetNotes(String state) {
            
            List<String> lst = new List<string>();
            
            if (string.IsNullOrWhiteSpace(state))
                throw new Exception ("state cannot be empty");
            else if (state != "completed" || state != "active" || state != "others")
                throw new Exception ("Invalid state {state}");
            
            foreach (var d in dic)
            {
                if (d.Value == "completed")
                    lst.Add(d.Key);
                else if (d.Value == "active")
                    lst.Add(d.Key);  
                else if (d.Value == "others")
                    lst.Add(d.Key);  
            }
            
            return lst;
        }
    } 

    public static int sansaXor(List<int> arr)
    {
        int n = arr.Count;
        if ((n & 1) == 0) return 0; 
        int x = 0;
        for (int i = 0; i < n; i += 2)
            x ^= arr[i];
        return x;
    }

}