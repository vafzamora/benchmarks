using System;
using System.Collections.Generic;
using System.IO;

namespace SplitString
{
    public class Split
    {
        public static void Run(){
            var reader = File.OpenText("municipios.csv");
            var line = reader.ReadLine();
            List<string> list = new List<string>(100);
            while (!string.IsNullOrEmpty(line))
            {
                var parsed = line.Split(';');
                if (parsed[4]=="3501")
                {
                    list.Add(parsed[0]); 
                }
                line = reader.ReadLine();
            }
            reader.Dispose(); 
        }
    }
}