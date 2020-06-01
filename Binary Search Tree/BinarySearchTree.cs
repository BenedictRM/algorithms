using System;
using System.Linq;
using System.Collections.Generic;

public class BinarySearchTree {
    private BSTNode root {get; set;}
    public BinarySearchTree(List<int> values) {
        if(values.Any()) {
            this.root = new BSTNode(values[0], 0);
            values.RemoveAt(0);
        }

        foreach(int value in values) {
            AddNode(value);
        }
    }

    public void AddNode(int value) {
        AddNode(this.root, value, 0);
    }

    private BSTNode AddNode(BSTNode node, int value, int level) {
        if(node == null)
            return new BSTNode(value, level);

        if(value < node.Value) {
            node.Left = AddNode(node.Left, value, level + 1);
        } else if(value > node.Value){
            node.Right = AddNode(node.Right, value, level + 1);
        }

        return node;
    }

    public void RemoveNode(int value) {
        this.root = RemoveNode(this.root, value);
    }

    private BSTNode RemoveNode(BSTNode node, int value) {
        if(value < node.Value)
            RemoveNode(node.Left, value);
        else if(value > node.Value)
            RemoveNode(node.Right, value);
        
        if(node.Left == null)
            return node.Right;//TODO:Subtract Level
        else if(node.Right == null)
            return node.Left;//TODO:Subtract Level
        
        node.Value = MinValue(node.Right);
        node.Right = RemoveNode(node.Right, node.Value);

        return node;
    }

    private int MinValue(BSTNode node) {
        int min = node.Value;

        while(node.Left != null) {
            min = node.Left.Value;
            node = node.Left;
        }

        return min;
    }

    public void PrintTreeToConsole() {
        Console.WriteLine("Printing Tree...");

        if(this.root != null) {
            Queue<BSTNode> q = new Queue<BSTNode>();
            q.Enqueue(this.root);
            PrintTreeToConsole(q);
        }
    }

    private void PrintTreeToConsole(Queue<BSTNode> q) {
        if(!q.Any())
            return;
        
        BSTNode node = q.Dequeue();

        Console.WriteLine(node.Value + " : " + node.Level);

        if(node.Left != null)
            q.Enqueue(node.Left);
        if(node.Right != null)
            q.Enqueue(node.Right);

        PrintTreeToConsole(q);
    }
}