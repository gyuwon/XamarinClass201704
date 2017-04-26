using System;
using System.Collections.Generic;

namespace Delegates
{
    public delegate void IntAction(int value);

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IntAction action = Console.WriteLine;

            // 1. 집계자 개체 사용
            var aggregator = new Aggregator();
            action += aggregator.Add;

            ForEach(array, action);

            Console.WriteLine($"Sum: {aggregator.Sum}");

            // 2. delegate 사용
            ////int sum = 0;
            ////action += delegate (int n)
            ////{
            ////    sum += n;
            ////};

            ////ForEach(array, action);

            ////Console.WriteLine($"Sum: {sum}");

            // 3. Lambda 사용
            ////int sum = 0;

            ////// 3.1 장황한
            ////action += (int n) =>
            ////{
            ////    sum += n;
            ////};

            ////// 3.2 매개변수 형식 생략
            ////////action += (n) =>
            ////////{
            ////////    sum += n;
            ////////};

            ////// 3.3 하나의 매개변수에 대해 괄호 생략
            ////////action += n =>
            ////////{
            ////////    sum += n;
            ////////};

            ////// 3.4 하나의 구문에 대해 '{}' 생략
            ////////action += n => sum += n;

            ////ForEach(array, action);

            ////Console.WriteLine($"Sum: {sum}");
        }

        public static void ForEach(IEnumerable<int> values, IntAction action)
        {
            foreach (int value in values)
            {
                action.Invoke(value);
            }
        }

        class Aggregator
        {
            public int Sum { get; private set; } = 0;

            public void Add(int n) => Sum += n;
        }
    }
}
