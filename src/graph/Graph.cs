using System.Collections.Generic;
using System.Linq;
using src.dynamicArray;

namespace src.graph
{
    public class Graph
    {

        public DynamicArray<Vertex> Vertices = new();
        public DynamicArray<Edge> Edges = new();

        public Graph(){}

        public Graph(DynamicArray<(string v1, string v2, int w)> edges)
        {
            foreach (var (v1, v2, w) in edges)
            {
                var aVertex = new Vertex(v1);
                var bVertex = new Vertex(v2);

                aVertex = Vertices.GetOrAdd(aVertex);
                bVertex = Vertices.GetOrAdd(bVertex);

                var e = new Edge
                {
                    Vertex1 = aVertex,
                    Vertex2 = bVertex,
                    Weight = w
                };

                Edges.Add(e);
            }
        }

        public void SetNotUsedVertices()
        {
            foreach (var vertex in Vertices)
            {
                vertex.Used = false;
            }
        }

        public Graph(IEnumerable<(string v1, string v2, int w)> edges) : this(new DynamicArray<(string v1, string v2, int w)>(edges)){}
        
        public override string ToString()
        {
            var result = string.Empty;

            result += "Vertices: " + string.Join(", ", Vertices) + "\n";
            result += "Edges: " + string.Join(", ", Edges);

            return result;
        }

        public string ToStringOnlyEdges()
        {
            var simpleEdgesStrings = new DynamicArray<string>();

            foreach (var edge in Edges)
            {
                simpleEdgesStrings.Add(edge.Vertex1.Name + " " + edge.Vertex2.Name);
            }
            
            BubbleSort.Sort(
                simpleEdgesStrings,
                new LexicographicOrderComparer()
            );

            return string.Join("\n", simpleEdgesStrings) + "\n" + Edges.Sum(edge => edge.Weight);
        }
    }
}