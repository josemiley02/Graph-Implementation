using GraphImplementation;
using Engine;
namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Utils.CreateGraph(graph, (0, 1), (0, 3), (0, 7), (1, 2), (1, 3), (2, 4), (2, 5), (3, 6), (4, 8), (4, 9), (6, 7));

            int[] D = graph.BFS(7);
        }
    }
}