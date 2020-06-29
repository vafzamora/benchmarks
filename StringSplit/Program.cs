using System;
using BenchmarkDotNet.Running;

namespace SplitString
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SplitString.Benchmarks>();
            //Split.Run();
            //Span.Run(); 
            //StringNoSplit.Run();
        }
    }
}
