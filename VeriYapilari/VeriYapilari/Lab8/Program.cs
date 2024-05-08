using System;
using System.Collections.Generic;

namespace Lab8
{
    class Node
    {
        public int veri;
        public Node sol;
        public Node sag;

        public Node(int veri)
        {
            this.veri = veri;
            this.sol = null;
            this.sag = null;
        }
    }

    class Tree
    {
        public Node root;

        public Tree()
        {
            this.root = null;
        }

        public List<int> createElements(int n)
        {
            List<int> elements = new List<int>();
            int sonDeger = Convert.ToInt32(Math.Pow(2, n) - 1);

            for (int i = 1; i <= sonDeger; i++)
                elements.Add(i);
            return elements;
        }

        public Node createTree(List<int> elements, int left, int right)
        {
            if (left > right)
                return null;

            int mid = (left + right) / 2;

            Node temp = new Node(elements[mid - 1]);

            temp.sol = createTree(elements, left, mid - 1);
            temp.sag = createTree(elements, mid + 1, right);

            return temp;
        }

        public void writeTree(Node root, int n)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int level = 0;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                int baseSpace = (int)Math.Pow(2, n - level +1) - 2;
                int branchSpace = (baseSpace * 2) + 1;
                int nodeSpace = baseSpace * 2 + 4;

                Console.Write(new string(' ', baseSpace));

                for (int i = 0; i < count; i++)
                {
                    Node node = queue.Dequeue();

                    if (node != null)
                    {
                        Console.Write(node.veri);
                        queue.Enqueue(node.sol);
                        queue.Enqueue(node.sag);
                    }
                    else
                        Console.Write(" ");

                    if (i < count - 1)
                        Console.Write(new string(' ', nodeSpace));
                }

                Console.WriteLine();
                Console.WriteLine();

                if (level < n - 1)
                {
                    Console.Write(new string(' ', baseSpace - 1));

                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("/  ");
                        Console.Write(" \\");
                        if (i < count - 1)
                            Console.Write(new string(' ',branchSpace));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                level++; 
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n değerini giriniz:");
            int n = Convert.ToInt32(Console.ReadLine());

            Tree tree = new Tree();
            List<int> elements = tree.createElements(n);

            Node node = tree.createTree(elements, 1, elements.Count);

            Console.WriteLine("Ağaç Şeklinde Gösterim:");
            tree.writeTree(node, n);

            Console.ReadLine();
        }
    }
}
