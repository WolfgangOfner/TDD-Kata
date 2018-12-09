using System.Collections.Generic;

namespace Tree
{
    public class MyTree
    {
        public MyTree(int value)
        {
            Root = new TreeNode(value);
        }

        public TreeNode Root { get; private set; }

        public void Insert(int value)
        {
            var newNode = new TreeNode(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;

                while (true)
                {
                    var parent = current;

                    if (value < current.Value)
                    {
                        current = current.LeftChild;

                        if (current == null)
                        {
                            parent.LeftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.RightChild;

                        if (current == null)
                        {
                            parent.RightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public static void Sort(TreeNode root, List<int> output)
        {
            if (root != null)
            {
                Sort(root.LeftChild, output);
                output.Add(root.Value);
                Sort(root.RightChild, output);
            }
        }
    }
}