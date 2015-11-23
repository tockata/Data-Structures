namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayWithTrees
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        private static List<List<Tree<int>>> pathsWithGivenSum = new List<List<Tree<int>>>();
        private static Stack<Tree<int>> tempPath = new Stack<Tree<int>>();

        public static void Main()
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
            Console.WriteLine(string.Format("Root node: {0}", rootNode.Value));

            var leafNodes = FindLeafNodes();
            Console.WriteLine("Leaf nodes: {0}", string.Join(" ", leafNodes.Select(n => n.Value)));

            var middleNodes = FindMiddleNodes();
            Console.WriteLine("Middle nodes: {0}", string.Join(" ", middleNodes.Select(n => n.Value)));

            var longestPath = FindTheLongestPath(rootNode);
            Console.WriteLine(
                "Longest path: {0} (length = {1})",
                string.Join(" -> ", longestPath.Select(n => n.Value)),
                longestPath.Count);

            FindAllPaths(rootNode, pathSum);
            Console.WriteLine("Paths of sum {0}:", pathSum);
            foreach (var path in pathsWithGivenSum)
            {
                Console.WriteLine(string.Join(" -> ", path.Select(n => n.Value)));
            }
        }

        private static void FindAllPaths(Tree<int> node, int sum)
        {
            tempPath.Push(node);
            foreach (var child in node.Children)
            {
                FindAllPaths(child, sum);
            }

            int tempPathSum = tempPath.Sum(n => n.Value);
            if (tempPathSum == sum)
            {
                var foundPath = tempPath.ToList();
                foundPath.Reverse();
                pathsWithGivenSum.Add(foundPath);
            }

            tempPath.Pop();
        }

        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(n => !n.Children.Any() && n.Parent != null)
                .OrderBy(n => n.Value)
                .ToList();

            return leafNodes;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(n => n.Children.Any() && n.Parent != null)
                .OrderBy(n => n.Value)
                .ToList();

            return middleNodes;
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(n => n.Parent == null);
            return rootNode;
        }

        private static List<Tree<int>> FindTheLongestPath(Tree<int> rootNode)
        {
            List<Tree<int>> path = new List<Tree<int>>();

            foreach (var child in rootNode.Children)
            {
                List<Tree<int>> tempPath = FindTheLongestPath(child);
                if (tempPath.Count > path.Count)
                {
                    path = tempPath;
                }
            }

            path.Insert(0, rootNode);

            return path;
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