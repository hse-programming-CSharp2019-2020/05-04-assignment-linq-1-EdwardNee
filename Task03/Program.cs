using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*Все действия по обработке данных выполнять с использованием LINQ
 * 
 * Объявите перечисление Manufacturer, состоящее из элементов
 * Dell (код производителя - 0), Asus (1), Apple (2), Microsoft (3).
 * 
 * Обратите внимание на класс ComputerInfo, он содержит поле типа Manufacturer
 * 
 * На вход подается число N.
 * На следующих N строках через пробел записана информация о компьютере: 
 * фамилия владельца, код производителя (от 0 до 3) и год выпуска (в диапазоне 1970-2020).
 * Затем с помощью средств LINQ двумя разными способами (как запрос или через методы)
 * отсортируйте коллекцию следующим образом:
 * 1. Первоочередно объекты ComputerInfo сортируются по фамилии владельца в убывающем порядке
 * 2. Для объектов, у которых фамилии владельцев сопадают, 
 * сортировка идет по названию компании производителя (НЕ по коду) в возрастающем порядке.
 * 3. Если совпадают и фамилия, и имя производителя, то сортировать по году выпуска в порядке возрастания.
 * 
 * Выведите элементы каждой коллекции на экран в формате:
 * <Фамилия_владельца>: <Имя_производителя> [<Год_производства>]
 * 
 * Пример ввода:
 * 3
 * Ivanov 1970 0
 * Ivanov 1971 0
 * Ivanov 1970 1
 * 
 * Пример вывода:
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * 
 *  * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * При некорректных входных данных (не связанных с созданием объекта) выбрасывайте FormatException
 * При невозможности создать объект класса ComputerInfo выбрасывайте ArgumentException!
 */
namespace Task03
{
    public enum Manufacturer
    {
        Dell = 0, Asus = 1, Apple = 2, Microsoft = 3
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int N;
            List<ComputerInfo> computerInfoList = new List<ComputerInfo>();
            try
            {
                N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                for (int i = 0; i < N; i++)
                {
                    var info = Console.ReadLine().Split(' ');
                    computerInfoList.Add(new ComputerInfo
                    {
                        Owner = info[0],
                        Date = int.Parse(info[1]),
                        ComputerManufacturer = (Manufacturer)Enum.Parse(typeof(Manufacturer), info[2])
                    });
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
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
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }



            try
            {
                // выполните сортировку одним выражением
                var computerInfoQuery = from ci in computerInfoList
                    orderby ci.Owner descending, ci.ComputerManufacturer.ToString(), ci.Date descending 
                    select ci;


            

                PrintCollectionInOneLine(computerInfoQuery);

                Console.WriteLine();

                // выполните сортировку одним выражением
                var computerInfoMethods = computerInfoList.OrderByDescending(ci => ci.Owner)
                    .ThenBy(ci => ci.ComputerManufacturer.ToString()).ThenByDescending(ci => ci.Date);

                PrintCollectionInOneLine(computerInfoMethods);

            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
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
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
        }

        // выведите элементы коллекции на экран с помощью кода, состоящего из одной линии (должна быть одна точка с запятой)
        public static void PrintCollectionInOneLine(IEnumerable<ComputerInfo> collection)
        {
            collection.ToList().ForEach(c=>Console.WriteLine($"{c.Owner}: {c.ComputerManufacturer.ToString()} [{c.Date}]"));
        }
    }


    class ComputerInfo
    {
        private int date;

        public int Date
        {
            get => date;
            set
            {
                if (value < 1970 | value > 2020)
                {
                    throw new ArgumentException();
                }
                date = value;
            }
        }

        public string Owner { get; set; }
        private Manufacturer coManufacturer;
        public Manufacturer ComputerManufacturer
        {
            get => coManufacturer;
            set
            {
                if ((int)value > 3 || value < 0)
                {
                    throw new ArgumentException();
                }
                coManufacturer = value;
            }
        }

    }
}
