using System;
using System.Collections.Generic;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // HashTable h = new HashTable();

            Console.WriteLine("Creating Binary Search Tree");
            List<int> values = new List<int>{5,2,9,45,3,1};
            BinarySearchTree bst = new BinarySearchTree(values);

            bst.PrintTreeToConsole();

            bst.RemoveNode(5);
            bst.PrintTreeToConsole();
        }
    }
}
