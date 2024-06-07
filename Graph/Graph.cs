using System.Runtime.CompilerServices;

namespace GraphImplementation
{
    public class Graph<T>
    {
        public Graph(params T[] values)
        {
            Vertexs = [];
            foreach (var item in values)
            {
                Vertexs.Add(new Vertex<T>(item));
            }
        }
        private List<Vertex<T>> Vertexs { get; set; }
        public void AddVertex(params T[] vertex)
        {
            foreach (var item in vertex)
            {
                Vertexs.Add(new Vertex<T>(item));
            }
        }
        public void RemoveVertex(params int[] vertexs)
        {
            foreach (var item in vertexs)
            {
                if (CheckValidationIndex(item))
                    Vertexs.RemoveAt(item);
            }
        }
        public void AddAdjancency(int v1, int v2)
        {
            if (CheckValidationIndex(v1, v2) && v1 != v2)
            {
                Vertex<T> u = Vertexs[v1];
                Vertex<T> v = Vertexs[v2];
                u.AdjVertexs.Add(v);
                v.AdjVertexs.Add(u);
                return;
            }
            throw new ArgumentException();
        }
        public IEnumerable<T> GetValues()
        {
            foreach (var item in Vertexs)
            {
                yield return item.Value!;
            }
        }
        public int[] BFS(int start)
        {
            if(!CheckValidationIndex(start)) throw new IndexOutOfRangeException();
            int[] Distances = new int[Vertexs.Count];
            for (int i = 0; i < Distances.Length; i++)
            {
                if(i == start) continue;
                Distances[i] = int.MaxValue;
            }
            BFS(start, ref Distances);
            return Distances;
        }
        private void BFS(int start, ref int[] Distances)
        {
            Queue<Vertex<T>> vertices = [];
            vertices.Enqueue(Vertexs[start]);
            int index = 0;
            while(vertices.Count > 0)
            {
                var u = vertices.Dequeue();
                foreach (var item in u.AdjVertexs)
                {
                    index = Vertexs.IndexOf(item);
                    if(Distances[index] == int.MaxValue)
                    {
                        Distances[index] = Distances[Vertexs.IndexOf(u)] + 1;
                        vertices.Enqueue(item);
                    }
                }
            }
        }
        private bool CheckValidationIndex(params int[] indexes)
        {
            foreach (var index in indexes)
            {
                if (index >= Vertexs.Count || index < 0) throw new IndexOutOfRangeException();
            }
            return true;
        }
    }
}