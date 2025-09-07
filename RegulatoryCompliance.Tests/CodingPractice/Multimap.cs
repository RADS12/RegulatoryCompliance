using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetUsers2
{
    public class TagAggregator_Multimap
    {
        private readonly Dictionary<string, HashSet<int>> _tagsMap = new();

        public void AddTag(int customerId, string tag)
        {
            if (!_tagsMap.ContainsKey(tag))
                _tagsMap[tag] = new HashSet<int>();

            _tagsMap[tag].Add(customerId);
        }


    }

    //Summary
    //Feature               MultiMap<TKey, TValue>     MultiMap
    //Type-safe                     ✅                       ❌
    //Compile-time checking       ✅                   ❌
    //Easy to use               ✅                     ❌
    //Generic                       ✅                       ❌
    public class TagAggregator_IEnumerable<TKey, TValues> : IEnumerable<KeyValuePair<TKey, TValues>>
    {
        private readonly Dictionary<TKey, HashSet<TValues>> _tagsMap = new();

        public void Addtag(TKey key, TValues value)
        {
            if (!_tagsMap.ContainsKey(key))
                _tagsMap[key] = new HashSet<TValues>();  //If the key with value is present then make this as HashSet to hold more values

            _tagsMap[key].Add(value);
        }

        public bool RemoveTag(TKey key, TValues value)
        {
            if (_tagsMap.TryGetValue(key, out var values))      //Get values for the key
            {
                bool removed = values.Remove(value);            // Removed the value
                if (values.Count == 0) _tagsMap.Remove(key);    //If key has no values then remove the key
                return removed;
            }

            return false;
        }

        public bool Contains(TKey key, TValues value)
        {
            var result = _tagsMap.ContainsKey(key) && _tagsMap[key].Contains(value);

            return result;

        }

        public IEnumerable<TValues> GetValues(TKey key)
        {
            var result = _tagsMap.ContainsKey(key) ? _tagsMap[key] : new HashSet<TValues>();

            return result;
        }




        IEnumerator<KeyValuePair<TKey, TValues>> IEnumerable<KeyValuePair<TKey, TValues>>.GetEnumerator()
        {

            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }



}