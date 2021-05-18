using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using P08.Graphs.Common;

namespace P08.Graphs.Models
{
    public class Graph
    {
        private const string BASE_FILES_PATH = "../../../Files/";
        private const string BASE_INPUT_FILES_PATH = BASE_FILES_PATH + "Input/";
        private const string BASE_OUTPUT_FILES_PATH = BASE_FILES_PATH + "Output/";
        private const string BASE_FILES_EXTENSION = ".txt";

        private const string INPUT_FILE_LIST_OF_EDGES = BASE_INPUT_FILES_PATH + Constants.LIST_OF_EDGES + BASE_FILES_EXTENSION;
        private const string INPUT_FILE_ADJACENCY_MATRIX = BASE_INPUT_FILES_PATH + Constants.ADJACENCY_MATRIX + BASE_FILES_EXTENSION;
        private const string INPUT_FILE_INCIDENCE_MATRIX = BASE_INPUT_FILES_PATH + Constants.INCIDENCE_MATRIX + BASE_FILES_EXTENSION;

        private const string OUTPUT_FILE_LIST_OF_EDGES = BASE_OUTPUT_FILES_PATH + Constants.LIST_OF_EDGES + BASE_FILES_EXTENSION;
        private const string OUTPUT_FILE_ADJACENCY_MATRIX = BASE_OUTPUT_FILES_PATH + Constants.ADJACENCY_MATRIX + BASE_FILES_EXTENSION;
        private const string OUTPUT_FILE_INCIDENCE_MATRIX = BASE_OUTPUT_FILES_PATH + Constants.INCIDENCE_MATRIX + BASE_FILES_EXTENSION;

        private int[,] graphMatrix;

        public Graph(int countOfNodes)
        {
            this.CountOfNodes = countOfNodes;
            this.graphMatrix = new int[this.CountOfNodes, this.CountOfNodes];
        }

        private int CountOfNodes { get; set; }

        public void InitializeMatrix(string typeMatrix)
        {
            switch (typeMatrix)
            {
                case Constants.LIST_OF_EDGES:
                    int[,] listOfEdges = this.InitializeListOfEdges();

                    this.graphMatrix = this.ConvertFromListOfEdgesToAdjacencyMatrix(listOfEdges, this.CountOfNodes);
                    break;
                case Constants.ADJACENCY_MATRIX:
                    this.graphMatrix = this.InitializeAdjacencyMatrix(this.CountOfNodes);
                    break;
                case Constants.INCIDENCE_MATRIX:
                    int[,] incidenceMatrix = this.InitializeIncidenceMatrix(this.CountOfNodes);

                    this.graphMatrix = this.ConvertFromIncidenceToAdjacencyMatrix(incidenceMatrix, this.CountOfNodes);
                    break;
            }
        }

        public void SaveInFileMatrixAsIncidence()
        {
            int[,] incidenceMatrix = this.ConvertFromAdjacencyMatrixToIncidence(this.graphMatrix, this.CountOfNodes);

            string text = GetMatrixAsString(incidenceMatrix);

            this.WriteToFile(OUTPUT_FILE_INCIDENCE_MATRIX, text);
        }

        public void SaveInFileMatrixAsAdjacency()
        {
            string text = this.GetMatrixAsString(this.graphMatrix);

            this.WriteToFile(OUTPUT_FILE_ADJACENCY_MATRIX, text);
        }

        public void SaveInFileListOfEdges()
        {
            int[,] listOfEdges = this.ConvertFromAdjacencyMatrixToListOfEdges(this.graphMatrix);

            string text = this.GetMatrixAsString(listOfEdges);

            this.WriteToFile(OUTPUT_FILE_LIST_OF_EDGES, text);
        }

        private int[,] ConvertFromAdjacencyMatrixToIncidence(int[,] adjacencyMatrix, int countOfNodes)
        {
            int[,] incidenceMatrix = new int[countOfNodes, GetCountOfEdges(adjacencyMatrix)];

            int counterOfCurrentEdge = 0;
            for (int row = 0; row < adjacencyMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < adjacencyMatrix.GetLength(1); col++)
                {
                    if (row < col && adjacencyMatrix[row, col] == 1)
                    {
                        incidenceMatrix[row, counterOfCurrentEdge] = 1;
                        incidenceMatrix[col, counterOfCurrentEdge] = 1;

                        counterOfCurrentEdge++;
                    }
                }
            }

            return incidenceMatrix;
        }

        private int[,] ConvertFromAdjacencyMatrixToListOfEdges(int[,] adjacencyMatrix)
        {
            int[,] listOfEdges = new int[GetCountOfEdges(adjacencyMatrix), 2];

            int counterOfCurrentEdge = 0;
            for (int row = 0; row < adjacencyMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < adjacencyMatrix.GetLength(1); col++)
                {
                    if (row < col && adjacencyMatrix[row, col] == 1)
                    {
                        listOfEdges[counterOfCurrentEdge, 0] = row + 1;
                        listOfEdges[counterOfCurrentEdge, 1] = col + 1;

                        counterOfCurrentEdge++;
                    }
                }
            }

