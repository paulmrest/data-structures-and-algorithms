# Challenge 35: Graphs

An implementation of a directionally linked generic graph data structure. Employs the built-in C# Dictionary class for the graph's Adjacency List to hold the vertices and edges.

- `AddNode(T value)`: adds a new vertex to the graph with value T.
- `AddEdge(Vertex<T> vertexA, Vertex<T> vertexB, W weight)`: adds a new directional edge connecting vertexA to vertexB with weight W.
- `GetNodes()`: gets a List<Vertex<T>> of all the vertices presently in teh graph.
- `GetNeighbors(Vertex<T> vertex)`: gets a List<Edge<T, W>> of the edges originating from the parameter vertex.
- `Size()`: returns an int signifying the curren number of vertices in the graph.

## Approach & Efficiency

- `AddNode(T value)`:
    - Time: O(1)
    - Space: O(1)
- `AddEdge(Vertex<T> vertexA, Vertex<T> vertexB, W weight)`:
    - Time: O(1)
    - Space: O(1)
- `GetNodes()`:
    - Time: O(n)
    - Space: O(n)
- `GetNeighbors(Vertex<T> vertex)`:
    - Time: O(n)
    - Space: O(n)
- `Size()`:
    - Time: O(1)
    - Space: O(1)

## Links to Code

- [Graph.cs](Graph/Classes/Graph.cs)
- [Vertex.cs](Graph/Classes/Vertex.cs)
- [Edge.cs](Graph/Classes/Edge.cs)

## Change Log

### 2020-08-24
- Initial implementation and tests