using System;
using System.Linq;
using System.Collections.Generic;

public class BinarySearchTree : BinaryTree {
    private BSTNode root {get; set;}
    private int treeHeight {get; set;}
    private Dictionary<int, String> treeNodesByLevel;
    private Dictionary<int, String> branchesByLevel;

    public BinarySearchTree(List<int> values) {
        this.treeHeight = 0;
        this.treeNodesByLevel = new Dictionary<int, string>();
        this.branchesByLevel = new Dictionary<int, string>();

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

    private void PrintTreeToConsole(Queue<BSTNode> q) {
        BuildTreeNodeByLevel(q);

        foreach(int key in this.treeNodesByLevel.Keys) {
            string level = this.treeNodesByLevel[key];
            if(key != 0) {
                string branches = this.branchesByLevel[key];
                Console.Write(branches);
                Console.WriteLine();
            }
            Console.Write(level);
            Console.WriteLine();
        }
        
        this.treeNodesByLevel.Clear();
    }

    private void BuildTreeNodeByLevel(Queue<BSTNode> q) {
        if(!q.Any())
            return;
        
        BSTNode node = q.Dequeue();
        int padding = 0;

        if(node.ParentConsolePadding >= 0) {
            if(node.IsLeftNode)
                padding = (int)node.ParentConsolePadding - 5;
            else
                padding = (int)node.ParentConsolePadding + 5;
        } else {
            //Get root node in the middle
            padding = (treeHeight - node.Level) * 5;
        }

        if(padding < 0)
            padding = 0;
            
        string nodeStr = "" + node.Value;
        string branch = node.IsLeftNode ? "/" : @"\";
        int branchOffset = node.IsLeftNode ? 2 : -2;

        if(treeNodesByLevel.ContainsKey(node.Level)) {
            string level = treeNodesByLevel[node.Level];
            nodeStr = nodeStr.PadLeft(padding - level.Length);
            nodeStr = level + nodeStr;

            string branchLevel = branchesByLevel[node.Level];
            branch = branch.PadLeft((padding - branchLevel.Length) + branchOffset);
            branch = branchLevel + branch;
        } else {
            nodeStr = nodeStr.PadLeft(padding);
            branch = branch.PadLeft(padding + branchOffset);
        }

        treeNodesByLevel[node.Level] = nodeStr;
        if(node.Level != 0)
            branchesByLevel[node.Level] = branch;

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

        BuildTreeNodeByLevel(q);
    }
}