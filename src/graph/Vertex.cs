using System;
using src.tree;

namespace src.graph
{
    public class Vertex : IEquatable<Vertex>
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

        public bool Equals(Vertex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Equals(TreeElement, other.TreeElement);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vertex)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TreeElement);
        }
    }
}