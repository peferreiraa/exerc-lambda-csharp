using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using ExercLambda.Entities;

namespace ExercLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double enterSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            Console.WriteLine();
     
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }

                }

                var searchEmployee = list.Where(p => p.Salary >= enterSalary).OrderBy(p => p.Email).Select(p => p.Email);
                Console.WriteLine("Email of people whose salary is more than " + enterSalary.ToString("F2", CultureInfo.InvariantCulture));

                foreach (string employee in searchEmployee)
                {
                    Console.WriteLine(employee);
                }

                Console.WriteLine();
                var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch(IOException e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
