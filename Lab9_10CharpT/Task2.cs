using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {MiddleName}, {Gender}, {Age}, {Salary}";
        }
    }

    class Program
    {
        public static void Main_Task2()
        {
            // Читаємо дані з файлу і зберігаємо їх у списку співробітників
            List<Employee> employees = new List<Employee>();
            using (StreamReader sr = new StreamReader("C:\\Users\\Anatoha\\github-classroom\\VLazorykOOP\\csharplab9-Mykytiuk-Anatolii\\Lab9_10CharpT\\employees.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(',');
                    if (data.Length == 6)
                    {
                        Employee emp = new Employee
                        {
                            LastName = data[0],
                            FirstName = data[1],
                            MiddleName = data[2],
                            Age = int.Parse(data[4]),
                            Salary = double.Parse(data[5])
                        };

                        // Отримуємо перший символ рядка та перетворюємо його у символ для статі співробітника
                        char gender;
                        if (char.TryParse(data[3].Substring(0, 1), out gender))
                        {
                            emp.Gender = gender;
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect gender format for employee: {emp.LastName}, {emp.FirstName}, {emp.MiddleName}");
                            continue;
                        }

                        employees.Add(emp);
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect data format for employee: {string.Join(",", data)}");
                    }
                }
            }

            // Розділяємо співробітників на дві групи: зарплата < 10000 та зарплата >= 10000
            Queue<Employee> lowSalaryEmployees = new Queue<Employee>();
            Queue<Employee> highSalaryEmployees = new Queue<Employee>();
            foreach (Employee emp in employees)
            {
                if (emp.Salary < 10000)
                    lowSalaryEmployees.Enqueue(emp);
                else
                    highSalaryEmployees.Enqueue(emp);
            }

            // Друкуємо спочатку співробітників з низькою зарплатою, потім з високою
            Console.WriteLine("Employees with salary < 10000:");
            while (lowSalaryEmployees.Count > 0)
            {
                Console.WriteLine(lowSalaryEmployees.Dequeue());
            }

            Console.WriteLine("\nEmployees with salary >= 10000:");
            while (highSalaryEmployees.Count > 0)
            {
                Console.WriteLine(highSalaryEmployees.Dequeue());
            }
        }
    }
}
