using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListBenchmark
{
    class Program
    {
        static int keyCount = 200;
        static int itemsCount = 50000;
        static int sample = (itemsCount/keyCount);
        static List<string> subject = new List<string>();
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
            Console.WriteLine($"List<string>,{sw1.ElapsedMilliseconds},{sw2.ElapsedMilliseconds}");
            Console.ReadKey();
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
