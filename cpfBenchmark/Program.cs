using BenchmarkDotNet.Running;
using System;

namespace cpfBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Benchmarks>();

            string testCpf = "532.817.478-09";
            for (int i = 0; i < 5000; i++)
            {
                Baseline.IsCpf(testCpf);
            }
        }
    }
}
