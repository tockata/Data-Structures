namespace PlayWithTrees
{
    using System.Collections.Generic;

    public class Tree<T>
    {
        public Tree(T value, params Tree<T>[] childrens)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in childrens)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public IList<Tree<T>> Children { get; set; }

        public Tree<T> Parent { get; set; }

        public T Value { get; set; }
    }
}