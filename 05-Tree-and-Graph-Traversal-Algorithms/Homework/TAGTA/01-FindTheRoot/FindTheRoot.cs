namespace _01_FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTheRoot
    {
        private static List<int>[] graph;
        private static bool[] hasParent;
        private static int nodesCount;
        private static int edgesCount;

        public static void Main()
        {
            nodesCount = int.Parse(Console.ReadLine());
            edgesCount = int.Parse(Console.ReadLine());
            graph = new List<int>[edgesCount];
            hasParent = new bool[nodesCount];
            ReadGraph();
            FindNodesParents();

            var roots = hasParent.Select((node, index) => new { Node = node, Index = index })
                .Where(n => n.Node == false)
                .Select(n => n.Index)
                .ToList();
            if (roots.Count == 1)
            {
                Console.WriteLine("Root is: " + roots[0]);
            }
            else if (roots.Count > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }

        private static void ReadGraph()
        {
            for (int i = 0; i < edgesCount; i++)
            {
                graph[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }
        }

        private static void FindNodesParents()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                hasParent[graph[i][1]] = true;
            }
        }
    }
}