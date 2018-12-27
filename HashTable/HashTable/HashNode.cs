namespace HashTable
{
    public class HashNode
    {
        internal HashNode Next;
        public int Key { get; }
        public int Value { get; }

        public HashNode(int key, int value)
        {
            Key = key;
            Next = null;
            Value = value;
        }

        public void SetNextNode(HashNode item)
        {
            Next = item;
        }
    }
}