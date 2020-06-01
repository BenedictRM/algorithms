public class AbstractBinaryTreeDecorator : BinaryTree {
    private BinaryTree binaryTreeToDecorate;
    protected AbstractBinaryTreeDecorator(BinaryTree binaryTreeToDecorate) {
        this.binaryTreeToDecorate = binaryTreeToDecorate;
    }

    public void AddNode(int value){
        this.binaryTreeToDecorate.AddNode(value);
    }
    public void RemoveNode(int value){
        this.binaryTreeToDecorate.RemoveNode(value);
    }
    public void PrintTreeToConsole(){
        this.binaryTreeToDecorate.PrintTreeToConsole();
    }

}