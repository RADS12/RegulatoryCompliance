using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {
        public NotesStore() {}
        private Dictionary<string, string> dic = new Dictionary<string, string>();

        public void AddNote(string state, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(state))
                throw new Exception("State cannot be empty");

            if (state != "completed" && state != "active" && state != "others")
                throw new Exception("Invalid state " + state);

            dic[name] = state; // insert/update
        }
        
        public List<string> GetNotes(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
                throw new Exception("State cannot be empty");

            if (state != "completed" && state != "active" && state != "others")
                throw new Exception("Invalid state " + state);

            List<string> result = new List<string>();

            foreach (var kv in dic)
            {
                if (kv.Value == state)
                    result.Add(kv.Key);
            }

            return result;
        }
        
        
    } 

    public class Solution
    {
        public static void Main() 
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    } else {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}