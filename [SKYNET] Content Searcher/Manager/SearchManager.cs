using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static int ProcessedFiles;
        public static string FileExtention;

        public string DirectoryPath;
        public string Word;
        public List<string> Files;

        public event EventHandler<FileInfo> OnFileFounded;
        public event EventHandler<int> OnProgressChanged;
        public event EventHandler<DateTime> OnSearchStarted;
        public event EventHandler<int> OnSearchCompleted;
        public event EventHandler<int> OnSearchCancelled;

        private bool stopSearch;

        public SearchManager()
        {
            Files = new List<string>();
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

            try
            {
                string validExtention = FileExtention.StartsWith("*.") ? FileExtention.Replace("*.", "") : FileExtention;
                validExtention = FileExtention.StartsWith(".") ? FileExtention.Replace(".", "") : FileExtention;
                validExtention = FileExtention == "" ? "*" : FileExtention;
                
                //modCommon.Show("Starting test");
                //Stopwatch sw = new Stopwatch();
                //sw.Start();
                //sw.Stop();
                //modCommon.Show("Founded in " + sw.ElapsedMilliseconds.ToString("N0") + " ms.");

                CacheDirectory cache = frmMain.CacheManager.Cache.Find(c => c.Path == DirectoryPath && c.Extention == validExtention);

                if (cache != null)
                {

                    frmMain.Write($"Searching in {cache.Files.Count()} files loaded from cache");
                    FindInCache2(cache);
                    UpdateCache(cache);
                }
                else
                {
                    frmMain.Write($"Creating file list from \"{DirectoryPath}\"");

                    var fileNames = from dir in Directory.EnumerateFiles(DirectoryPath, $"*.{validExtention}", SearchOption.AllDirectories) select dir;

                    frmMain.Write($"Searching in {fileNames.Count()} files");

                    cache = new CacheDirectory()
                    {
                        Extention = FileExtention,
                        Path = DirectoryPath,
                        Files = fileNames.ToList()
                    };

                    FindInCache(cache);

                    frmMain.CacheManager.Add(cache);
                }
            }
            catch (Exception ex)
            {
                modCommon.Show(ex);
            }
        }
        private void FindInCache2(CacheDirectory cache)
        {
            Files = cache.Files;
            int totalFiles = Files.Count;
            int part = totalFiles / 4;
            int C_4 = totalFiles - part * 3;
            int finished = 0;
            List<string> thread_1 = SKYNET.modCommon.GetPaginated(Files, 1, part);
            List<string> thread_2 = SKYNET.modCommon.GetPaginated(Files, 2, part);
            List<string> thread_3 = SKYNET.modCommon.GetPaginated(Files, 3, part);
            List<string> thread_4 = Files.GetRange(part * 3, C_4);
            string Th1_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th1_Name, delegate
            {
                for (int l = 0; l < thread_1.Count(); l++)
                {
                    ProcessFile(thread_1[l]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th1_Name);
            });
            string Th2_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th2_Name, delegate
            {
                for (int k = 0; k < thread_2.Count(); k++)
                {
                    ProcessFile(thread_2[k]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th2_Name);
            });
            string Th3_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th3_Name, delegate
            {
                for (int j = 0; j < thread_3.Count(); j++)
                {
                    ProcessFile(thread_3[j]);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th3_Name);
            });
            string Th4_Name = "Search_" + Path.GetRandomFileName();
            ThreadManager.RunThread(Th4_Name, delegate
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

        private void UpdateCache(CacheDirectory cache)
        {
            Task.Run(() =>
            {
                var fileNames = from dir in Directory.EnumerateFiles(DirectoryPath, FileExtention, SearchOption.AllDirectories) select dir;
                cache.Files = fileNames.ToList();
                frmMain.CacheManager.Update(cache);
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

            string Th1_Name = Path.GetRandomFileName();
            ThreadManager.RunThread(Th1_Name, () =>
            {
                foreach (var item in thread_1)
                {
                    ProcessFile(item);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th1_Name);
            });


            string Th2_Name = Path.GetRandomFileName();
            ThreadManager.RunThread(Th2_Name, () =>
            {
                foreach (var item in thread_2)
                {
                    ProcessFile(item);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th2_Name);
            });

            string Th3_Name = Path.GetRandomFileName();
            ThreadManager.RunThread(Th3_Name, () =>
            {
                foreach (var item in thread_3)
                {
                    ProcessFile(item);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th3_Name);
            });

            string Th4_Name = Path.GetRandomFileName();
            ThreadManager.RunThread(Th4_Name, () =>
            {
                foreach (var item in thread_4)
                {
                    ProcessFile(item);
                }
                finished++;
                NotifyFinished(finished, 4, ProcessedFiles);
                ThreadManager.RemoveThread(Th4_Name);
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
        public void ProcessFile(string filePath)
        {
            ProcessedFiles++;
            try
            {
                FileInfo info = new FileInfo(filePath);
                if (info.Length > 3700000) //3.7mb
                    return;

                StreamReader reader = new StreamReader(filePath);
                for (string text = reader.ReadLine(); text != null; text = reader.ReadLine())
                {
                    if (text.ToLower().Contains(Word.ToLower()))
                    {
                        NotifyFounded(info);
                        break;
                    }
                }
            }
            catch { }
            NotifyProgress();
        }
        private void NotifyFounded(FileInfo info)
        {
            OnFileFounded?.Invoke(this, info);
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
            Files = null;
            ThreadManager.StopThreads();
        }
    }

}
