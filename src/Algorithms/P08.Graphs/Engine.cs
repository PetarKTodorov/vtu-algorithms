namespace P08.Graphs
{
    using System;

    using P08.Graphs.Common;
    using P08.Graphs.Models;

    public class Engine
    {
        public void Run()
        {
            Console.WriteLine("Tests is with M = 9" + Environment.NewLine);
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());

            var graph = new Graph(m);

            // InitializeMatrix takes as argument one of these
            // Constants.INCIDENCE_MATRIX
            // Constants.ADJACENCY_MATRIX
            // Constants.LIST_OF_EDGES
            graph.InitializeMatrix(Constants.INCIDENCE_MATRIX);

            graph.SaveInFileMatrixAsAdjacency();
            graph.SaveInFileListOfEdges();
            graph.SaveInFileMatrixAsIncidence();
        }
    }
}
