#nullable enable
using System.Linq;
using src.dynamicArray;

namespace src.tree
{
    public class TreeElement
    {
        public int Rank = 0;
        public TreeElement? Parent;

        public TreeElement(TreeElement? parent = null)
        {
            Parent = parent;
        }

        public TreeElement Representative
        {
            get
            {
                TreeElement el;
                for (el = this; el.Parent is not null; el = el.Parent)
                {
                }

                return el;
            }
        }

        public void Union(TreeElement tree)
        {
            var leftRepresentative  = Representative;
            var rightRepresentative = tree.Representative;
            
            switch (leftRepresentative.Rank.CompareTo(rightRepresentative.Rank))
            {
                case > 0: 
                    tree.Parent = this;
                    break;
                case < 0: 
                    Parent = tree;
                    break;
                case 0:
                    tree.Rank++;
                    Parent = tree;
                    break;
            }
        }
    }
}