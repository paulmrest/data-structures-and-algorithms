# Challenge 15: Binary Tree and BST Implementation

A .NET class library project that implements a generic Node class, a generic Tree class, and a <int> BinarySearchTree class.

## Tree.cs
`PreOrder()` - returns a pre-ordered List<T> of the values in the tree.
`InOrder()` - returns an in-order List<T> of the values in the tree.
`PostOrder()` - returns a post-ordered List<T> of the values in the tree.

## BinarySearchTree.cs
-`Add()` - adds a new node with an int value in sorted order to the binary tree.
-`Contains()` - checks whether a given int value is present in the binary search tree, returns true it is, false otherwise.

## Approach & Efficiency

### Tree.cs

- `PreOrder()`
    - Time: O(n)
    - Space: O(n)
- `InOrder()`
    - Time: O(n)
    - Space: O(n)
- `PostOrder()`
    - Time: O(n)
    - Space: O(n)

### BinarySearchTree.cs

- `Add()`
    - Time: O(log h)
    - Space: O(1)
- `Contains()`
    - Time: O(log h)
    - Space: O(1)

## Link(s) to Code

- [Node.cs](Classes/Node.cs)
- [Tree.cs](Classes/Tree.cs)
- [BinarySearchTree.cs](Classes/BinarySearchTree.cs)

## Change Log

### 2020-07-28

- Binary search tree added.

### 2020-07-26

- Initial implementation.