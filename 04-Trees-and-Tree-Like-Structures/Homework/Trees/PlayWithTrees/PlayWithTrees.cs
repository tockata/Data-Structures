namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayWithTrees
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        public static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            var rootNode = FindRootNode();
            var leafNodes = FindLeafNodes();
            var middleNodes = FindMiddleNodes();
        }

        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(n => !n.Children.Any() && n.Parent != null)
                .ToList();

            return leafNodes;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(n => n.Children.Any() && n.Parent != null)
                .ToList();

            return middleNodes;
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(n => n.Parent == null);
            return rootNode;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }
    }
}