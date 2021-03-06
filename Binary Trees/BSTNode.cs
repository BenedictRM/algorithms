public class BSTNode{
    public BSTNode Left {get; set;}
    public BSTNode Right {get; set;}
    public int Value;
    public int Level;
    public int? ParentConsolePadding;
    public bool IsLeftNode;

    public BSTNode(int value, int level) {
        this.Value = value;
        this.Level = level;
    }
}