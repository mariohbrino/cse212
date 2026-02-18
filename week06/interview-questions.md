1. Describe a recursive function that accepts a valid Binary Tree and determines
if it is a Binary Search Tree.

Assuming that the binary search tree (BST) is not accept duplicates, then I beleive
that we can determine that it's a BST by checking if it has left and right subtree
nodes with lower values to the left and grather values to the right of the root node.

- Left nodes values must be lower than parent node
- Right nodes values must be grather than parent node
- A BST don't need to be balanced, however it should not have items within one subtree
node side
