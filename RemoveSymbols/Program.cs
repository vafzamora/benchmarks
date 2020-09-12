using System;
using BenchmarkDotNet.Running;

namespace RemoveSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
            //new Benchmarks().WithSpanChar();
        }
    }
}
