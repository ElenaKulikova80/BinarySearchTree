namespace BinarySearchTree;

internal class TreeNode
{
    int key;
    public int Key { get { return key; } }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int key)
    { this.key = key; }
}
