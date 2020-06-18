using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpfBenchmark
{
    [MemoryDiagnoser]
    public class Benchmarks
    {

        private const string testCpf = "532.817.478-09";

        public Benchmarks()
        {

        }

        [Benchmark(Baseline=true)]
        public void Baseline_() => Baseline.IsCpf(testCpf);

        
        [Benchmark]
        public void SemPadLeft_() => SemPadLeft.IsCpf(testCpf);


        [Benchmark]
        public void SemIntArray_() => SemIntArray.IsCpf(testCpf);
        
        [Benchmark]
        public void SemReplace_() => SemReplace.IsCpf(testCpf);

        [Benchmark]
        public void Final_() => Final.IsCpf(testCpf);
        
    }
}
