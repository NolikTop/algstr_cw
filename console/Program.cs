using System;
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

            for (int i = 0; i < n; ++i)
            {
                line = Console.ReadLine();
                if (line is null) return;

                var strings = line.Split(" ");
                var a = strings[0];
                var b = strings[1];
                var weight = int.Parse(strings[2]);

                var aVertex = new Vertex { Name = a };
                var bVertex = new Vertex { Name = b }; // todo 
                if (!graph.Vertices.Contains(aVertex))
                {
                    graph.Vertices.Add(aVertex);
                }
                if (!graph.Vertices.Contains(bVertex))
                {
                    graph.Vertices.Add(bVertex);
                }

                var edge = new Edge
                {
                    Vertex1 = aVertex,
                    Vertex2 = bVertex,
                    Weight = weight,
                };
                
                graph.Edges.Add(edge);
            }
            
            //todo
            
            Console.WriteLine("Hello World!");
        }
    }
}