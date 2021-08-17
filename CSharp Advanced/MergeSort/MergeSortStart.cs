using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class MergeSortStart
    {
        static void Main()
        {

            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var sorted = new Mergesort();

            Console.WriteLine(string.Join(" ", sorted.Sort(arr)));
        }
    }

    public class Mergesort
    {
        public List<int> Sort(List<int> arr)
        {
            if (arr.Count <= 1)
            {
                return arr;
            }

            var left = new List<int>();
            var right = new List<int>();

            left.Capacity = arr.Count / 2;
            right.Capacity = arr.Count - left.Capacity;

            for (int i = 0; i < arr.Count; i++)
            {
                if (i < arr.Count / 2)
                {
                    left.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();
            result.Capacity = left.Count + right.Count;

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count || rightIndex < right.Count)
            {
                if (leftIndex < left.Count && rightIndex == right.Count)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                    continue;
                }
                else if (rightIndex < right.Count && leftIndex == left.Count)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                    continue;
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) == -1 || left[leftIndex].CompareTo(right[rightIndex]) == 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                    continue;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
        }
    }
}
