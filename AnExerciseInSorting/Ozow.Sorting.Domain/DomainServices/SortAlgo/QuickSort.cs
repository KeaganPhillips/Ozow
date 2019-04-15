using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozow.Sorting.Domain.DomainServices.SortAlgo
{
    public class QuickSort : ISortAlgo
    {
        public string Sort(string input)
        {             
            //var arr = input.ToArray();
            //_quickSortAlgo(arr, 0, input.Length -1);
            return _quicksort(input.ToArray().ToList())
                .Aggregate<char, StringBuilder>(new StringBuilder(64), (sb,c) => sb.Append(c))
                .ToString();
        }

        /// <summary>
        /// Quick sort algo taken from: https://gist.github.com/lbsong/6833729
        /// </summary>        
        private static void _quickSortAlgo(char[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            char num = arr[start];

            int i = start, j = end;

            while (i < j)
            {
                while (i < j && arr[j] > num)
                {
                    j--;
                }

                arr[i] = arr[j];

                while (i < j && arr[i] < num)
                {
                    i++;
                }

                arr[j] = arr[i];
            }

            arr[i] = num;
            _quickSortAlgo(arr, start, i - 1);
            _quickSortAlgo(arr, i + 1, end);
        }

        public static List<T> _quicksort<T>(List<T> elements) where T: IComparable {
            if (elements.Count() < 2) 
                return elements;
                
            var pivot = new Random().Next(elements.Count());
            var val = elements[pivot];
            var lesser = new List<T>();
            var greater = new List<T>();
            for (int i = 0; i < elements.Count(); i++) {
                if (i != pivot) {
                    if (elements[i].CompareTo(val) < 0) {
                        lesser.Add(elements[i]);
                    }
                    else {
                        greater.Add(elements[i]);
                    }
                }
            }

            var merged = _quicksort(lesser);
            merged.Add(val);
            merged.AddRange(_quicksort(greater));
            return merged;
        }
    }
}