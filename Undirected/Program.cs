using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undirected
{
    class Graph{
        private int Vertex;
        private List<Int32>[] Adjacecny;

        public Graph(int v1)
        {
            Vertex = v1;
            Adjacecny = new List<Int32>[v1];

            for(int i = 0; i < v1; i++)
            {
                Adjacecny[i] = new List<Int32>();
            }
        }
        public void AddEdge(int v1, int w1)
        {
            Adjacecny[v1].Add(w1);
        }
        void BFS(int s1)
        {
            bool[] visited = new bool[Vertex];
            Queue<int> queue = new Queue<int>();
            visited[s1] = true;
            queue.Enqueue(s1);

            while(queue.Count != 0)
            {
                s1 = queue.Dequeue();
                Console.WriteLine("next ->" + s1);

                foreach(Int32 next in Adjacecny[s1])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
        }
        public void PrintAdjecentyMatrix()
        {
            for(int i=0;i< Vertex; i++)
            {
                Console.Write(i + ":[");
                string s1 = "";
                foreach(var k in Adjacecny[i])
                {
                    s1 = s1 + (k + ",");
                    s1 = s1.Substring(0, s1.Length - 1);
                    s1 = s1 + "]";
                    Console.Write(s1);
                    Console.WriteLine();
                }
            }
        }
        public static void Main()
        {
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            graph.PrintAdjecentyMatrix();

            Console.WriteLine("BFS");

            graph.BFS(1);
        }
    
    }

}