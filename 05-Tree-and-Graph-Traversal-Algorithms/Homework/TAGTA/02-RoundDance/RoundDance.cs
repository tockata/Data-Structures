namespace _02_RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundDance
    {
        private static Dictionary<int, List<int>> nodesAndChilds = new Dictionary<int, List<int>>();
        private static Dictionary<int, bool> isVisited = new Dictionary<int, bool>();

        public static void Main()
        {
            int edgesCount = int.Parse(Console.ReadLine());
            int rootNode = int.Parse(Console.ReadLine());

            ReadInput(edgesCount);
            foreach (var key in nodesAndChilds.Keys)
            {
                isVisited[key] = false;
            }
            List<int> longestPath = FindLongestPath(rootNode);
            Console.WriteLine("Longest path count = {0}", longestPath.Count);
            Console.WriteLine("Longest path nodes = {0}", string.Join(" ", longestPath));
        }

        private static List<int> FindLongestPath(int rootNode)
        {
            List<int> longestPath = new List<int>();
            if (!isVisited[rootNode])
            {
                isVisited[rootNode] = true;
                foreach (var child in nodesAndChilds[rootNode])
                {
                    List<int> tempPath = FindLongestPath(child);
                    if (tempPath.Count > longestPath.Count)
                    {
                        longestPath = tempPath;
                    }
                }

                longestPath.Insert(0, rootNode);
            }

            return longestPath;
        }

        private static void ReadInput(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                int[] connectedNodes = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (!nodesAndChilds.ContainsKey(connectedNodes[0]))
                {
                    nodesAndChilds[connectedNodes[0]] = new List<int>();
                }

                if (!nodesAndChilds.ContainsKey(connectedNodes[1]))
                {
                    nodesAndChilds[connectedNodes[1]] = new List<int>();
                }

                nodesAndChilds[connectedNodes[0]].Add(connectedNodes[1]);
                nodesAndChilds[connectedNodes[1]].Add(connectedNodes[0]);
            }
        }
    }
}