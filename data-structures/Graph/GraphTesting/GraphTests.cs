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

            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");

            //Act
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

            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            
            //Act
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

            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexOne, vertexThree, 25);

            //Act
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

            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            Vertex<string> vertexTwo = testGraph.AddNode("a vertex home alone and sad");
            Vertex<string> vertexThree = testGraph.AddNode("this vertex is too busy to be sad");
            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexOne, vertexThree, 25);

            //Act
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

            Vertex<string> vertexOne = testGraph.AddNode("just a little vertex lost in the graph");
            testGraph.AddEdge(vertexOne, vertexOne, 50);

            //Act
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

    public class BreadthFirstTests
    {
        [Fact]
        public void CanTraverseAGraphWithOneNode()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");

            string[] expectedOrder = new string[]
            {
                "vertexOne"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.BreadthFirst(vertexOne);

            //Assert
            Assert.NotNull(traversal);
            Assert.Single(traversal);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void CanTraverseAGraphWithOneNodeWhoseEdgePointsAtItself()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");

            testGraph.AddEdge(vertexOne, vertexOne, 50);

            string[] expectedOrder = new string[]
            {
                "vertexOne"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.BreadthFirst(vertexOne);

            //Assert
            Assert.NotNull(traversal);
            Assert.Single(traversal);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void CanTraverseAGraph()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");
            Vertex<string> vertexTwo = testGraph.AddNode("vertexTwo");
            Vertex<string> vertexThree = testGraph.AddNode("vertexThree");
            Vertex<string> vertexFour = testGraph.AddNode("vertexFour");
            Vertex<string> vertexFive = testGraph.AddNode("vertexFive");
            Vertex<string> vertexSix = testGraph.AddNode("vertexSix");

            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            testGraph.AddEdge(vertexTwo, vertexFour, 25);
            testGraph.AddEdge(vertexTwo, vertexSix, 25);
            testGraph.AddEdge(vertexThree, vertexFive, 25);

            string[] expectedOrder = new string[]
            {
                "vertexOne",
                "vertexTwo",
                "vertexThree",
                "vertexFour",
                "vertexSix",
                "vertexFive"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.BreadthFirst(vertexOne);

            //Assert
            Assert.NotNull(traversal);
            Assert.Equal(6, traversal.Count);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void CanTraverseAGraphWithCircularEdges()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");
            Vertex<string> vertexTwo = testGraph.AddNode("vertexTwo");
            Vertex<string> vertexThree = testGraph.AddNode("vertexThree");
            Vertex<string> vertexFour = testGraph.AddNode("vertexFour");
            Vertex<string> vertexFive = testGraph.AddNode("vertexFive");

            testGraph.AddEdge(vertexOne, vertexTwo, 25);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            testGraph.AddEdge(vertexTwo, vertexFour, 25);
            testGraph.AddEdge(vertexThree, vertexFive, 25);
            testGraph.AddEdge(vertexFive, vertexTwo, 25);
            testGraph.AddEdge(vertexFour, vertexThree, 25);

            string[] expectedOrder = new string[]
            {
                "vertexOne",
                "vertexTwo",
                "vertexThree",
                "vertexFour",
                "vertexFive"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.BreadthFirst(vertexOne);

            //Assert
            Assert.NotNull(traversal);
            Assert.Equal(5, traversal.Count);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void DoesNotTraverseIslandVertices()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");
            Vertex<string> vertexTwo = testGraph.AddNode("vertexTwo");
            Vertex<string> vertexThree = testGraph.AddNode("vertexThree");
            Vertex<string> vertexFour = testGraph.AddNode("vertexFour");
            Vertex<string> vertexFive = testGraph.AddNode("vertexFive");

            testGraph.AddEdge(vertexOne, vertexTwo, 25);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            testGraph.AddEdge(vertexTwo, vertexOne, 25);

            testGraph.AddEdge(vertexFive, vertexFour, 25);
            testGraph.AddEdge(vertexFour, vertexFive, 25);

            string[] expectedOrder = new string[]
            {
                "vertexOne",
                "vertexTwo",
                "vertexThree"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.BreadthFirst(vertexOne);

            //Assert
            Assert.NotNull(traversal);
            Assert.Equal(3, traversal.Count);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }
    }

    public class GetEdges
    {
        [Fact]
        public void ReturnsTrueForAnEmptyArray()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("cheese plate");
            Vertex<string> vertexTwo = testGraph.AddNode("martini pitcher");
            Vertex<string> vertexThree = testGraph.AddNode("salmon puffs");

            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);


            string[] locations = new string[] { };

            //Act
            var result = GetEdgesExtension.GetEdges(testGraph, locations);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Item1);
            Assert.Equal(0, result.Item2);
        }

        [Fact]
        public void ReturnsFalseForEmptyGraph()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            string[] locations = new string[] { };

            //Act
            var result = GetEdgesExtension.GetEdges(testGraph, locations);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.Item1);
            Assert.Equal(-1, result.Item2);
        }

        [Fact]
        public void CanFindSimpleRoute()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("cheese plate");
            Vertex<string> vertexTwo = testGraph.AddNode("martini pitcher");
            Vertex<string> vertexThree = testGraph.AddNode("salmon puffs");

            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);


            string[] locations = new string[] { "cheese plate", "martini pitcher", "salmon puffs" };

            //Act
            var result = GetEdgesExtension.GetEdges(testGraph, locations);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Item1);
            Assert.Equal(75, result.Item2);
        }

        [Fact]
        public void CanFindRouteInComplexGraphWithCircularRoutes()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("cheese plate");
            Vertex<string> vertexTwo = testGraph.AddNode("martini pitcher");
            Vertex<string> vertexThree = testGraph.AddNode("salmon puffs");
            Vertex<string> vertexFour = testGraph.AddNode("whiskey cabinet");
            Vertex<string> vertexFive = testGraph.AddNode("pancake table");

            testGraph.AddEdge(vertexTwo, vertexFive, 50);
            testGraph.AddEdge(vertexFive, vertexOne, 25);

            testGraph.AddEdge(vertexOne, vertexFour, 12);
            testGraph.AddEdge(vertexThree, vertexFive, 5);
            testGraph.AddEdge(vertexFour, vertexThree, 19);
            testGraph.AddEdge(vertexOne, vertexTwo, 7);

            string[] locations = new string[] { "martini pitcher", "pancake table", "cheese plate" };

            //Act
            var result = GetEdgesExtension.GetEdges(testGraph, locations);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Item1);
            Assert.Equal(75, result.Item2);
        }
    }

    public class DepthFirstTests
    {
        [Fact]
        public void CanTraverseAGraphWithOneNode()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");

            string[] expectedOrder = new string[]
            {
                "vertexOne"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.DepthFirst();

            //Assert
            Assert.NotNull(traversal);
            Assert.Single(traversal);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void CanTraverseAGraphWithOneNodeWhoseEdgePointsAtItself()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");

            testGraph.AddEdge(vertexOne, vertexOne, 50);

            string[] expectedOrder = new string[]
            {
                "vertexOne"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.DepthFirst();

            //Assert
            Assert.NotNull(traversal);
            Assert.Single(traversal);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void CanTraverseAGraph()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");
            Vertex<string> vertexTwo = testGraph.AddNode("vertexTwo");
            Vertex<string> vertexThree = testGraph.AddNode("vertexThree");
            Vertex<string> vertexFour = testGraph.AddNode("vertexFour");
            Vertex<string> vertexFive = testGraph.AddNode("vertexFive");
            Vertex<string> vertexSix = testGraph.AddNode("vertexSix");

            testGraph.AddEdge(vertexOne, vertexTwo, 50);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            testGraph.AddEdge(vertexTwo, vertexFour, 25);
            testGraph.AddEdge(vertexTwo, vertexSix, 25);
            testGraph.AddEdge(vertexThree, vertexFive, 25);

            string[] expectedOrder = new string[]
            {
                "vertexOne",
                "vertexTwo",
                "vertexThree",
                "vertexFive",
                "vertexFour",
                "vertexSix"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.DepthFirst();

            //Assert
            Assert.NotNull(traversal);
            Assert.Equal(6, traversal.Count);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void CanTraverseAGraphWithCircularEdges()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");
            Vertex<string> vertexTwo = testGraph.AddNode("vertexTwo");
            Vertex<string> vertexThree = testGraph.AddNode("vertexThree");
            Vertex<string> vertexFour = testGraph.AddNode("vertexFour");
            Vertex<string> vertexFive = testGraph.AddNode("vertexFive");

            testGraph.AddEdge(vertexOne, vertexTwo, 25);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            testGraph.AddEdge(vertexTwo, vertexFour, 25);
            testGraph.AddEdge(vertexThree, vertexFive, 25);
            testGraph.AddEdge(vertexFive, vertexTwo, 25);
            testGraph.AddEdge(vertexFour, vertexThree, 25);

            string[] expectedOrder = new string[]
            {
                "vertexOne",
                "vertexTwo",
                "vertexThree",
                "vertexFive",
                "vertexFour"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.DepthFirst();

            //Assert
            Assert.NotNull(traversal);
            Assert.Equal(5, traversal.Count);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }

        [Fact]
        public void DoesNotTraverseIslandVertices()
        {
            //Arrange
            Graph<string, int> testGraph = new Graph<string, int>();

            Vertex<string> vertexOne = testGraph.AddNode("vertexOne");
            Vertex<string> vertexTwo = testGraph.AddNode("vertexTwo");
            Vertex<string> vertexThree = testGraph.AddNode("vertexThree");
            Vertex<string> vertexFour = testGraph.AddNode("vertexFour");
            Vertex<string> vertexFive = testGraph.AddNode("vertexFive");

            testGraph.AddEdge(vertexOne, vertexTwo, 25);
            testGraph.AddEdge(vertexTwo, vertexThree, 25);
            testGraph.AddEdge(vertexTwo, vertexOne, 25);

            testGraph.AddEdge(vertexFive, vertexFour, 25);
            testGraph.AddEdge(vertexFour, vertexFive, 25);

            string[] expectedOrder = new string[]
            {
                "vertexOne",
                "vertexTwo",
                "vertexThree"
            };

            //Act
            List<Vertex<string>> traversal = testGraph.DepthFirst();

            //Assert
            Assert.NotNull(traversal);
            Assert.Equal(3, traversal.Count);
            bool traversalOrderCorrect = true;
            int index = 0;
            foreach (Vertex<string> oneVertex in traversal)
            {
                if (oneVertex.Value != expectedOrder[index])
                {
                    traversalOrderCorrect = false;
                    break;
                }
                index++;
            }
            Assert.True(traversalOrderCorrect);
        }
    }
}