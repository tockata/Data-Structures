namespace DirectoryContentTree
{
    using System;
    using System.IO;
    using System.Linq;

    public class DirectoryTreeConsoleApp
    {
        private static string rootDirectory = "C:\\WINDOWS";

        public static void Main(string[] args)
        {
            Folder folderTree = TraverseDirectoriesAndFiles(rootDirectory);
            // Print folder tree for other smaller than "C:\\WINDOWS" folder
            //PrintFolderTree(folderTree, 0);
            Console.WriteLine("Total size of folder '{0}' = {1}", rootDirectory, CalculateFolderFilesSize(folderTree));
        }

        private static long CalculateFolderFilesSize(Folder folder)
        {
            long size = 0;
            foreach (var file in folder.Files)
            {
                size += file.Size;
            }

            foreach (var childFolder in folder.ChildFolders)
            {
                size += CalculateFolderFilesSize(childFolder);
            }

            return size;
        }

        private static void PrintFolderTree(Folder folder, int indent)
        {
            Console.WriteLine("{0}Folder: {1}", new string('-', indent), folder.Name);
            if (!folder.ChildFolders.Any())
            {
                Console.WriteLine("{0}No subfolders.", new string('-', indent + 1));
            }
            else
            {
                foreach (var childFolder in folder.ChildFolders)
                {
                    PrintFolderTree(childFolder, indent + 1);
                }
            }

            if (!folder.Files.Any())
            {
                Console.WriteLine("{0}No files.", new string('-', indent + 1));
            }
            else
            {
                foreach (var file in folder.Files)
                {
                    Console.WriteLine("{0}{1}, size: {2}", new string('-', indent + 1), file.Name, file.Size);
                }
            }
        }

        private static Folder TraverseDirectoriesAndFiles(string parentDirectory)
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(parentDirectory);
            DirectoryInfo[] rootDirectoryChildFolders = new DirectoryInfo[0];
            FileInfo[] rootDirectoryFiles = new FileInfo[0];

            try
            {
                rootDirectoryChildFolders = rootDirectory.GetDirectories();
            }
            catch (Exception ex)
            {
            }

            try
            {
                rootDirectoryFiles = rootDirectory.GetFiles();
            }
            catch (Exception ex)
            {
            }

            Folder rootFolder = new Folder
                (
                    rootDirectory.FullName,
                    new File[rootDirectoryFiles.Length],
                    new Folder[rootDirectoryChildFolders.Length]
                );

            for (int i = 0; i < rootDirectoryFiles.Length; i++)
            {
                rootFolder.Files[i] = new File(rootDirectoryFiles[i].Name, rootDirectoryFiles[i].Length);
            }

            for (int i = 0; i < rootDirectoryChildFolders.Length; i++)
            {
                rootFolder.ChildFolders[i] = TraverseDirectoriesAndFiles(rootDirectoryChildFolders[i].FullName);
            }

            return rootFolder;
        }
    }
}