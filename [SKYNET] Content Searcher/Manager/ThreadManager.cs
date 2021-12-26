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
            Thread start = new Thread(new ThreadStart(startThread))
            {
                Name = name,
                IsBackground = true
            };
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
        internal static void RemoveThread(string Name)
        {
            Thread tt = ActiveThreads.Find(t => t.Name == Name);
            if (tt != null)
            {
                tt.Join();
                ActiveThreads.RemoveAll(t => t.Name == Name);
                GC.Collect();
            }
        }
    }
}