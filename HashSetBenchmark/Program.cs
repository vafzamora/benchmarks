using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashSetBenchmark
{    class Program
    {
        static int keyCount = 200;
        static int itemsCount = 50000;
        static int sample = (itemsCount/keyCount);
        static HashSet<string> subject = new HashSet<string>();
        static string[] searchKeys = new string[keyCount];

        static void Main(string[] args)
        {
            CreateKeys();

            var sw1 = Stopwatch.StartNew();
            LoadData();
            sw1.Stop();

            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < keyCount; i++)
            {
                subject.Contains(searchKeys[i]);
            }
            sw2.Stop();

            Console.WriteLine($"HashSet<string>,{sw1.ElapsedMilliseconds},{sw2.ElapsedMilliseconds}");
        }

        private static void LoadData()
        {
            int i = 10000, end = i+itemsCount; 
 
            for (; i < end ; i++)
            {
                subject.Add(i.ToString());
            }
        }
        private static void CreateKeys()
        {
            int i = 10000, end = i+itemsCount,j=0; 
            
            for (; i < end; i+=sample)
            {
                searchKeys[j++] = i.ToString(); 
            }
        }

    }
}
