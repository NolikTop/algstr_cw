using System;
using System.Collections.Generic;
using System.Linq;
using src.disjointSet;
using src.dynamicArray;
using src.graph;

namespace src
{
    public static class KruskalAlgorithm
    {

        private static void BubbleSort<T>(DynamicArray<T> arr, IComparer<T> comparer)
        {
            var n = arr.Count;
            
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (comparer.Compare(arr[j], arr[j+1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }
        
        public static Graph GetMinimumSpanningTree(Graph graph)
        {
            var result = new Graph
            {
                Vertices = (DynamicArray<Vertex>)graph.Vertices.Clone()
            };

            foreach (var vertex in result.Vertices)
            {
                vertex.TreeElement = new DisjointSetElement(vertex);
            }

            var edges = (DynamicArray<Edge>)graph.Edges.Clone();
            BubbleSort(edges, new EdgesComparer());
            
            foreach (var edge in edges)
            {
                var tr1 = edge.Vertex1.TreeElement;
                var tr2 = edge.Vertex2.TreeElement;

                if (tr1 is null)
                {
                    throw new NullReferenceException("Вершина " + edge.Vertex1 + " не имеет ссылки на TreeElement");
                }
                if (tr2 is null)
                {
                    throw new NullReferenceException("Вершина " + edge.Vertex2 + " не имеет ссылки на TreeElement");
                }

                // если представители их компонент связности равны, значит они в одной компоненте связности и добавлять ребро не надо (иначе будет цикл)
                if (tr1.Representative == tr2.Representative) continue;
                
                result.Edges.Add(edge);
                tr1.Union(tr2);
            }

            return result;
        }

    }
}