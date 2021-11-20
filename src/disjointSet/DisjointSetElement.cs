#nullable enable
using System;
using src.graph;

namespace src.disjointSet
{
    public class DisjointSetElement
    {
        public int Rank = 0;
        public DisjointSetElement? Parent;
        public Vertex Vertex;

        public DisjointSetElement(Vertex vertex, DisjointSetElement? parent = null)
        {
            Parent = parent;
            Vertex = vertex;
        }

        public DisjointSetElement Representative
        {
            get
            {
                DisjointSetElement el;
                for (el = this; el.Parent is not null; el = el.Parent)
                {
                }

                return el;
            }
        }

        public void Union(DisjointSetElement disjointSet)
        {
            var leftRepresentative  = Representative;
            var rightRepresentative = disjointSet.Representative;
            
            switch (leftRepresentative.Rank.CompareTo(rightRepresentative.Rank))
            {
                case > 0: 
                    rightRepresentative.Parent = leftRepresentative;
                    break;
                case < 0: 
                    leftRepresentative.Parent = rightRepresentative;
                    break;
                case 0:
                    rightRepresentative.Rank++;
                    leftRepresentative.Parent = rightRepresentative;
                    break;
            }
        }
    }
}