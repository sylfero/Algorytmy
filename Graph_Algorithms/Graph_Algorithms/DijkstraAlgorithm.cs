using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
    static class DijkstraAlgorithm
    {
        public static int[] Dijkstra(this int[,] graph, int start = 0)
        {
            if (graph.GetLength(0) != graph.GetLength(1)) throw new Exception("Incorrect graph size");

            int[] distance = Enumerable.Repeat(int.MaxValue, graph.GetLength(0)).ToArray();
            bool[] isSet = Enumerable.Repeat(false, graph.GetLength(0)).ToArray();

            distance[start] = 0;

            for (int i = 0; i < graph.GetLength(0) - 1; i++)
            {
                int min = int.MaxValue;
                int min_index = 0;

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (distance[j] < min && isSet[j] == false)
                    {
                        min = distance[j];
                        min_index = j;
                    }
                }

                isSet[min_index] = true;

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (!isSet[j] && Convert.ToBoolean(graph[min_index, j]) && distance[min_index] != int.MaxValue && distance[min_index] + graph[min_index, j] < distance[j])
                    {
                        distance[j] = distance[min_index] + graph[min_index, j];
                    }
                }
            }
            return distance;
        }
    }
}
