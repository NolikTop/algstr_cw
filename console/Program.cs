using System;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using src;
using src.graph;

namespace algstr_cp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"/Users/noliktop/RiderProjects/algstr_cp/input.txt";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Укажите путь до файла с данными в коде");
            }

            Graph graph = new();

            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) is not null)
                {
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
            }
            Console.WriteLine(KruskalAlgorithm.GetMinimumSpanningTree(graph).ToStringOnlyEdges());
        }
    }
}