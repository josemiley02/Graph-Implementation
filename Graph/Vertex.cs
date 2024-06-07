namespace GraphImplementation
{
    public class Vertex<T>
    {
        public Vertex(T value)
        {
            Value = value;
            AdjVertexs = [];
        }
        public T? Value { get; set; }
        public List<Vertex<T>> AdjVertexs { get; set; }
        public int Degree => AdjVertexs.Count;
    }
}