using System;
using Xunit;
using Graph.Classes;
using Graph;
using System.Linq;
using System.Collections.Generic;

namespace GraphTesting
{
    public class GraphTests
    {


        //Node can be successfully added to the graph
        [Fact]
        public void CanAddVertexToGraph()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            testGraph.AddNode("just a little vertex lost in the graph");

            //Assert
            Assert.NotNull(testGraph);
            Assert.True(testGraph.AdjList.Count > 0);
        }

        //An edge can be successfully added to the graph
        [Fact]
        public void CanAddEdgeToGraph()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);

            Edge<string, int> linkingEdge = testGraph.AdjList[vertexOne].FirstOrDefault(x => x.Vertex == vertexTwo);

            //Assert
            Assert.NotNull(testGraph);
            Assert.Single(testGraph.AdjList[vertexOne]);
            Assert.NotNull(linkingEdge);
            Assert.NotNull(linkingEdge.Vertex);
            Assert.Equal(50, linkingEdge.Weight);
        }

        //A collection of all nodes can be properly retrieved from the graph
        [Fact]
        public void CanGetAllVertices()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);

            List<Vertex<string>> allVertices = testGraph.GetNodes();

            Edge<string, int> vOnevTwoEdge = testGraph.AdjList[vertexOne].FirstOrDefault(x => x.Vertex == vertexTwo);
            Edge<string, int> vTwovThreeEdge = testGraph.AdjList[vertexTwo].FirstOrDefault(x => x.Vertex == vertexThree);

            //Assert
            Assert.NotNull(allVertices);
            Assert.Equal(3, allVertices.Count);
            Assert.Equal(vertexTwo, vOnevTwoEdge.Vertex);
            Assert.Equal(vertexThree, vTwovThreeEdge.Vertex);
        }

        //All appropriate neighbors can be retrieved from the graph
        [Fact]
        public void CanGetAllNeighbors()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexOne, vertexThree, 25);

            List<Edge<string, int>> neighbors = testGraph.GetNeighbors(vertexOne);

            //Assert
            Assert.NotNull(neighbors);
            Assert.Equal(2, neighbors.Count);
        }


        //Neighbors are returned with the weight between nodes included
        [Fact]
        public void CanGetNeighborsWithWeightValues()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexOne, vertexThree, 25);

            List<Edge<string, int>> neighbors = testGraph.GetNeighbors(vertexOne);
            int vOnevTwoEdgeWeight = neighbors
                .Where(x => x.Vertex == vertexTwo)
                .Select(x => x.Weight)
                .FirstOrDefault();

            int vOnevThreeEdgeWeight = neighbors
                .Where(x => x.Vertex == vertexThree)
                .Select(x => x.Weight)
                .FirstOrDefault();

            //Assert
            Assert.NotNull(neighbors);
            Assert.Equal(2, neighbors.Count);
            Assert.Equal(50, vOnevTwoEdgeWeight);
            Assert.Equal(25, vOnevThreeEdgeWeight);
        }

        //The proper size is returned, representing the number of nodes in the graph
        [Fact]
        public void CanGetGraphSize()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexOne, vertexThree, 25);


            //Assert
            Assert.NotNull(testGraph);
            Assert.Equal(3, testGraph.Size());
        }

        //A graph with only one node and edge can be properly returned
        [Fact]
        public void CanGetNeighborForAOneNodeGraph()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Act
            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            testGraph.AddEdge(vertexOne, vertexOne, 50);

            List<Edge<string, int>> neighbors = testGraph.GetNeighbors(vertexOne);
            Edge<string, int> vOneEdge = neighbors
                .Where(x => x.Vertex == vertexOne)
                .FirstOrDefault();

            //Assert
            Assert.NotNull(neighbors);
            Assert.Single(neighbors);
            Assert.Equal(50, vOneEdge.Weight);
            Assert.Equal(vertexOne, vOneEdge.Vertex);
        }

        //An empty graph properly returns null
        [Fact]
        public void EmptyGraphIsNull()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            //Assert
            Assert.Equal(0, testGraph.Size());
        }

    }
}
