using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter02
{
    class Program
    {

        private static List<string> ToSentenceCase(List<string> source)
        {
            var left = source;
            var right = Enumerable.Range(1, source.Count);
            return Enumerable.Zip(left, right, (s, i) => $"{i}.{s}").ToList();
        }

        private static double CalcBMI(double weight, double height)
            => weight / height;

        private static string BMILevel(double bmi)
        {
            if (bmi < 18.5) return "体重不足";
            if (bmi >= 25) return "超重";

            return "健康";
        }

        private static void RunBMI()
        {
            Console.WriteLine("you weight andh Height: ");
            var weight = Double.Parse(Console.ReadLine());
            Console.WriteLine("you Height: ");
            var height = Double.Parse(Console.ReadLine());
            var bmi = CalcBMI(weight, height);
            var level = BMILevel(bmi);
            Console.WriteLine(level);
        }

        static void Main(string[] args)
        {
            
        }
    }
}
