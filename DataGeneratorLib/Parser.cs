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
        //{

        //public static List<string> ReadPatronymics(string path)
        //    using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
        //    {
        //        return s.ReadToEnd()
        //            .Replace('\r', ' ')
        //            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Select(str => str.Trim())
        //            .ToList();
        //    }
        //}

        //public static List<string> ReadFirstNames(string path)
        //{
        //    using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
        //    {
        //        return s.ReadToEnd()
        //            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Select(str => str.Trim())
        //            .ToList();
        //    }
        //}

        //public static List<string> ReadSurnames(string path)
        //{
        //    using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
        //    {
        //        return s.ReadToEnd()
        //            .Replace('\r', ' ')
        //            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Select(str => str.Trim())
        //            .ToList();
        //    }
        //}

        //public static List<string> ReadCarBrands(string path)
        //{
        //    using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
        //    {
        //        return s.ReadToEnd()
        //            .Replace('\r', ' ')
        //            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Select(str => str.Trim())
        //            .ToList();
        //    }
        //}

        //public static List<string> ReadCarModels(string path)
        //{
        //    List<string> carModels = new List<string>();
        //    for (var i = 0; i < 10; i++)
        //        carModels.Add($"Model{i}");
        //    return carModels;
        //}

        //public static List<string> ReadTransmissions(string path)
        //{
        //    return new List<string> { "Автомат", "Вариатор", "Механическая" };
        //}

        //public static List<string> ReadTaskNames(string path)
        //{
        //    using (StreamReader s = new StreamReader(path, Encoding.GetEncoding(1251)))
        //    {
        //        return s.ReadToEnd()
        //            .Replace('\r', ' ')
        //            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Select(str => str.Trim())
        //            .ToList();
        //    }
        //}
    }
}