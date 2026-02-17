public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Start Problem 1

        if (Data == value)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value, Node? node = null)
    {
        // Start Problem 2
        // To handle the problem with recursion the simplest way
        // is to add an additional parameter to track the current
        // node, this should be null by default on the method.

        // Initialize from the root node
        if (node is null)
        {
            node = this;
        }

        // Return true in case the current node data is equal to data
        if (node.Data == value)
        {
            return true;
        }

        // Check if the value is less than or grather than data, this
        // will allow to determine which path to go to (left or right).
        // In case the last node is empty from left or right on the path
        // it should return false, because the item is not on the tree
        // since it went through the possible path that the item would
        // be at.
        if (value < node.Data)
        {
            if (node.Left is null)
                return false;
            else
                return Contains(value, node.Left);
        }
        else
        {
            if (node.Right is null)
                return false;
            else
                return Contains(value, node.Right);
        }
    }

    public int GetHeight(int leftHeight = 0, int rightHeight = 0)
    {
        // Start Problem 4

        if (Left is null && Right is null)
        {
            return 1;
        }

        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }

        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
    }
}