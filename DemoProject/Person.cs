using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    internal class Person
    {
        string name { get; set; }
        int age { get; set; }
        double salary;

        public Person(string name,int age, double salary) {
        this.name=name;
            this.age=age;
            this.salary = salary;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
         public  void PresetMe()
        {
            Console.WriteLine($"Name:{name}-age:{age} and salary:{this.salary}");
        }

    }
}
