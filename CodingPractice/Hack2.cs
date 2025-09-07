using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
        //    return employees
        //            .GroupBy(e => e.Company)
        //            .ToDictionary(
        //                g => g.Key,
        //                g => (int)g.Average(e => e.Age)
        //            );
        
            var result = employees
                .GroupBy(e => e.Company)
                .Select(g => new
                {
                    Company = g.Key,
                    AvgAge = (int)Math.Round(g.Average(e => e.Age), MidpointRounding.AwayFromZero)
                })
                .OrderBy(x => x.Company);

            var dict = new Dictionary<string, int>();
            foreach (var x in result) dict[x.Company] = x.AvgAge;
            return dict;
            
        }
        
        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            // return employees
            //        .GroupBy(e => e.Company)
            //        .ToDictionary(
            //            g => g.Key,
            //            g => g.Count()
            //        );
            
            var result = employees
                .GroupBy(e => e.Company)
                .Select(g => new { Company = g.Key, Count = g.Count() })
                .OrderBy(x => x.Company);

            var dict = new Dictionary<string, int>();
            foreach (var x in result) dict[x.Company] = x.Count;
            return dict;
            
        }
        
        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            // return employees
            //        .GroupBy(e => e.Company)
            //        .ToDictionary(
            //            g => g.Key,
            //            g => g.OrderByDescending(e => e.Age).First()
            //        );
            
            var result = employees
                .GroupBy(e => e.Company)
                .Select(g => new
                {
                    Company = g.Key,
                    Oldest = g
                        .OrderByDescending(e => e.Age) // if tie, first in input kept
                        .First()
                })
                .OrderBy(x => x.Company);

            var dict = new Dictionary<string, Employee>();
            foreach (var x in result) dict[x.Company] = x.Oldest;
            return dict;
            
        }

        public static void Main()
        {   
            int countOfEmployees = int.Parse(Console.ReadLine());
            
            var employees = new List<Employee>();
            
            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee { 
                    FirstName = strArr[0], 
                    LastName = strArr[1], 
                    Company = strArr[2], 
                    Age = int.Parse(strArr[3]) 
                    });
            }
            
            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }
            
            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }
            
            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}   