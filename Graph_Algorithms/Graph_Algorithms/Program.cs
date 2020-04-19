using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
    class Program
    {
		static void Main(string[] args)
        {
			//dijkstra
			int[,] graph =
			{
				{0,2,2,6,3,0,0,0 },
				{2,0,2,0,0,1,1,0 },
				{2,2,0,0,2,1,0,0 },
				{6,0,0,0,0,2,0,3 },
				{3,0,2,0,0,0,4,5 },
				{0,1,1,2,0,0,2,2 },
				{0,1,0,0,4,2,0,2 },
				{0,0,0,3,5,2,2,0 }
			};
			int[] distance = graph.Dijkstra();
			for (int i = 0; i < distance.Length; i++)
			{
				Console.WriteLine($"{i} {distance[i]}");
			}
			Console.WriteLine(new string('-', 10));
			//floyd
			double INF = double.PositiveInfinity;
			double[,] graph2 =
			{
				{0,6,8,INF,-4 },
				{INF,0,INF,1,7 },
				{INF,4,0,INF,INF },
				{2,INF,-5,0,INF },
				{INF,INF,INF,3,0 }
			};
			double[,] distance2 = graph2.Floyd();
			for (int i = 0; i < distance2.GetLength(0); i++)
			{
				for (int j = 0; j < distance2.GetLength(0); j++)
				{
					Console.Write(distance2[i, j].ToString().PadLeft(4));
				}
				Console.WriteLine();
			}
			Console.WriteLine(new string('-', 10));
			//bfs
			BFSAlgorithm<char> bfs = new BFSAlgorithm<char>();
			bfs.Add('a', 1, 2);
			bfs.Add('b', 2);
			bfs.Add('c', 0, 3);
			bfs.Add('d', 3);
			List<char> path = bfs.BFS(0, 'd');
			if (path != null)
			{
				foreach (char i in path)
				{
					Console.Write(i + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine(new string('-', 10));
			//dfs
			DFSAlgorithm<char> dfs = new DFSAlgorithm<char>();
			dfs.Add('a', 1, 2);
			dfs.Add('b', 2);
			dfs.Add('c', 0, 3);
			dfs.Add('d', 3);
			List<char> path2 = dfs.DFS(0, 'd');
			if (path2 != null)
			{
				foreach (char i in path2)
				{
					Console.Write(i + " ");
				}
			}
			Console.ReadKey();
		}
    }
}
