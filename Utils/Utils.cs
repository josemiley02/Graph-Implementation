using GraphImplementation;

namespace Engine
{
    public static class Utils
    {
        public static void CreateGraph<T>(Graph<T> graph, params(int,int)[] edges)
        {
            foreach (var item in edges)
            {
                graph.AddAdjancency(item.Item1, item.Item2);
            }
        }
    }
}