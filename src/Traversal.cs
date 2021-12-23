using System;
using src.dynamicArray;
using src.graph;
using src.queue;
using src.stack;

namespace src
{
    public static class Traversal
    {

        public static DynamicArray<Vertex> Bfs(Graph g)
        {
            if (g.Edges.IsEmpty)
            {
                throw new Exception("Graph has no edges");
            }

            var result = new DynamicArray<Vertex>();
            
            g.SetNotUsedVertices();
            
            var q = new Queue<Vertex>();
            
            var firstVertex = g.Vertices[0];
            firstVertex.Used = true;
            q.Enqueue(firstVertex);

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                result.Add(current);

                foreach(var edge in g.Edges)
                {
                    if (edge.Vertex1 == current && !edge.Vertex2.Used)
                    {
                        q.Enqueue(edge.Vertex2);
                        edge.Vertex2.Used = true;
                    }else if (edge.Vertex2 == current && !edge.Vertex1.Used)
                    {
                        q.Enqueue(edge.Vertex1);
                        edge.Vertex1.Used = true;
                    }
                }
            }

            return result; 
        }

        public static DynamicArray<Vertex> Dfs(Graph g)
        {
            if (g.Edges.IsEmpty)
            {
                throw new Exception("Graph has no edges");
            }
            
            var result = new DynamicArray<Vertex>();

            g.SetNotUsedVertices();

            var s = new Stack<Vertex>();
            var firstVertex = g.Vertices[0];
            s.Push(firstVertex);

            while (s.Count > 0)
            {
                var current = s.Pop();

                if (!current.Used)
                {
                    current.Used = true;
                    result.Add(current);
                }

                foreach (var edge in g.Edges)
                {
                    if (edge.Vertex1 == current && !edge.Vertex2.Used)
                    {
                        s.Push(edge.Vertex2);
                    }
                    else if (edge.Vertex2 == current && !edge.Vertex1.Used)
                    {
                        s.Push(edge.Vertex1);
                    }
                }
            }

            return result; 
        }
        
    }
}