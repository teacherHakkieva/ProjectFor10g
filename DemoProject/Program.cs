using System.Threading;

namespace DemoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person mitak = new Person("Ivan", 15, 1234.56);

            Console.WriteLine(mitak.ToString());

            List<Person> people = new List<Person>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("---Избери операция---");
                Console.WriteLine("1. CREATE (Добавяне на човек)");
                Console.WriteLine("2. READ (Показване на всички)");
                Console.WriteLine("3. UPDATE (Промяна на заплата)");
                Console.WriteLine("4. DELETE (Изтриване по име)");
                Console.WriteLine("5. Изход");
                Console.Write("Избор: ");

                break;


            }
        }
    }
}
