using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
    static class FloydAlgorithm
    {
        public static double[,] Floyd(this double[,] graph)
        {
            if (graph.GetLength(0) != graph.GetLength(1)) throw new Exception("Incorrect graph size");

            double[,] distance = (double[,]) graph.Clone();


            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    for (int k = 0; k < graph.GetLength(0); k++)
                    {
                        if (distance[j, i] + distance[i, k] < distance[j, k])
                            distance[j, k] = distance[j, i] + distance[i, k];
                    }
                }
            }

            return distance;
        }
    }
}
