#nullable enable
using src.disjointSet;

namespace src.graph
{
    public record Vertex
    {
        public string Name;
        public DisjointSetElement? TreeElement;
        public bool Used;

        public Vertex(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}