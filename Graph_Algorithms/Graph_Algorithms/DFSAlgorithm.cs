using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
    class DFSAlgorithm<T>
    {
        private List<Edge> Edges = new List<Edge>();

        public void Add(T value, params int[] connections)
        {
            Edges.Add(new Edge(value, connections));
        }

        public List<T> DFS(int startId, T value)
        {
            bool[] visited = new bool[Edges.Count];
            Stack<int> stack = new Stack<int>();
            List<T> path = new List<T>();

            stack.Push(startId);
            visited[startId] = true;

            while (stack.Count != 0)
            {
                int id = stack.Pop();
                Edge edge = Edges[id];
                path.Add(Edges[id].Value);

                if (edge.Value.Equals(value))
                    return path;

                foreach (int i in edge.Connections)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
            return null;
        }


        private class Edge
        {
            public T Value { get; }
            public int[] Connections { get; }

            public Edge(T value, int[] connections)
            {
                Value = value;
                Connections = connections;
            }
        }
    }
}
