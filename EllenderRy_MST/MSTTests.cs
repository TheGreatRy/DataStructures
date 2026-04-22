using GraphLibrary;
using DijkstraLibrary;
using MSTLibrary;

namespace EllenderRy_MST
{
    public class MSTTests
    {
        MazeSolver MazeSolver = new MazeSolver();

        #region MST Validity Tests
        [Fact]
        public void MSTInitialTest()
        {
            string[] initialGraph = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3,F:7",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1,F:4",
                 "F,B:7,D:4,E:4"
            };

            string[] MST = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1",
                 "F,D:4"
            };

            Graph graph = new Graph(initialGraph);

            Graph expected = new Graph(MST);

            List<Edge> edges = graph.GraphToEdges();
            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void MSTInitialDifferentWeightsTest()
        {
            string[] initialGraph = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:4",
                 "B,A:4,C:7,D:1,F:3",
                 "C,B:7",
                 "D,B:1,E:8,F:2",
                 "E,D:8,F:2",
                 "F,B:3,D:2,E:2"
            };
            string[] MST = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:4",
                 "B,A:4,C:7,D:1",
                 "C,B:7",
                 "D,B:1,F:2",
                 "E,F:2",
                 "F,E:2"
            };

            Graph graph = new Graph(initialGraph);

            Graph expected = new Graph(MST);

            List<Edge> edges = graph.GraphToEdges();
            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MSTWithCycle()
        {
            string[] initialGraph = new string[4]
            {
                "A,B,C",
                "A,B:2,C:4",
                "B,A:2,C:3",
                "C,A:4,B:3"
            };
            string[] MST = new string[4]
            {
                "A,B,C",
                "A,B:2",
                "B,A:2,C:3",
                "C,B:3"
            };
            Graph graph = new Graph(initialGraph);

            Graph expected = new Graph(MST);

            List<Edge> edges = graph.GraphToEdges();
            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MSTInputIsMST()
        {
            string[] initialGraph = new string[7]
            {
                "A,B,C,D,E,F",
                "A,B:2",
                "B,A:2,C:3,D:4",
                "C,B:3",
                "D,B:4,E:6,F:1",
                "E,D:6",
                "F,D:1"
            };
            Graph graph = new Graph(initialGraph);

            List<Edge> edges = graph.GraphToEdges();
            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            Assert.Equal(graph, actual);
        }

        [Fact]
        public void MSTWithMultipleSolutions()
        {
            string[] initialGraph = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:3",
                 "B,A:3,C:2,D:3,F:4",
                 "C,B:2",
                 "D,B:3,E:4,F:2",
                 "E,D:4,F:3",
                 "F,B:4,D:2,E:3"
            };
            
            string[] MST = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:3",
                 "B,A:3,C:2,D:3",
                 "C,B:2",
                 "D,B:3,F:2",
                 "E,F:3",
                 "F,D:2,E:3"
            };

            Graph graph = new Graph(initialGraph);

            Graph expected = new Graph(MST);

            List<Edge> edges = graph.GraphToEdges();
            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MSTWithNoSolution()
        {
            string[] initialGraph = new string[3]
            {
                "A,B,C",
                "A,B:1",
                "B,A:1"
            };

            Graph graph = new Graph(initialGraph);

            List<Edge> edges = graph.GraphToEdges();
            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            Assert.Null(actual);
        }
        #endregion

        #region MST WeightTests
        [Fact]
        public void MSTInitialFullWeightTest()
        {
            string[] initialGraph = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3,F:7",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1,F:4",
                 "F,B:7,D:4,E:4"
            };

            Graph graph = new Graph(initialGraph);

            List<Edge> edges = graph.GraphToEdges();

            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            int actualWeight = actual.GetTotalWeights();

            Assert.Equal(14, actualWeight);
        }

        [Fact]
        public void MSTInitialPartialWeightTest()
        {
            string[] initialGraph = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3,F:7",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1,F:4",
                 "F,B:7,D:4,E:4"
            };

            Graph graph = new Graph(initialGraph);
            List<Edge> edges = graph.GraphToEdges();

            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            string start = "A";
            string end = "E";
            string[]? actualResult = MazeSolver.SolveMaze(actual, start, end);

            int actualWeight = actual.GetTotalWeights(actualResult);

            Assert.Equal(6, actualWeight);

        }

        [Fact]
        public void MSTInputIsMSTPartialWeightTest()
        {
            string[] initialGraph = new string[7]
            {
                "A,B,C,D,E,F",
                "A,B:2",
                "B,A:2,C:3,D:4",
                "C,B:3",
                "D,B:4,E:6,F:1",
                "E,D:6",
                "F,D:1"
            };

            Graph graph = new Graph(initialGraph);
            List<Edge> edges = graph.GraphToEdges();

            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            string start = "A";
            string end = "E";
            string[]? actualResult = MazeSolver.SolveMaze(actual, start, end);

            int actualWeight = actual.GetTotalWeights(actualResult);

            Assert.Equal(12, actualWeight);

        }
        [Fact]
        public void MSTInputIsMSTFullWeightTest()
        {
            string[] initialGraph = new string[7]
            {
                "A,B,C,D,E,F",
                "A,B:2",
                "B,A:2,C:3,D:4",
                "C,B:3",
                "D,B:4,E:6,F:1",
                "E,D:6",
                "F,D:1"
            };

            Graph graph = new Graph(initialGraph);

            List<Edge> edges = graph.GraphToEdges();

            Graph actual = MinSpanTree.KurskalsAlgo(edges);

            int actualWeight = actual.GetTotalWeights();

            Assert.Equal(16, actualWeight);

        }
        #endregion
    }
}