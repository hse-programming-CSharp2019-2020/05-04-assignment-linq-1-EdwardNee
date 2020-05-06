using System;
using System.Linq;
using System.Runtime.InteropServices;


/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr = default;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }


            var filteredCollection = arr.TakeWhile(x => x != 0);


            try
            {
                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = Enumerable.Average(filteredCollection, x => x * x);
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = filteredCollection.Average(x => x * x);
                Console.WriteLine($"{averageUsingStaticForm:F3}\n{averageUsingInstanceForm:F3}");

                // вывести элементы коллекции в одну строку
                //filteredCollection.ToList().ForEach(x=>Console.Write($"{x} "));
                string s = filteredCollection.Select(x => x.ToString()).Aggregate((x, y) => x + " " + y).ToString();
                Console.WriteLine(s);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
            }
        }

    }
}
