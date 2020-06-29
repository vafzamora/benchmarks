using System;
using BenchmarkDotNet.Attributes;

namespace SplitString
{
    [MemoryDiagnoser]
    public class Benchmarks
    {      
        [Benchmark(Baseline=true)]
        public void StringSplit()=>Split.Run();      
        
        [Benchmark]
        public void Span() => SplitString.Span.Run();  

        [Benchmark]
        public void StringNoSplit() => SplitString.StringNoSplit.Run();  
    }
}