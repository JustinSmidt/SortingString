using StringSorter.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.Repositories
{
    public class BubbleSort : IStringSorter
    {
        public string SortString(string str)
        {
            char[] chars = str.ToCharArray();

            for(int a = 0; a < chars.Length; a++)
            {
                for(int b = 0; b < chars.Length - 1; b++)
                {
                    if (chars[b] > chars[b + 1])
                    {
                        char temp = chars[b];
                        chars[b] = chars[b + 1];
                        chars[b+ 1] = temp;
                    }
                }
            }

            return new string(chars);
        }
    }
}
