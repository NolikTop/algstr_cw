using System.Linq;
using src.dynamicArray;

namespace src.graph
{
    public class Graph
    {

        public DynamicArray<Vertex> Vertices = new();
        public DynamicArray<Edge> Edges = new();

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
            
            return string.Join("\n", simpleEdgesStrings) + "\n" + Edges.Sum(edge => edge.Weight);
        }
    }
}