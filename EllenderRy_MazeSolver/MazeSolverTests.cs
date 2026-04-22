using DijkstraLibrary;
using GraphLibrary;

namespace EllenderRy_MazeSolver
{
    public class MazeSolverTests
    {
        MazeSolver mazeSolver = new MazeSolver();
        [Fact]
        public void InitialTestMaze()
        {
            string[] maze = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:2",
                 "B,A:2,C:4,D:3,F:7",
                 "C,B:4",
                 "D,B:3,E:1,F:4",
                 "E,D:1,F:4",
                 "F,B:7,D:4,E:4"
            };

            string[] expectedResult = new string[4] { "A", "B", "D", "E" };
            Graph graph = new Graph(maze);
            string start = "A";
            string end = "E";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void InitialMazeShiftedWeights()
        {
            string[] maze = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:4",
                 "B,A:4,C:7,D:1,F:3",
                 "C,B:7",
                 "D,B:1,E:8,F:2",
                 "E,D:8,F:2",
                 "F,B:3,D:2,E:2"
            };

            string[] expectedResult = new string[4] { "A", "B", "F", "E" };
            Graph graph = new Graph(maze);
            string start = "A";
            string end = "E";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void MazeWithDeadEnds()
        {
            string[] maze = new string[10]
            {
                "A,B,Z,X,Y,K,R,C,P",
                "Z,X:7",
                "X,Z:7,A:4,R:3",
                "R,X:3,P:9",
                "P,R:9",
                "A,X:4,B:8",
                "B,A:8,Y:6",
                "Y,B:6,C:5",
                "C,Y:5,K:2",
                "K,C:2"
            };
            string[] expectedResult = new string[7] { "Z", "X", "A", "B", "Y", "C", "K" };
            Graph graph = new Graph(maze);
            string start = "Z";
            string end = "K";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void MazeWithSmallCycle()
        {
            string[] maze = new string[4]
            {
                "A,B,C",
                "A,B:2,C:4",
                "B,A:2,C:3",
                "C,A:4,B:3"
            };
            string[] expectedResult = new string[2] { "A", "C" };
            Graph graph = new Graph(maze);
            string start = "A";
            string end = "C";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void MazeWithLargeCycle()
        {
            string[] maze = new string[17]
            {
                "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,Z",
                "A,B:7",
                "B,A:7,C:5,I:3",
                "C,B:5,D:2",
                "D,C:2,E:8",
                "E,D:8,F:1,N:4",
                "F,E:1,G:9",
                "G,F:9,H:6",
                "H,G:6,Z:2",
                "I,B:3,J:5",
                "J,I:5,K:1,M:6",
                "K,J:1,L:8",
                "L,K:8,Z:9",
                "M,J:6,N:4,O:3",
                "O,M:3,N:2",
                "N,M:4,O:2",
                "Z,L:9,H:2"
            };
            string[] expectedResult = new string[7] { "A", "B", "I", "J", "K", "L", "Z" };
            Graph graph = new Graph(maze);
            string start = "A";
            string end = "Z";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void MazeWithNoCycles()
        {
            string[] maze = new string[7]
            {
                "A,B,C,D,E,F",
                "A,B:2",
                "B,A:2,C:3,D:4",
                "C,B:3",
                "D,B:4,E:6,F:1",
                "E,D:6",
                "F,D:1"
            };
            string[] expectedResult = new string[4] { "A", "B", "D", "E" };
            Graph graph = new Graph(maze);
            string start = "A";
            string end = "E";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MazeWithMultipleSolutions()
        {
            string[] maze = new string[7]
            {
                 "A,B,C,D,E,F",
                 "A,B:3",
                 "B,A:3,C:2,D:3,F:4",
                 "C,B:2",
                 "D,B:3,E:4,F:2",
                 "E,D:4,F:3",
                 "F,B:4,D:2,E:3"
            };

            string[] expectedResult = new string[4] { "A", "B", "D", "E" };
            //string[] validResult = new string[4] { "A", "B", "F", "E" };

            Graph graph = new Graph(maze);
            string start = "A";
            string end = "E";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void MazeWithNoSolution()
        {
            string[] maze = new string[3]
            {
                "A,B,C",
                "A,B:1",
                "B,A:1"
            };
            Graph graph = new Graph(maze);
            string start = "A";
            string end = "C";
            string[]? actualResult = mazeSolver.SolveMaze(graph, start, end);
            //validating an impossible solution (no results)
            Assert.Null(actualResult);
        }
    }
}