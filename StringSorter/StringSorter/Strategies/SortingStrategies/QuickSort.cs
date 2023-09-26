using StringSorter.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorter.Repositories
{
    public class QuickSort : IStringSorter
    {
        public string SortString(string str)
        {
            char[] chars = str.ToCharArray();
            SortCharArray(chars, 0, chars.Length - 1);
            return new string(chars);
        }


        //sorts the array of characters
        private void SortCharArray(char[] chars, int low, int high)
        {
            if(low < high)
            {
                int pivotIndex = PivotPlacement(chars, low, high);
                SortCharArray(chars, low, pivotIndex - 1);
                SortCharArray(chars, pivotIndex + 1, high);
            }
        }


        //responsible for placing the pivot element in its correct position in the sorted array and ensures that elements
        //less than pivot are on its left and elements greater than pivot are on its right
        private int PivotPlacement(char[] chars, int low, int high) 
        {
            char pivot = chars[high];
            int i = low;

            for(int j = low; j < high; j++)
            {
                if (chars[j] < pivot)
                {
                    //swap chars[i] and chars [j]
                    char temp = chars[i];
                    chars[i] = chars[j];
                    chars[j] = temp;
                    i++;
                }
            }

            chars[high] = chars[i];
            chars[i] = pivot;

            return i;
        }
    }
}
