using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithms
{
    class BFSAlgorithm<T>
    {
        private List<Edge> Edges = new List<Edge>();

        public void Add(T value, params int[] connections)
        {
            Edges.Add(new Edge(value, connections));
        }
        
        public List<T> BFS(int startId, T value)
        {
            bool[] visited = new bool[Edges.Count];
            Queue<int> queue = new Queue<int>();
            List<T> path = new List<T>();

            queue.Enqueue(startId);
            visited[startId] = true;

            while(queue.Count != 0)
            {
                int id = queue.Dequeue();
                Edge edge = Edges[id];
                path.Add(Edges[id].Value);

                if (edge.Value.Equals(value))
                    return path;

                foreach (int i in edge.Connections)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
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
