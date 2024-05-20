namespace GraphImplementation
{
    public class Graph<T>
    {
        public Graph()
        {
            vertexs = new List<Vertex<T>>();
        }
        private List<Vertex<T>> vertexs { get; set; }
        public int Count => vertexs.Count;

        public void AddVertex(params T[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                vertexs.Add(new Vertex<T>(values[i], i));
            }
        }
        public void AddAdjacency(T value1, T value2)
        {
            Vertex<T> vertex1 = null!; 
            Vertex<T> vertex2 = null!; 
            foreach (var item in vertexs)
            {
                if(item.Value!.Equals(value1)) vertex1 = item;
                else if(item.Value.Equals(value2)) vertex2 = item;
            }
            if(vertex1 != null && vertex2 != null)
            {
                vertex1.Adj.Add(vertex2);
                vertex2.Adj.Add(vertex1);
            }
            throw new ArgumentException();
        }
        private class Vertex<K>
        {
            public Vertex(K value, int id)
            {
                Value = value;
                Id = id;
                Adj = new List<Vertex<K>>();
            }
            public K Value { get; set; }
            public int Id { get; private set; }
            public List<Vertex<K>> Adj { get;}
        }
    }
}