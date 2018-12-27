using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable
    {
        private readonly Dictionary<int, List<HashNode>> _table;
        private const int Size = 2;

        public Dictionary<int, List<HashNode>> Table => _table;

        public HashTable()
        {
            _table = new Dictionary<int, List<HashNode>>(Size);
        }

        public void Insert(int key, int value)
        {
            var item = new HashNode(key, value);
            var hash = CreateHash(key);

            if (_table.ContainsKey(hash))
            {
                var items = _table[hash];
                try
                {
                    var element = items.Single(i => i.Key == item.Key);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(nameof(key));
                }

                _table[hash].Add(item);
            }
            else
            {
                _table.Add(hash, new List<HashNode>{item});
            }
        }

        public void Delete(int key)
        {
            var hash = CreateHash(key);

            if (!_table.ContainsKey(hash))
            {
                return;
            }

            var items = _table[hash];
            try
            {
                var element = items.Single(i => i.Key == key);
                items.Remove(element);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public int Search(int key)
        {
            var hash = CreateHash(key);

            if (!_table.ContainsKey(hash))
            {
                return -1;
            }

            var items = _table[hash];
            try
            {
                var element = items.Single(i => i.Key == key);
                return element.Value;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private static int CreateHash(int key) => key / Size;
    }
}
