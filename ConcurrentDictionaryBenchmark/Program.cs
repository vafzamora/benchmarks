using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace ConcurrentDictionaryBenchmark
{
    class Program
    {
        static ConcurrentDictionary<int,string>  dict = new ConcurrentDictionary<int, string>(); 
        static void Main(string[] args)
        {
            //ConcurrentDict.Run(); 
            //GenericDict.Run();
            BenchmarkRunner.Run<Benchmarks>(); 
        }
    }
}
