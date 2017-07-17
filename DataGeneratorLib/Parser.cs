using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataGeneratorLib
{
    public static class Parser
    {
        public static List<string> ParseLines(string path)
        {
            using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                return s.ReadToEnd()
                    .Replace('\r', ' ')
                    .Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }

        public static List<string> ParseAllTextWithCommas(string path)
        {
            using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                return s.ReadToEnd()
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => str.Trim())
                    .ToList();
            }
        }
    }
}