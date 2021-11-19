using System;
using System.Collections.Generic;
using System.Linq;
using src.graph;
using src.tree;

namespace src
{
    public static class KruskalAlgorithm
    {

        public static Graph GetMinimumSpanningTree(Graph graph)
        {
            var result = new Graph();
            graph.Vertices.CopyTo(result.Vertices, 0);
            var map = new Dictionary<Vertex, TreeElement>(); // todo remove
            foreach (var vertex in graph.Vertices)
            {
                map[vertex] = new TreeElement();
            }

            foreach (var edge in graph.Edges.OrderBy(edge => edge.Weight))
            {
                var tr1 = map[edge.Vertex1];
                var tr2 = map[edge.Vertex2];

                if (tr1.Representative != tr2.Representative) // в разных компонентах связности 
                {
                    result.Edges.Add(edge);
                    tr1.Union(tr2);
                }
            }

            return result;
        }

    }
}