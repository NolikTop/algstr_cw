#nullable enable
using src.tree;

namespace src.graph
{
    public record Vertex
    {
        public string Name;
        public TreeElement? TreeElement;

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