namespace DirectoryContentTree
{
    public class Folder
    {
        public Folder(string name, File[] files, Folder[] childFolders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public Folder[] ChildFolders { get; set; }

        public File[] Files { get; set; }

        public string Name { get; set; }
    }
}