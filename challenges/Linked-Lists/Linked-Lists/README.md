# Challenge 05: Linked List Implementation

Create a (singly linked) linked list and node class with the following methods:

- `Insert()`: takes an integer value, creates a new node and inserts that node at the beginning of the linked list.
- `Includes()`: take an integer value, and returns true if the linked list contains that value, or false if not.
- `ToString()`: prints to the console a useful representation of the linked list.

Linked list was created in class and is included here as a DLL.

## Approach & Efficiency

- `Insert()`
    - Time: O(1)
    - Space: O(1)
    - This method simply creates a the new node and changes two references.
- `Includes()`
    - Time: O(n)
    - Space: O(1)
    - This method iterates over the linked list until it finds a node that matches the value.
- `ToString()`
    - Time: O(n)
    - Space: O(n)
    - This method iterates over the linked list, building a StringBuilder object.

## Example

![Linked List Execution](../../../assets/LinkedList-Example.png)

## Links to Code

- [Linked List Class](../../Libraries/LLLibrary/LinkedList.cs)
- [Node Class](../../Libraries/LLLibrary/Node.cs)

## Change Log

- 1.0: Code Challenge 05: Linked Lists - 2020-07-11