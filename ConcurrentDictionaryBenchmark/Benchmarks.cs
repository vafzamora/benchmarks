using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace ConcurrentDictionaryBenchmark{
    public class Benchmarks{

        [Benchmark]
        public void ConcurrentDictionary()=>ConcurrentDict.Run();

        [Benchmark(Baseline=true)]
        public void GenericDictionary()=>GenericDict.Run(); 

    } 

}