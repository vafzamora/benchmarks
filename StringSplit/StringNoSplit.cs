using System;
using System.Collections.Generic;
using System.IO;

namespace SplitString
{
    public static class StringNoSplit
    {
        public static void Run(){
            var reader = File.OpenText("municipios.csv");
            var line = reader.ReadLine();
            String search = ";3501;"; 
            List<string> list = new List<string>(100);
            while (!string.IsNullOrEmpty(line))
            {
                if (line.Contains(search,StringComparison.Ordinal))
                {
                    int pos = line.IndexOf(';');
                    list.Add(line.Substring(0,pos));
                }
                line = reader.ReadLine();
            }
            reader.Dispose(); 
        }
    }
}