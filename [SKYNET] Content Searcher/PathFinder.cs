using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SKYNET
{
    public class PathFinder
    {
        public List<string> Directories;
        public List<string> Files;
        public event EventHandler<FindFilesResult> Completed;
        public int PathsCount
        {
            get
            {
                return Directories.Count;
            }
        }
        public PathFinder()
        {
            Directories = new List<string>();
            Files = new List<string>();
        }
        public void Add(string _Path)
        {
            Directories.Add(_Path);
        }
        public void AddRange(string[] directories)
        {
            Directories.AddRange(directories);
        }
        public void Clear()
        {
            Directories.Clear();
        }

        internal void Find()
        {
            Files.Clear();
            for (int i = 0; i < Directories.Count; i++)
            {
                string path = Directories[i];
                int Current = i + 1;

                var task = Task.Run(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    List<string> files = new List<string>();
                    try
                    {
                        files = Directory.GetFiles(path, "*." + SearchManager.FileExtention, SearchOption.AllDirectories).ToList();
                        Files.AddRange(files);
                        Completed?.Invoke(this, new FindFilesResult(Current, Directories.Count, files));
                    }
                    catch (Exception)
                    {
                        Completed?.Invoke(this, new FindFilesResult(Current, Directories.Count, files));
                    }
                });
            }
        }


    }

    public class FindFilesResult 
    {
        public int CurrentDirectory;
        public int Directories;
        public List<string> Files;

        public FindFilesResult(int i, int count, List<string> files)
        {
            this.CurrentDirectory = i;
            this.Directories = count;
            this.Files = files;
        }
    }
}