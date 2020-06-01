using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : BinaryTree {
    private BSTNode root {get; set;}
    private int treeHeight {get; set;}
    private Dictionary<int, String> treeNodesByLevel;

    public BinarySearchTree(List<int> values) {
        this.treeHeight = 0;
        treeNodesByLevel = new Dictionary<int, string>();

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
        if(node == null) {
            if(level > this.treeHeight)
                treeHeight = level;

            return new BSTNode(value, level);
        }

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

    //TODO: Adjust tree height on delete
    private BSTNode RemoveNode(BSTNode node, int value) {
        if(value < node.Value)
            node.Left = RemoveNode(node.Left, value);
        else if(value > node.Value)
            node.Right = RemoveNode(node.Right, value);
        else {
            if(node.Left == null) {
                if(node.Right != null)
                    node.Right.Level--;

                return node.Right;
            }
            else if(node.Right == null) {
                if(node.Left != null)
                    node.Left.Level--;

                return node.Left;
            }
            
            //WARNING: Since just changing value of parent node, the level will effectively be correct so no need to --
            node.Value = MinValue(node.Right);
            node.Right = RemoveNode(node.Right, node.Value);
        }

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

    //TODO: calc padding of parent, then enqueue children -- as queing store the print string of the children so they show on the same level -- pass to method thqt prints this new struct
    //Map of level (int) to String/should be good -- Nodes visted level order so should be good
    private void PrintTreeToConsole(Queue<BSTNode> q) {
        BuildStrings(q);

        foreach(string str in this.treeNodesByLevel.Values) {
            Console.Write(str);
            Console.WriteLine();
        }
        // if(!q.Any())
        //     return;
        
        // BSTNode node = q.Dequeue();

        // string nodeStr = "" + node.Value;
        // int padding = (treeHeight - node.Level) * 5;

        // Console.Write(nodeStr.PadLeft(padding));
        // Console.WriteLine();

        // if(node.Left != null)
        //     q.Enqueue(node.Left);
        // if(node.Right != null)
        //     q.Enqueue(node.Right);

        // PrintTreeToConsole(q);
    }

    private void BuildStrings(Queue<BSTNode> q) {
        if(!q.Any())
            return;
        
        BSTNode node = q.Dequeue();
        int padding = 0;

        if(node.ParentConsolePadding >= 0) {
            if(node.IsLeftNode)
                padding = node.ParentConsolePadding - 5;
            else
                padding = node.ParentConsolePadding + 5;
        } else {
            padding = (treeHeight - node.Level) * 5;
        }

        if(padding < 0)
            padding = 0;

        string nodeStr = "" + node.Value;
        nodeStr = nodeStr.PadLeft(padding);

        if(treeNodesByLevel.ContainsKey(node.Level)) {
            string level = treeNodesByLevel[node.Level];
            nodeStr = level + nodeStr;
        }

        treeNodesByLevel[node.Level] = nodeStr;

        if(node.Left != null) {
            node.Left.ParentConsolePadding = padding;
            node.Left.IsLeftNode = true;
            q.Enqueue(node.Left);
        }
        if(node.Right != null) {
            node.Right.ParentConsolePadding = padding;
            node.Right.IsLeftNode = false;
            q.Enqueue(node.Right);
        }

        PrintTreeToConsole(q);
    }
}