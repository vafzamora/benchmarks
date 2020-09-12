using System;
using System.Linq;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RemoveSymbols
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        public string input = "91.247.498/0001-47";

        static Regex CompiledRegex = new Regex("[^0-9]", RegexOptions.Compiled);

        [Benchmark()]
        public void WithRegex()
        {
            var x = Regex.Replace(input, "[^0-9]", "");
        }

        [Benchmark]
        public void WithCompiledRegex()
        {
            var x = CompiledRegex.Replace(input, "");
        }

        [Benchmark(Baseline = true)]
        public void WithStringReplace()
        {
            var x = input.Replace("/", "").Replace(".", "").Replace("-", "");
        }

        [Benchmark]
        public void WithLINQ()
        {
            var x = new string(input.Where(c => c >= '0' && c <= '9').ToArray());
        }
        
        [Benchmark]
        public void WithSpanChar()
        {
            Span<char> outArray = stackalloc char[input.Length];
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]>='0' && input[i]<='9')
                {
                    outArray[j++] = input[i];
                }
            }
            string x = j > 0 ? outArray.Slice(0,j).ToString() : string.Empty; 
        }
    }
}