using System;
using src;
using src.graph;

namespace algstr_cp
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new();

            int n;
            
            var line = Console.ReadLine();
            if (line is null) return;
            
            n = int.Parse(line);

            for (var i = 0; i < n; ++i)
            {
                line = Console.ReadLine();
                if (line is null) return;

                var strings = line.Split(" ");
                var a = strings[0];
                var b = strings[1];
                var weight = int.Parse(strings[2]);

                var aVertex = new Vertex(a);
                var bVertex = new Vertex(b);

                aVertex = graph.Vertices.GetOrAdd(aVertex);
                bVertex = graph.Vertices.GetOrAdd(bVertex);

                var edge = new Edge
                {
                    Vertex1 = aVertex,
                    Vertex2 = bVertex,
                    Weight = weight,
                };
                
                graph.Edges.Add(edge);
            }

            Console.WriteLine("Input graph: ");
            Console.WriteLine(graph.ToString());
            Console.WriteLine();
            
            Console.WriteLine("Minimum spanning tree: ");
            Console.WriteLine(KruskalAlgorithm.GetMinimumSpanningTree(graph));
        }
    }
}