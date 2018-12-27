using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree : IEnumerable
    {
        private Node _root;

        public int Count { get; private set; }

        public BinarySearchTree()
        {
            _root = null;
        }

        public BinarySearchTree(IEnumerable<int> items) : this()
        {
            if (items == null)
            {
                throw new ArgumentNullException($"{nameof(items)} ca not be null");
            }

            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(int item)
        {
            _root = Add(_root, item);
            Count++;
        }

        public void Delete(int item)
        {
            _root = Delete(_root, item);
            Count--;
        }

        public bool Contains(int item) => Contains(_root, item);

        public IEnumerator GetEnumerator()
        {
            if (_root == null)
            {
                yield break;
            }

            foreach (var item in InOrder(_root))
            {
                yield return item;
            }
        }

        private Node Add(Node root, int item)
        {
            if (ReferenceEquals(root, null))
            {
                return new Node(item);
            }

            if (root.Value > item)
            {
                root.Left = Add(root.Left, item);
            }
            else
            {
                root.Right = Add(root.Right, item);
            }

            return root;
        }

        private Node Delete(Node root, int item)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                if (item < root.Value)
                {
                    root.Left = Delete(root.Left, item);

                    if (BalanceFactor(root) == -2)
                    {
                        root = BalanceFactor(root.Right) <= 0 ? RotateLL(root) : RotateRL(root);
                    }
                }
                else if (item > root.Value)
                {
                    root.Right = Delete(root.Right, item);

                    if (BalanceFactor(root) == 2)
                    {
                        root = BalanceFactor(root.Left) >= 0 ? RotateLL(root) : RotateLR(root);
                    }
                }
                else
                {
                    if (root.Right != null)
                    {
                        var parent = root.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }

                        root.Value = parent.Value;
                        root.Right = Delete(root.Right, parent.Value);

                        if (BalanceFactor(root) == 2)
                        {
                            root = BalanceFactor(root.Left) >= 0 ? RotateLL(root) : RotateLR(root);
                        }
                    }
                    else
                    {
                        return root.Left;
                    }
                }
            }

            return root;
        }

        private int GetHeight(Node root)
        {
            var height = 0;

            if (root != null)
            {
                var l = GetHeight(root.Left);
                var r = GetHeight(root.Right);
                var m = Max(l, r);
                height = m + 1;
            }

            return height;
        }

        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int BalanceFactor(Node root)
        {
            var l = GetHeight(root.Left);
            var r = GetHeight(root.Right);
            var factor = l - r;

            return factor;
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        private bool Contains(Node root, int item)
        {
            while (true)
            {
                if (root == null)
                {
                    return false;
                }

                if (root.Value == item)
                {
                    return true;
                }

                root = root.Value > item ? root.Left : root.Right;
            }
        }

        private static IEnumerable InOrder(Node root)
        {
            while (true)
            {
                if (root.Left != null)
                {
                    foreach (var item in InOrder(root.Left))
                    {
                        yield return item;
                    }
                }

                yield return root.Value;

                if (root.Right != null)
                {
                    root = root.Right;
                    continue;
                }

                break;
            }
        }

    }
}
