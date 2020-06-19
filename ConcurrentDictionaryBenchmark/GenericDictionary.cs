using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrentDictionaryBenchmark
{
    class GenericDict
    {
        static object dictLock = new Object();
        static Dictionary<int, string> dict = new Dictionary<int, string>();
        internal static void Run()
        {
            Task[] tasks = new Task[4];
            tasks[0] = Task.Run(() => AddItems(10000, 20000));
            tasks[1] = Task.Run(() => AddItems(30000, 20000));
            tasks[2] = Task.Run(() => AddItems(50000,20000)); 
            tasks[3] = Task.Run(() => AddItems(70000,20000)); 


            Task.WaitAll(tasks);
        }
        static void AddItems(int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                lock (dictLock)
                {
                    dict.TryAdd(i, i.ToString());
                }
            }
        }
    }
}