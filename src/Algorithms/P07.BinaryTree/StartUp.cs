namespace P07.BinaryTree
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var tree = new Tree();

            var node1 = new Node();
            node1.value = 10;

            tree.AddNR(ref node1, 1);
            tree.AddNR(ref node1, 2);
            tree.AddNR(ref node1, 15);
            tree.AddNR(ref node1, 8);
            tree.AddNR(ref node1, 3);
            tree.AddNR(ref node1, 3);
            tree.AddNR(ref node1, 20);

            tree.RemoveNodeNR(ref node1, 7);
            tree.RemoveNodeNR(ref node1, 3);

            tree.RemoveNodeNR(ref node1, 10);

            tree.Traverse(node1); // Output: 20 1 2 8
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
            private const string REMOVE_NODE_ERROR_MESSAGE = "The key {0} not exists in the tree.";

            //рекурсивна реализация на добавяне на елемент        
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
                    Console.WriteLine(message);

                    return;
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

            //нерекурсивна реализация на добавяне на елемент        
            public void AddNR(ref Node root, int v)
            {
                if (root == null)
                {
                    root = new Node();
                    root.value = v;

                    return;
                }

                bool isAlreadyExist = SearchNR(root, v);

                if (isAlreadyExist)
                {
                    string message = String.Format(ADD_NODE_ERROR_MESSAGE, v);
                    Console.WriteLine(message);

                    return;
                }

                Node newNode = new Node();
                newNode.value = v;
                Node prior = root;
                Node next;
                if (v < root.value)
                    next = root.left;
                else
                    next = root.right;
                while (next != null)
                {
                    prior = next;
                    if (v < prior.value)
                        next = prior.left;
                    else
                        next = prior.right;
                }
                if (v < prior.value)
                    prior.left = newNode;
                else
                    prior.right = newNode;
            }

            //рекурсивна реализация на търсене на елемент
            public bool Search(Node root, int key)
            {
                if (root == null)
                    return false;
                if (root.value == key)
                    return true;
                if (root.value > key)
                    return Search(root.left, key);
                else
                    return Search(root.right, key);
            }

            //нерекурсивна реализация на търсене на елемент 
            public bool SearchNR(Node root, int key)
            {
                Node parent;

                Node curr = root;

                while (curr != null && curr.value != key)
                {
                    parent = curr;

                    if (key < curr.value)
                    {
                        curr = curr.left;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }

                return curr != null;
            }

            //намиране на минимален елемент в дясно поддърво
            Node FindMinRight(Node root)
            {
                Node p = root.right;
                while (p.left != null)
                {
                    p = p.left;
                }
                return p;
            }

            //рекурсивна реализация на изтриване на елемент
            public void RemoveNode(ref Node root, int key)
            {
                if (root == null)
                {
                    Console.WriteLine("No such key");
                }
                else
                    if (key < root.value)
                    RemoveNode(ref root.left, key);
                else
                {
                    if (key > root.value)
                        RemoveNode(ref root.right, key);
                    else
                    {
                        if (root.left != null && root.right != null)
                        {
                            Node replace = FindMinRight(root);
                            root.value = replace.value;
                            RemoveNode(ref root.right, root.value);
                        }
                        else
                        {
                            Node temp = root;
                            if (root.left != null) root = root.left;
                            else root = root.right;
                            temp = null;
                        }
                    }
                }

            }

            //нерекурсивна реализация на изтриване на елемент
            public void RemoveNodeNR(ref Node root, int key)
            {
                Node parent = null;
                Node curr = root;

                while (curr != null && curr.value != key)
                {
                    parent = curr;

                    if (key < curr.value)
                    {
                        curr = curr.left;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }

                if (curr == null)
                {
                    string message = String.Format(REMOVE_NODE_ERROR_MESSAGE, key);
                    Console.WriteLine(message);

                    return;
                }

                if (curr.left == null && curr.right == null)
                {
                    if (curr != root)
                    {
                        if (parent.left == curr)
                        {
                            parent.left = null;
                        }
                        else
                        {
                            parent.right = null;
                        }
                    }
                    else
                    {
                        root = null;
                    }
                }
                else
                {
                    Node child = (curr.left != null) ? curr.left : curr.right;

                    if (curr != root)
                    {
                        if (curr == parent.left)
                        {
                            parent.left = child;
                        }
                        else
                        {
                            parent.right = child;
                        }
                    }
                    else
                    {
                        if (root.right != null)
                        {
                            child.left = root.right;
                        }

                        root = child;
                    }
                }
            }

            //ЛКД обхождане на дървото
            public void Traverse(Node root)
            {
                if (root.left != null)
                    Traverse(root.left);
                Console.Write("{0} ", root.value);
                if (root.right != null)
                    Traverse(root.right);
            }

        }
    }
}
