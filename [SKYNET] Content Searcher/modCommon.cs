using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public class modCommon
    {
        public static bool Hackerprod = Environment.UserName == "Administrador" ? true : false;

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr ILCreateFromPathW(string pszPath);

        [DllImport("shell32.dll")]
        private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, int cild, IntPtr apidl, int dwFlags);
        [DllImport("shell32.dll")]
        private static extern void ILFree(IntPtr pidl);
        public static void OpenFolderAndSelectFile(string filePath)
        {
            if (filePath == null)
                return;

            IntPtr pidl = ILCreateFromPathW(filePath);
            SHOpenFolderAndSelectItems(pidl, 0, IntPtr.Zero, 0);
            ILFree(pidl);
        }
        public static void ReleaseMemory()
        {
            try
            {
                SetProcessWorkingSetSize(GetCurrentProcess(), -1, -1);
            }
            catch (Exception exception1)
            {
                object obj1 = exception1;
                Exception exception = (Exception)obj1;
            }
        }

        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr GetCurrentProcess();


        public static void Show(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

        public static void InvokeAction(Control control, Action action)
        {
            try { control.Invoke(action); }
            catch { }
        }
        public static void EnsureDirectoryExists(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                filePath = filePath.Trim().Replace("\0", string.Empty);
                if (!string.IsNullOrEmpty(filePath))
                {
                    try
                    {
                        string text = filePath;
                        if (Path.IsPathRooted(filePath))
                        {
                            text = text.Trim();
                            if (!Directory.Exists(text))
                            {
                                try
                                {
                                    Directory.CreateDirectory(text);
                                }
                                catch { }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                    }
                }
            }
        }
        public static string GetPath()
        {
            Process currentProcess;
            try
            {
                currentProcess = Process.GetCurrentProcess();
                return new FileInfo(currentProcess.MainModule.FileName).Directory?.FullName;
            }
            finally { currentProcess = null; }
        }

        public static List<string> GetPaginated(List<string> list, int startPage, int PageSize)
        {
            if (list.Count == 0)
            {
                return new List<string>();
            }

            if (startPage == 1 || startPage == 0)
            {
                startPage = 0;
                return list.GetRange(startPage, Math.Min(PageSize, list.Count));
            }
            int num = (int)((startPage - 1) * PageSize);
            int count = (int)PageSize;
            if (num + PageSize > list.Count)
            {
                count = list.Count - num;
            }
            return list.GetRange(num, count);
        }

    }
}