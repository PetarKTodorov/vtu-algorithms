namespace P16.Exam
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Tree tree = new Tree();
        private static Node node1 = new Node();
        private static LinkedList<int> linkedList = new LinkedList<int>();

        public static void Main()
        {
            var tree = new Tree();

            FillTree();

            Console.Write("Left Root Right Tree: ");
            tree.Traverse(node1);
            Console.WriteLine();

            int maxValue = tree.FindMaxElement(node1).value;
            int minValue = tree.FindMinElement(node1).value;
            double averageValue = (maxValue + minValue) / 2.0;

            Console.WriteLine($"Max Value: {maxValue}");
            Console.WriteLine($"Min Value: {minValue}");
            Console.WriteLine($"Average Value: {averageValue}");

            tree.GetAllNumbersGreatherThen(node1, averageValue);

            Console.WriteLine("Link List: " + String.Join(", ", linkedList));
        }

        private static void FillTree()
        {
            var random = new Random();
            int number = random.Next(0, 100);

            node1.value = number;

            for (int index = 1; index <= 29; index++)
            {
                try
                {
                    number = random.Next(0, 100);

                    tree.Add(ref node1, number);
                }
                catch (InvalidOperationException e)
                {
                    index--;
                }
            }
        }

        public class Node
        {
            public int value;
            public Node left;
            public Node right;
        }

        public class Tree
        {
            private const string ADD_NODE_ERROR_MESSAGE = "The value {0} already exists in tree.";
       
            public void Add(ref Node root, int v)
            {
                if (root == null)
                {
                    root = new Node();
                    root.value = v;

                    return;
                }

                bool isAlreadyExist = Search(root, v);

                if (isAlreadyExist)
                {
                    string message = String.Format(ADD_NODE_ERROR_MESSAGE, v);
                    throw new InvalidOperationException(message);
                }

                if (v < root.value)
                {
                    Add(ref root.left, v);
                }
                else
                {
                    Add(ref root.right, v);
                }
            }

            public bool Search(Node root, int key)
            {
                if (root == null)
                {
                    return false;
                }
                    
                if (root.value == key)
                {
                    return true;
                }
                    
                if (root.value > key)
                {
                    return Search(root.left, key);
                }      
                else
                {
                    return Search(root.right, key);
                }            
            }

            public Node FindMinElement(Node root)
            {
                Node p = root.left;
                while (p.left != null)
                {
                    p = p.left;
                }

                return p;
            }

            public Node FindMaxElement(Node root)
            {
                Node p = root.right;
                while (p.right != null)
                {
                    p = p.right;
                }

                return p;
            }

            public void Traverse(Node root)
            {
                if (root.left != null)
                {
                    Traverse(root.left);
                } 
                
                Console.Write("{0} ", root.value);

                if (root.right != null)
                {
                    Traverse(root.right);
                }       
            }

            public void GetAllNumbersGreatherThen(Node root, double minValue)
            {
                if (root.left != null)
                {
                    GetAllNumbersGreatherThen(root.left, minValue);
                }

                if (root.value > minValue)
                {
                    linkedList.AddLast(root.value);
                }

                if (root.right != null)
                {
                    GetAllNumbersGreatherThen(root.right, minValue);
                }
            }
        }
    }
}
