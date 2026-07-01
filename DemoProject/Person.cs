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
        string name { get; set; }
        int age { get; set; }
        double salary;

        public Person(string name, int age, double salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public override string ToString()
        {
          return ($"Name:{this.name}-age:{this.age} and salary:{this.salary}");
        }
        public string ToFileRow()
        {
            return $"{name};{age};{Salary}";
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
