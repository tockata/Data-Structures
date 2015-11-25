namespace _04_LongestPathInATree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPathInATree
    {
        private static Dictionary<int, List<int>> treeNodes = new Dictionary<int, List<int>>();
        private static Dictionary<int, int?> parents = new Dictionary<int, int?>();

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());
            ReadTree(edgesCount);

            var leafes = treeNodes.Where(n => n.Value.Count == 0).Select(n => n.Key).ToList();
            var rootNode = parents.First(n => n.Value == null).Key;
            var pathsToRoot = FindAllPathsToRoot(leafes, rootNode);
            int maxSumPath = FindMaxSumPath(pathsToRoot, rootNode);
            Console.WriteLine("\nMax sum path is: " + maxSumPath);
        }

        private static int FindMaxSumPath(List<List<int>> pathsToRoot, int rootNode)
        {
            int maxSumPath = int.MinValue;
            for (int i = 0; i < pathsToRoot.Count; i++)
            {
                for (int j = 0; j < pathsToRoot.Count; j++)
                {
                    if (i != j && pathsToRoot[i].Intersect(pathsToRoot[j]).Count() == 0)
                    {
                        int currentSum = pathsToRoot[i].Sum() + pathsToRoot[j].Sum() + rootNode;
                        if (currentSum > maxSumPath)
                        {
                            maxSumPath = currentSum;
                        }
                    }
                }
            }

            return maxSumPath;
        }

        private static List<List<int>> FindAllPathsToRoot(List<int> leafes, int rootNode)
        {
            var paths = new List<List<int>>();
            foreach (var leaf in leafes)
            {
                int currentNode = leaf;
                var currentLeafPath = new List<int>();
                while (currentNode != rootNode)
                {
                    currentLeafPath.Add(currentNode);
                    currentNode = (int)parents[currentNode];
                }

                paths.Add(currentLeafPath);
            }

            return paths;
        }

        private static void ReadTree(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                int[] nodes = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (!treeNodes.ContainsKey(nodes[0]))
                {
                    treeNodes[nodes[0]] = new List<int>();
                }

                if (!treeNodes.ContainsKey(nodes[1]))
                {
                    treeNodes[nodes[1]] = new List<int>();
                }

                treeNodes[nodes[0]].Add(nodes[1]);

                if (!parents.ContainsKey(nodes[0]))
                {
                    parents[nodes[0]] = null;
                }

                parents[nodes[1]] = nodes[0];
            }
        }
    }
}