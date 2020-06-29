using System;
using System.Collections.Generic;
using System.IO;

namespace SplitString
{
    public static class Span
    {
        public static void Run(){
            var reader = File.OpenText("municipios.csv");
            var line = reader.ReadLine();
            ReadOnlySpan<char> search = ";3501;".AsSpan(); 
            List<string> list = new List<string>(100);
            while (!string.IsNullOrEmpty(line))
            {
                ReadOnlySpan<char> chars = line.AsSpan();

                if (chars.Contains(search,StringComparison.Ordinal))
                {
                    int pos = line.IndexOf(';');
                    list.Add(chars.Slice(0,pos).ToString());
                }
                line = reader.ReadLine();
            }
            reader.Dispose(); 
        }
     }
}