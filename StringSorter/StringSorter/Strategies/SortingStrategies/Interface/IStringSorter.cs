using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.Repositories.Interface
{
    public interface IStringSorter
    {
        //Interface defines my contract for sorting a string
        //BubbleSort and QuickSort will be its concrete implementations, each providing a different strategy
        string SortString(string str);
    }
}
