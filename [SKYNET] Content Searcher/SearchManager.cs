using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SKYNET
{
    public class SearchManager : IDisposable
    {
        public static SearchManager Instance;
        public static int ProcessedFiles { get; set; }

        public string DirectoryPath;
        public string Word;
        public static string FileExtention;

        public event EventHandler<FileDetails> OnFileFounded;
        public event EventHandler<int> OnProgressChanged;
        public event EventHandler<DateTime> OnSearchStarted;
        public event EventHandler<int> OnSearchCompleted;
        public event EventHandler<int> OnSearchCancelled;

        public List<string> Files;
        private bool stopSearch;

        private PathFinder Finder;

        public SearchManager()
        {
            Instance = this;
            Files = new List<string>();
            Finder = new PathFinder();
            Finder.Completed += SearchCompleted;
            ProcessedFiles = 0;
        }



        internal void Initialize(string Path, string word, string extention)
        {
            DirectoryPath = Path;
            Word = word;
            FileExtention = string.IsNullOrEmpty(extention) ? "" : extention;
        }

        public void Search()
        {
            OnSearchStarted?.Invoke(this, DateTime.Now);
            modCommon.ReleaseMemory();

            frmMain.Write("Searching");
            Task.Run(() =>
            {
                //Files.Clear();
                CacheDirectory cache = frmMain.cacheManager.Cache.Find(c => c.Path == DirectoryPath && c.Extention == FileExtention);
                if (cache != null)
                {
                    FindInCache(cache);
                }
                else
                {
                    Finder.Clear();
                    Finder.AddRange(Directory.GetDirectories(DirectoryPath));
                    Finder.Find();
                    return;
                }

            });
        }

        private void FindInCache(CacheDirectory cache)
        {
            Files = cache.Files;

            int totalFiles = Files.Count;
            int part = totalFiles / 4;
            int C_4 = totalFiles - (part * 3);
            int finished = 0;

            List<string> thread_1 = modCommon.GetPaginated(Files, 1, part);
            List<string> thread_2 = modCommon.GetPaginated(Files, 2, part);
            List<string> thread_3 = modCommon.GetPaginated(Files, 3, part);
            List<string> thread_4 = Files.GetRange((int)part * 3, C_4);

            string Th1_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th1_Name, () =>
            {
                for (int i = 0; i < thread_1.Count(); i++)
                {
                    ProcessFile(thread_1[i]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th1_Name);
            });

            string Th2_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th2_Name, () =>
            {
                for (int i = 0; i < thread_2.Count(); i++)
                {
                    ProcessFile(thread_2[i]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th2_Name);
            });

            string Th3_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th3_Name, () =>
            {
                for (int i = 0; i < thread_3.Count(); i++)
                {
                    ProcessFile(thread_3[i]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th3_Name);
            });

            string Th4_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th4_Name, () =>
            {
                for (int i = 0; i < thread_4.Count(); i++)
                {
                    ProcessFile(thread_4[i]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th4_Name);
            });
        }
        private void SearchCompleted(object sender, FindFilesResult result)
        {
            Files.AddRange(result.Files);
            string tName = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(tName, () =>
            {
                for (int i = 0; i < result.Files.Count(); i++)
                {
                    ProcessFile(result.Files[i]);
                }
                if (NotifyFinished(result.CurrentDirectory, result.Directories, Files.Count))
                {
                    frmMain.cacheManager.AddAndSave(DirectoryPath, Files);
                }
                ThreadManager.RemoveThread(tName);
            });
        }
        private bool NotifyFinished(int Current, int Count, int ProcessedFiles)
        {
            if (Current == Count)
            {
                OnSearchCompleted?.Invoke(this, ProcessedFiles);
                return true;
            }
            return false;
        }
        public static void ProcessFile(string filePath)
        {
            ProcessedFiles++;
            try
            {
                FileInfo info = new FileInfo(filePath);
                if (info.Length > 3700000)
                    return;

                if (File.ReadAllLines(filePath).Where(x => x.ToLower().Contains(Instance?.Word.ToLower())).Count() > 0)
                {
                    Instance?.NotifyFounded(info);
                }
            }
            catch { }
            Instance?.NotifyProgress();
        }
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern uint GetFileSize([In] string hFile, out uint lpFileSizeHigh);
        private void NotifyFounded(FileInfo info)
        {
            var task = Task.Factory.StartNew(() =>
            {
                string FileName = Path.GetFileName(info.FullName);
                long FileSize = info.Length;
                string FilePath = info.FullName;
                OnFileFounded?.Invoke(this, new FileDetails()
                {
                    FileName = FileName,
                    FilePath = FilePath,
                    FileSize = FileSize
                });
            });
        }

        private void NotifyProgress()
        {
            if (stopSearch)
            {
                OnSearchCancelled?.Invoke(this, ProcessedFiles);
                ThreadManager.StopThreads();
                return;
            }
            OnProgressChanged?.Invoke(this, ProcessedFiles);
        }

        public void Cancel()
        {
            stopSearch = true;
        }

        public void Dispose()
        {
            Instance = null;
            Files = null;
            Finder = null;
            ThreadManager.StopThreads();
        }
    }
    public class FileDetails
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
    }




}
