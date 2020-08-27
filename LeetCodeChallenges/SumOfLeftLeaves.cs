namespace algorithms.LeetCodeChallenges
{

    /**
    * Definition for a binary tree node.
    * public class TreeNode {
    *     public int val;
    *     public TreeNode left;
    *     public TreeNode right;
    *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
    *         this.val = val;
    *         this.left = left;
    *         this.right = right;
    *     }
    * }
    */
    public class SumOfLeftLeaves
    {
        //WARNING: Commented out so Program.cs could compile -- did not implement TreeNode so it fails compilation
        // public int SumOfLeftLeaves(TreeNode root) {
        //     int total = 0;
            
        //     if(root != null) {
        //         if(root.left != null) {
        //             if(isLeaf(root.left))
        //                 total = root.left.val;
        //             else
        //                 total += SumOfLeftLeaves(root.left);
        //         }

        //         if(root.right != null) {
        //             total += SumOfLeftLeaves(root.right);
        //         }
        //     }

        //     return total;
        // }
        
        // private bool isLeaf(TreeNode node) {
        //     bool isLeaf = false;

        //     if(node.left == null && node.right == null)
        //         isLeaf = true;

        //     return isLeaf;
        // }
    }
}