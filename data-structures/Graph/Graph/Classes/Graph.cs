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
    }
}
