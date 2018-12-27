namespace BinarySearchTree
{
    internal class Node
    {
        internal Node Left;
        internal Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public int Value { get; set; }
    }
}