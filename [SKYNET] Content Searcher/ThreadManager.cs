using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace SKYNET
{
    public class ThreadManager
    {
        public static List<Thread> ActiveThreads { get; set; }

        public static void RunThread(string name, Action startThread)
        {
            Thread start = new Thread(new ThreadStart(startThread));
            start.IsBackground = true;
            start.Name = name;
            start.Start();
            ActiveThreads.Add(start);
        }
        public static void StopThreads()
        {
            for (int i = 0; i < ActiveThreads.Count; i++)
            {
                Thread thread = ActiveThreads[i];
                try
                {
                    if (thread != null)
                    {
                        thread.Abort();
                    }
                }
                catch { }
            }
            ActiveThreads.Clear();
            GC.Collect();
        }
        static ThreadManager()
        {
            ActiveThreads = new List<Thread>();
        }
        public static string GenerateName()
        {
            string str1 = "";
            try
            {
                //Random Marcado por mi
                string str2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                short num1 = checked((short)str2.Length);
                Random random = new Random();
                StringBuilder stringBuilder = new StringBuilder();
                int num2 = 1;
                do
                {
                    int startIndex = random.Next(0, (int)num1);
                    stringBuilder.Append(str2.Substring(startIndex, 1));
                    checked { ++num2; }
                }
                while (num2 <= 6);
                stringBuilder.Append(DateAndTime.Now.ToString("HHmmss"));
                str1 = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
            }
            return str1;
        }
        internal static void RemoveThread(string Name, bool StartsWith = false)
        {
            if (StartsWith)
            {
                var Threads = ActiveThreads.FindAll(t => t.Name.StartsWith(Name));
                if (Threads != null)
                {
                    foreach (var thread in Threads)
                    {
                        thread.Abort();
                        ActiveThreads.RemoveAll(t => t.Name == thread.Name);
                        GC.Collect();
                    }
                }
            }
            else
            {
                Thread tt = ActiveThreads.Find(t => t.Name == Name);
                if (tt != null)
                {
                    tt.Abort();
                    ActiveThreads.RemoveAll(t => t.Name == Name);
                    GC.Collect();
                }
            }
        }
    }
}