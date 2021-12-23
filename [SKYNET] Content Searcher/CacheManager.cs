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
        public void AddAndSave(string _Path, List<string> _Files)
        {
            var item = new CacheDirectory()
            {
                Path = _Path,
                Files = _Files
            };

            if (Cache.Find(c => c.Path == _Path) != null)
            {
                return;
            }

            Cache.Add(item);

            try
            {
                List<string> Content = new List<string>();
                Content.Add(item.Path);
                Content.AddRange(item.Files);
                File.WriteAllLines(Path.Combine(ChacheDirectory, Path.GetRandomFileName()), Content.ToArray());
            }
            catch (Exception ex)
            {
                modCommon.Show(ex);
            }
        }
        public void Load()
        {
            modCommon.EnsureDirectoryExists(ChacheDirectory);
            foreach (var item in Directory.GetFiles(ChacheDirectory))
            {
                List<string> Content = File.ReadAllLines(item).ToList();
                if (Content.Any() && Directory.Exists(Content[0]))
                {
                    string Path = Content[0];
                    Content.RemoveAt(0);
                    List<string> Files = Content;
                    Cache.Add(new CacheDirectory()
                    {
                        Path = Path,
                        Files = Files
                    });
                }
                else
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
                    Content.Add(item.Path);
                    Content.AddRange(item.Files);
                    File.WriteAllLines(Path.Combine(ChacheDirectory, Path.GetRandomFileName()), Content.ToArray());
                }
                catch (Exception ex)
                {
                    modCommon.Show(ex);
                }
            }
        }

        public void Clear()
        {
            Cache.Clear();
            foreach (var item in Directory.GetFiles(ChacheDirectory))
            {
                File.Delete(item);
            }
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

