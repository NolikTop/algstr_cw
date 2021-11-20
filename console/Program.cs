using System;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using src;
using src.dynamicArray;
using src.graph;

namespace algstr_cw
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"/Users/noliktop/RiderProjects/algstr_cw/input.txt";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Укажите путь до файла с данными в коде");
            }
            
            var edges = new DynamicArray<(string, string, int)>();
            
            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) is not null)
                {
                    var strings = line.Split(" ");
                    var a = strings[0];
                    var b = strings[1];
                    var weight = int.Parse(strings[2]);

                    edges.Add((a,b,weight));
                }
            }
            
            Graph graph = new(edges);

            Console.WriteLine(KruskalAlgorithm.GetMinimumSpanningTree(graph).ToStringOnlyEdges());
        }
    }
}