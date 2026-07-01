
namespace DemoProject
{
    internal class Program
    {
        private const string FilePath = "people.txt";
        static void Main(string[] args)
        {
            Person mitak = new Person("Иван", 17, 1234);
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
                        Console.WriteLine();
                        break;

                    case "2":
                        // ==========================================
                        // 2. READ
                        // ==========================================
                        Console.WriteLine("--- Списък с хора ---");
                        if (people.Count == 0)
                        {
                            Console.WriteLine("Списъкът е празен (няма записи във файла).");
                        }
                        else
                        {
                            foreach (Person p in people)
                            {
                                Console.WriteLine(p);
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        // ==========================================
                        // 3. UPDATE
                        // ==========================================
                        Console.Write("Въведете името на човека за промяна на заплатата: ");
                        string nameToUpdate = Console.ReadLine();

                        Person personToUpdate = null;

                        foreach (Person p in people)
                        {
                            if (p.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase))
                            {
                                personToUpdate = p;
                                break;
                            }
                        }

                        if (personToUpdate != null)
                        {
                            Console.Write($"Сегашна заплата на {personToUpdate.Name}: {personToUpdate.Salary:F2}. Нова заплата: ");
                            double newSalary = double.Parse(Console.ReadLine());

                            personToUpdate.Salary = newSalary;

                            // Записваме промените във файла
                            SavePeopleToFile(people);
                            Console.WriteLine("Заплата беше успешно обновена във файла!");
                        }
                        else
                        {
                            Console.WriteLine("Човек с такова име не беше намерен.");
                        }
                        break;
                    case "4":
                        // ==========================================
                        // 4. DELETE
                        // ==========================================
                        Console.Write("Въведете името на човека за изтриване: ");
                        string nameToDelete = Console.ReadLine();

                        int indexToDelete = -1;

                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase))
                            {
                                indexToDelete = i;
                                break;
                            }
                        }

                        if (indexToDelete != -1)
                        {
                            people.RemoveAt(indexToDelete);

                            // Записваме промените (вече без изтрития човек) във файла
                            SavePeopleToFile(people);
                            Console.WriteLine($"Лицето {nameToDelete} беше изтрито от списъка и файла.");
                        }
                        else
                        {
                            Console.WriteLine("Човек с такова име не беше намерен.");
                        }
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Изход от програмата.");
                        break;
                    default:
                        Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                        break;

                }
            
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
