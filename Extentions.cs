using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitExcel
{
    internal static class Extentions
    {
        internal static List<List<T>> SplitList<T>(List<T> source, bool UseMultithreading)
        {
            int sourseCount = source.Count;
            int threadsNumber = (UseMultithreading) ? GetThreadsNumber() : 1;
            int listLen = sourseCount / threadsNumber;
            int rem = sourseCount % threadsNumber;
            if (rem > 0) listLen++;
            return SplitList(source, listLen);
        }
        private static List<List<T>> SplitList<T>(List<T> source, int len)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / len)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        private static int GetThreadsNumber()
        {
            try {
                int processorCount = Environment.ProcessorCount;
                if (processorCount > 1 && processorCount < 4) return 2;
                else if (processorCount >= 4) return 4;
                else return 1;
            }
            catch { return 1; }
        }
    }
}
