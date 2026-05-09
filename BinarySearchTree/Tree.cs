namespace BinarySearchTree;

internal class Tree
{
    public TreeNode Root { get; private set; }

    public void Insert(int key)
    {
        var newNode = new TreeNode(key);
        if (Root == null) { Root = newNode; return; }

        var curr = Root;
        while (true)
        {
            if (key < curr.Key)
            {
                if (curr.Left == null) { curr.Left = newNode; break; }
                curr = curr.Left;
            }
            else
            {
                if (curr.Right == null) { curr.Right = newNode; break; }
                curr = curr.Right;
            }
        }
    }

    public TreeNode? Search(int key)
    {
        var curr = Root;
        while (curr != null)
        {
            if (key == curr.Key) return curr;
            curr = key < curr.Key ? curr.Left : curr.Right;
        }
        return null;
    }

    public void Remove(int key)
    {
        TreeNode node = Root;
        TreeNode parent = null;
        bool isLeftChild = false;

        // Находим узел и его родителя
        while (node != null && node.Key != key)
        {
            parent = node;
            if (key < node.Key) { node = node.Left; isLeftChild = true; }
            else { node = node.Right; isLeftChild = false; }
        }
        if (node == null) return; // Не найден

        // Определяем замену
        TreeNode replacement;
        if (node.Left == null)
            replacement = node.Right;
        else if (node.Right == null)
            replacement = node.Left;
        else
        {
            // Два потомка: ищем минимум в правом поддереве
            replacement = node.Right;
            TreeNode replacementParent = node;
            while (replacement.Left != null)
            {
                replacementParent = replacement;
                replacement = replacement.Left;
            }
            // Отсоединяем минимум от старого места
            if (replacementParent != node)
            {
                replacementParent.Left = replacement.Right;
                replacement.Right = node.Right;
            }
            replacement.Left = node.Left;
        }

        // Подключаем замену
        if (parent == null) Root = replacement;          // Удаляем корень
        else if (isLeftChild) parent.Left = replacement; // Левый ребёнок родителя
        else parent.Right = replacement;                 // Правый ребёнок родителя
    }
}
