using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    public class CacheManager
    {
        public string ChacheDirectory { get; set; }
        public List<CacheDirectory> Cache { get; set; }

        public CacheManager(string Directory)
        {
            ChacheDirectory = Directory;
            Cache = new List<CacheDirectory>();
        }
        public void Load()
        {
            modCommon.EnsureDirectoryExists(ChacheDirectory);
            foreach (var item in Directory.GetFiles(ChacheDirectory))
            {
                try
                {
                    List<string> Content = File.ReadAllLines(item).ToList();
                    if (Content.Any() && Directory.Exists(Content[0]))
                    {
                        string Path = Content[0];
                        string Ext = Content[1];
                        Content.RemoveAt(0);
                        Content.RemoveAt(1);
                        List<string> Files = Content;
                        Cache.Add(new CacheDirectory()
                        {
                            Path = Path,
                            Extention = Ext,
                            Files = Files
                        });
                    }
                    else
                    {
                        try { Directory.Delete(item); } catch { }
                    }
                }
                catch 
                {
                    try { Directory.Delete(item); } catch { }
                }
            }
        }
        public void Save()
        {
            foreach (var item in Directory.GetFiles(ChacheDirectory))
            {
                File.Delete(item);
            }

            foreach (var item in Cache)
            {
                try
                {
                    List<string> Content = new List<string>();
                    Content.Add($"{item.Path}");
                    Content.Add(item.Extention);
                    Content.AddRange(item.Files);
                    File.WriteAllLines(Path.Combine(ChacheDirectory, Path.GetRandomFileName()), Content.ToArray());
                }
                catch (Exception ex)
                {
                    modCommon.Show(ex);
                }
            }
        }

        internal void Update(CacheDirectory cache)
        {
            if (cache == null || cache.Files.Count() == 0)
            {
                return;
            }
            foreach (var item in Cache)
            {
                if (item.Path == cache.Path && item.Extention == cache.Extention)
                {
                    item.Files = cache.Files;
                }
            }
            Save();
        }

        public void Clear()
        {
            Cache.Clear();
            foreach (var item in Directory.GetFiles(ChacheDirectory))
            {
                File.Delete(item);
            }
        }

        public void Add(CacheDirectory cache)
        {
            if (cache == null || cache.Files.Count() == 0)
            {
                return;
            }
            var Exists = frmMain.CacheManager.Cache.Find(c => c.Path == cache.Path && c.Extention == cache.Extention);
            if (Exists == null)
            {
                Cache.Add(cache);
            }
            Save();
        }
    }
    public class CacheDirectory
    {
        public string Extention { get; set; }
        public string Path { get; set; }
        public List<string> Files { get; set; }
        public CacheDirectory()
        {
            Files = new List<string>();
        }
    }
}

