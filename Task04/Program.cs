﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естесственно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk04();
        }

        public static void RunTesk04()
        {
            List<int> values = new List<int> { 3, 1, 0, 5 };
            int index =
                values
                    .Select((n, i) => new { Value = n, Index = i })
                    .Aggregate((a, b) => a.Value < b.Value ? a : b)
                    .Index;
            Console.WriteLine(index);
            int[] arr = default;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = (Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Select(int.Parse).ToArray();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ArgumentOutOfRangeException");
            }



            // использовать синтаксис методов! SQL-подобные запросы не писать!

            int arrAggregate = arr.Aggregate(5, (cur, nex) => cur + nex);
            Console.WriteLine(arrAggregate);


            int arrMyAggregate = MyClass.MyAggregate(arr);

            Console.WriteLine(arrAggregate);
            Console.WriteLine(arrMyAggregate);

        }
    }

    static class MyClass
    {
        public static int MyAggregate()
        {

        }
    }
}
