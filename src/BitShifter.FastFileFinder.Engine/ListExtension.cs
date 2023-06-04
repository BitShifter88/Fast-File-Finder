using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitShifter.FastFileFinder.Engine
{
    public static class ListExtension
    {
        public static List<int> AllIndexesOf(this string str, string value, StringComparison compare)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, compare);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
