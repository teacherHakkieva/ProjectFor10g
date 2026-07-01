using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoProject
{
    internal class Person
    {
        string Name { get; set; }
        int Age { get; set; }
        double salary;

        public Person(string name, int age, double salary)
        {
           Name = name;
           Age = age;
            Salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public override string ToString()
        {
          return ($"Name:{Name}-age:{Age} and salary:{salary}");
        }
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