            return listOfEdges;
        }

        private int[,] ConvertFromIncidenceToAdjacencyMatrix(int[,] incidenceMatrix, int countOfNodes)
        {
            int[,] adjacencyMatrix = new int[countOfNodes, countOfNodes];

            for (int col = 0; col < incidenceMatrix.GetLength(1); col++)
            {
                List<int> nodes = new List<int>(2);

                for (int row = 0; row < incidenceMatrix.GetLength(0); row++)
                {
                    if (incidenceMatrix[row, col] == 1)
                    {
                        nodes.Add(row);
                    }
                }

                adjacencyMatrix[nodes[0], nodes[1]] = 1;
                adjacencyMatrix[nodes[1], nodes[0]] = 1;
            }

            return adjacencyMatrix;
        }

        private int[,] ConvertFromListOfEdgesToAdjacencyMatrix(int[,] listOfEdges, int countOfNodes)
        {
            int[,] adjacencyMatrix = new int[countOfNodes, countOfNodes];

            for (int row = 0; row < listOfEdges.GetLength(0); row++)
            {
                int firstNodeAsMatrixIndex = listOfEdges[row, 0] - 1;
                int secondNodeAsMatrixIndex = listOfEdges[row, 1] - 1;

                adjacencyMatrix[firstNodeAsMatrixIndex, secondNodeAsMatrixIndex] = 1;
                adjacencyMatrix[secondNodeAsMatrixIndex, firstNodeAsMatrixIndex] = 1;
            }

            return adjacencyMatrix;
        }

        private string GetMatrixAsString(int[,] matrix)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    stringBuilder.Append(matrix[row, col] + " ");
                }

                stringBuilder.AppendLine();
            }

            string matrixAsText = stringBuilder.ToString().Trim();

            return matrixAsText;
        }

        private void WriteToFile(string path, string text)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(text);
            }
        }

        private int GetCountOfEdges(int[,] adjacencyMatrix)
        {
            int countOfEdges = 0;

            for (int row = 0; row < adjacencyMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < adjacencyMatrix.GetLength(1); col++)
                {
                    if (row > col && adjacencyMatrix[row, col] == 1)
                    {
                        countOfEdges++;
                    }
                }
            }

            return countOfEdges;
        }

        private int[,] InitializeListOfEdges()
        {
            int countOfLines = File.ReadAllLines(INPUT_FILE_LIST_OF_EDGES).Length;

            int[,] listOfEdges = new int[countOfLines, 2];

            using (StreamReader streamReader = File.OpenText(INPUT_FILE_LIST_OF_EDGES))
            {
                string line = string.Empty;
                int row = 0;

                while ((line = streamReader.ReadLine()) != null)
                {
                    int[] connection = line.Split(' ')
                        .Select(int.Parse)
                        .ToArray();

                    listOfEdges[row, 0] = connection[0];
                    listOfEdges[row, 1] = connection[1];

                    row++;
                }
            }

            return listOfEdges;
        }

        private int[,] InitializeAdjacencyMatrix(int countOfNodes)
        {
            int[,] adjacencyMatrix = new int[countOfNodes, countOfNodes];

            using (StreamReader streamReader = File.OpenText(INPUT_FILE_ADJACENCY_MATRIX))
            {
                string line = string.Empty;
                int row = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    int[] rowFromFile = line.Split()
                        .Select(int.Parse)
                        .ToArray();

                    for (int col = 0; col < rowFromFile.Length; col++)
                    {
                        int typeConnection = rowFromFile[col];

                        adjacencyMatrix[row, col] = typeConnection;
                    }

                    row++;
                }
            }

            return adjacencyMatrix;
        }

        private int[,] InitializeIncidenceMatrix(int countOfNodes)
        {
            int countOfLines = File.ReadAllLines(INPUT_FILE_INCIDENCE_MATRIX)[0].Length / 2 + 1;

            int[,] incidenceMatrix = new int[countOfNodes, countOfLines];

            using (StreamReader streamReader = File.OpenText(INPUT_FILE_INCIDENCE_MATRIX))
            {
                string line = string.Empty;
                int row = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    int[] rowFromFile = line.Split()
                        .Select(int.Parse)
                        .ToArray();

                    for (int col = 0; col < rowFromFile.Length; col++)
                    {
                        int connection = rowFromFile[col];

                        incidenceMatrix[row, col] = connection;
                    }

                    row++;
                }
            }

            return incidenceMatrix;
        }
    }
}
