# Challenge 10: Stack and Queue Implementation

A class library project containing a Stack and Queue class, with the Node class used by both. The Node class here can only hold string values.

For the Stack class:
- Can `Push()` a string onto a Stack (encapsulated in a Node)
- Can `Pop()` the top Node off the Stack and return its string value
- Can `Peek()` at the top Node's value without affecting the Stack
- Can check if Stack `IsEmpty()`

For the Queue class:
- Can `Enqueue()` a string on the queue (encapsulated in a Node)
- Can `Dequeue()` the front Node from the queue, and return its string value
- Can `Peek()` at the front Node's value without affecting the queue
- Can check if queue `IsEmpty()`

## Approach & Efficiency

Stack class:
- `Push()`
    - Time: O(1)
    - Space: O(1)
- `Pop()`
    - Time: O(1)
    - Space: O(1)
- `Peek()`
    - Time: O(1)
    - Space: O(1)
- `IsEmpty()`
    - Time: O(1)
    - Space: O(1)

Queue class
- `Enqueue()`
    - Time: O(1)
    - Space: O(1)
- `Dequeue()`
    - Time: O(1)
    - Space: O(1)
- `Peek()`
    - Time: O(1)
    - Space: O(1)
- `IsEmpty()`
    - Time: O(1)
    - Space: O(1)

## Links to Code

- [Stack Class](Classes/Stack.cs)
- [Queue Class](Classes/Queue.cs)
- [Node Class](Classes/Node.cs)

## Change Log

- 1.0: Code Challenge 05: Linked Lists - 2020-07-18