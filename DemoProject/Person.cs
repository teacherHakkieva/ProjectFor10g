

namespace DemoProject
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Person(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Име: {Name}, Възраст: {Age}, Заплата: {Salary:F2}";
        }

        // Преобразува обекта в ред, подходящ за запис във файл (напр. Иван;25;2500)
        public string ToFileRow()
        {
            return $"{Name};{Age};{Salary}";
        }

        // Създава обект Person от прочетен ред от файла
        public static Person FromFileRow(string row)
        {
            string[] parts = row.Split(';');
            if (parts.Length == 3)
            {
                string name = parts[0];
                int age = int.Parse(parts[1]);
                double salary = double.Parse(parts[2]);
                return new Person(name, age, salary);
            }
            return null;
        }
    }
}

