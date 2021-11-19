namespace src.graph
{
    public class Edge
    {
        public Vertex Vertex1; // можно было бы сделать From и To, но граф не ориентированный
        public Vertex Vertex2; // поэтому так 
        public int Weight; 
    }
}