using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.Classes
{
    public class Graph<T, W>
    {
        public Dictionary<Vertex<T>, List<Edge<T, W>>> AdjList { get; set; }

        private int _size;

        /// <summary>
        /// Instantiates a new Graph.
        /// </summary>
        public Graph()
        {
            AdjList = new Dictionary<Vertex<T>, List<Edge<T, W>>>();
            _size = 0;
        }

        /// <summary>
        /// Adds a node/vertex to the Graph.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Vertex<T> AddNode(T value)
        {
            Vertex<T> newVertex = new Vertex<T>(value);
            AdjList.Add(newVertex, new List<Edge<T, W>>());
            _size++;
            return newVertex;
        }

        /// <summary>
        /// Adds a new weighted directional Edge, signifying a connection between vertexA and vertexB.
        /// </summary>
        /// <param name="vertexA">
        /// Vertex<T>: the vertex the connection originates with
        /// </param>
        /// <param name="vertexB">
        /// Vertex<T>: the vertex the connection travels to
        /// </param>
        /// <param name="weight">
        /// int: the weight of the connection
        /// </param>
        public void AddEdge(Vertex<T> vertexA, Vertex<T> vertexB, W weight)
        {
            Edge<T, W> newEdge = new Edge<T, W>
            {
                Vertex = vertexB,
                Weight = weight
            };
            AdjList[vertexA].Add(newEdge);
        }

        /// <summary>
        /// Gets a List of the vertices in the graph.
        /// </summary>
        /// <returns>   
        /// List<Vertex<T>>: a List of all the vertices in the graph
        /// </returns>
        public List<Vertex<T>> GetNodes()
        {
            List<Vertex<T>> vertices = new List<Vertex<T>>();
            foreach (KeyValuePair<Vertex<T>, List<Edge<T,W>>> oneKVPair in AdjList)
            {
                vertices.Add(oneKVPair.Key);
            }
            return vertices;
        }

        /// <summary>
        /// Gets a List of the Edges for a given vertex. So all the edges originating at that vertex. Does not get the edges that connect to that vertex
        /// </summary>
        /// <param name="vertex">
        /// Vertex<T>: a vertex with one of more edges originating from it
        /// </param>
        /// <returns>
        /// List<Edge<T,W>>: a List of the edges connected to the parameter vertex
        /// </returns>
        public List<Edge<T,W>> GetNeighbors(Vertex<T> vertex)
        {
            List<Edge<T, W>> edges = new List<Edge<T, W>>();
            foreach(Edge<T,W> oneEdge in AdjList[vertex])
            {
                edges.Add(oneEdge);
            }
            return edges;
        }

        /// <summary>
        /// Gets the current number of vertices in the graph.
        /// </summary>
        /// <returns>
        /// int: the number of vertices presently in the graph
        /// </returns>
        public int Size()
        {
            return _size;
        }

        /// <summary>
        /// Gets a breadth first traversal of the graph starting at the parameter vertex, returning a List of the vertices connected through the graph to that parameter vertex.
        /// </summary>
        /// <param name="vertex">
        /// Vertex<T>: the vertex at which to start the traversal
        /// </param>
        /// <returns>
        /// List<Vertex<T>>: a List of all the vertices connected to the parameter vertex
        /// </returns>
        public List<Vertex<T>> BreadthFirst(Vertex<T> vertex)
        {
            List<Vertex<T>> vertices = new List<Vertex<T>>();
            BreathFirst(vertex, vertices);
            return vertices;
        }

        /// <summary>
        /// Conducts a recursive traversal of the graph, starting at the parameter Vertex, putting the vertices into the parameter List.
        /// </summary>
        /// <param name="currVertex">
        /// Vertex<T>: the originating vertex for a given layer in the recursion
        /// </param>
        /// <param name="traversal">
        /// List<Vertex<T>>: the traversal list, modified in place as the traversal proceeds
        /// </param>
        private void BreathFirst(Vertex<T> currVertex, List<Vertex<T>> traversal)
        {
            traversal.Add(currVertex);
            List<Edge<T, W>> currEdges = AdjList[currVertex];
            foreach (Edge<T,W> oneEdge in currEdges)
            {
                if (oneEdge.Vertex != null && !traversal.Contains(oneEdge.Vertex))
                {
                    BreathFirst(oneEdge.Vertex, traversal);
                }
            }
        }
    }

    /// <summary>
    /// Extension class for Coding Challenge 37.
    /// As we are only dealing with Graph<string, int>.
    /// </summary>
    public static class GetEdgesExtension
    {
        /// <summary>
        /// Finds whether a given route is possible in the given graph, and returns a tuple with that route's cost.
        /// </summary>
        /// <param name="graph">
        /// Graph<string, int>: the graph the route potentially exists within
        /// </param>
        /// <param name="route">
        /// string[]: the route we are looking for within the graph
        /// </param>
        /// <returns>
        /// Tuple<bool, int>: a tuple containing whether the route is possible (bool), and if it is, its cost (int). If the route is not possible, returns -1 for the cost
        /// </returns>
        public static Tuple<bool, int> GetEdges(this Graph<string, int> graph, string[] route)
        {
            if (route.Length == 0 && graph.Size() > 0)
            {
                return Tuple.Create(true, 0);
            }
            else
            {
                var vertices = graph.AdjList.Keys;
                foreach (Vertex<string> oneVertex in vertices)
                {
                    var result = GetEdges(graph, new List<Vertex<string>>(), oneVertex, route, 0, 0);
                    if (result.Item1)
                    {
                        return result;
                    }
                }
                return Tuple.Create(false, -1);
            }
        }

        /// <summary>
        /// Recursive private method for traversing a graph starting from a given vertex, and looks for the parameter route.
        /// </summary>
        /// <param name="graph">
        /// Graph<string, int>: the graph we are traversing
        /// </param>
        /// <param name="traversal">
        /// List<Vertex<string>>: a List of the vertices seen so far in a given traversal. Allows checking for whether we are in an infinite loop in the graph.
        /// </param>
        /// <param name="currVertex">
        /// Vertex<string>: the current vertex we are looking at in the traversal
        /// </param>
        /// <param name="route">
        /// string[]: the route we are looking for as an array of destinations
        /// </param>
        /// <param name="index">
        /// int: the index of the next destination we are looking for in the route string[]
        /// </param>
        /// <param name="cost">
        /// int: once a possible route is found, keeps track of the total cost of the route
        /// </param>
        /// <returns>
        /// Tuple<bool, int>: a tuple containing whether the route is possible (bool), and if it is, its cost (int). If the route is not possible, returns -1 for the cost.
        /// </returns>
        private static Tuple<bool, int> GetEdges(this Graph<string, int> graph, List<Vertex<string>> traversal, Vertex<string> currVertex, string[] route, int index, int cost)
        {
            if (!traversal.Contains(currVertex))
            {
                traversal.Add(currVertex);
                if (currVertex.Value.ToLower() == route[index].ToLower())
                {
                    index++;
                    if (index >= route.Length)
                    {
                        return Tuple.Create(true, cost);
                    }
                }
                var vertexEdges = graph.GetNeighbors(currVertex);
                foreach (var oneEdge in vertexEdges)
                {
                    cost += oneEdge.Weight;
                    return GetEdges(graph, traversal, oneEdge.Vertex, route, index, cost);
                }
            }
            return Tuple.Create(false, -1);
        }
    }
}
