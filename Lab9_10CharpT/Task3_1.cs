using System;
using System.Collections;

namespace Task3_1
{
    class Employee : IComparable, ICloneable
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Employee otherEmp = obj as Employee;
            if (otherEmp != null)
                return this.LastName.CompareTo(otherEmp.LastName);
            else
                throw new ArgumentException("Object is not an Employee");
        }

        public object Clone()
        {
            return new Employee
            {
                LastName = this.LastName,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                Gender = this.Gender,
                Age = this.Age,
                Salary = this.Salary
            };
        }
    }

    class Program
    {
        public static void Main_Task3_1()
        {
            ArrayList employees = new ArrayList();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("C:\\Users\\Anatoha\\github-classroom\\VLazorykOOP\\csharplab9-Mykytiuk-Anatolii\\Lab9_10CharpT\\employees.txt"))
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

            // Сортуємо за прізвищем
            employees.Sort();

            // Розділяємо співробітників на дві групи: зарплата < 10000 та зарплата >= 10000
            Queue lowSalaryEmployees = new Queue();
            Queue highSalaryEmployees = new Queue();
            foreach (Employee emp in employees)
            {
                if (emp.Salary < 10000)
                    lowSalaryEmployees.Enqueue(emp.Clone());
                else
                    highSalaryEmployees.Enqueue(emp.Clone());
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
