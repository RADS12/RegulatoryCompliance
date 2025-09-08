public class LinqTests()
{
    public Dictionary<int, decimal> GetGroupByDept(List<Employee> emp)
    {
        //public Dictionary<int, decimal> dic = new Dictionary<int, decimal>();

        return emp.GroupBy(g => g.DepartmentId)
            .Select(g = new
            {
                g.DepartmentId,
                g.Average(g => g.salary)
            });
    }

    public List<int> GetTopThree(List<int> lst)
    {
        lst.Sort();

        return lst.Skip(lst.Count - 3).ToList();
    }

    /*
    var words = new List<string>
    {
        "eat", "tea", "tan", "ate", "nat", "bat"
    };
    Result:
    [
        ["eat", "tea", "ate"],
        ["tan", "nat"],
        ["bat"]
    ]
    */
    public static List<List<string>> GroupAnagrams(List<string> words)
    {
        if (words == null) return new List<List<string>>();

        return words
            .GroupBy(w => new string(w.ToLowerInvariant().OrderBy(c => c).ToArray()))
            .Select(g => g.ToList())
            .ToList();
    }

    //Parallel Sum: Split a large array and compute its sum in parallel using Task or Parallel.For
    public static long ParallelSum(int[] data)
    {
        long total = myArray.AsParallel().Sum(x => (long)x);
        return total;
    }
    
}

public class Employee
{
    public EmpId EmpId { get; set; }
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
}