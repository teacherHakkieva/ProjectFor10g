
namespace DemoProject
{
    internal class Program
    {
        private const string FilePath = "people.txt";
        static void Main(string[] args)
        {
            Person mitak = new Person("Иван", 17, 1234.56);
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
               
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        // ==========================================
                        // 1. CREATE – Въвеждане от конзолата
                        // ==========================================
                        Console.Write("Въведете име: ");
                        string name = Console.ReadLine();

                        Console.Write("Въведете възраст: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Въведете заплата: ");
                        double salary = double.Parse(Console.ReadLine());

                        Person newPerson = new Person(name, age, salary);
                        people.Add(newPerson);

                        // Записваме обновения списък във файла
                        SavePeopleToFile(people);
                        Console.WriteLine("Успешно добавен нов запис!");
                        break;
                      

                }
                break;
            }
        }
        static void SavePeopleToFile(List<Person> people)
        {
            List<string> rows = new List<string>();
            foreach (Person p in people)
            {
                rows.Add(p.ToFileRow());
            }
            File.WriteAllLines(FilePath, rows);
        }
    }
}
