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
    }
}