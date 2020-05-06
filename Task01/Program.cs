using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо отфильтровать полученные коллекцию, оставив только отрицательные или четные числа.
 * Дважды вывести коллекцию, разделив элементы специальным символом.
 * Остальные указания см. непосредственно в коде!
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 2:4
 * 2*4
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
 * 
 */

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk01();
        }

        public static void RunTesk01()
        {
            int[] arr = default;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = (from str in Console.ReadLine()?.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    select int.Parse(str)).ToArray();

                //Еще можно так.
                //arr = Console.ReadLine()?.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            catch (InvalidOperationException)
            {
                //ничего не введено.
                Console.WriteLine("InvalidOperationException");
            }
            catch (FormatException)
            {
                //Введено не число.
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"OverflowException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            try
            {
                // использовать синтаксис запросов!
                IEnumerable<int> arrQuery = from el in arr
                                        where el % 2 == 0 | el < 0
                                        select el;
            //IEnumerable<int> arrQuery = arr.Where(x => x % 2 == 0);

            // использовать синтаксис методов!
            IEnumerable<int> arrMethod = arr.Where(x => x % 2 == 0 | x < 0);

            
                PrintEnumerableCollection<int>(arrQuery, ":");
                PrintEnumerableCollection<int>(arrMethod, "*");
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

        // Попробуйте осуществить вывод элементов коллекции с учетом разделителя, записав это ОДНИМ ВЫРАЖЕНИЕМ.
        // P.S. Есть два способа, оставьте тот, в котором применяется LINQ...
        public static void PrintEnumerableCollection<T>(IEnumerable<T> collection, string separator)
        {
            //Console.WriteLine(string.Join(separator, collection));

            var res = collection.Select(x => x.ToString()).Aggregate((current, next) => current + separator + next);
            // var res = collection.OfType<string>().Aggregate((current, next) => current + separator + next);
            Console.WriteLine(res);
        }
    }
}
