﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter01
{
    public static class Program
    {
        static List<int> QuickSort(this List<int> list)
        {
            if (list.Count == 0) return new List<int>();

            var pivot = list[0];
            var rest = list.Skip(1);

            var small = from item in rest where item <= pivot select item;
            var large = from item in rest where pivot < item select item;

            return small.ToList()
                        .QuickSort()
                        .Append(pivot)
                        .Concat(large.ToList().QuickSort())
                        .ToList();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
