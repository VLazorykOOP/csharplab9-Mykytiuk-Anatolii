﻿using Task1;
//using Task2;
//using Task3;
//using Task4;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSelect the task number(1-4): ");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Task1.Program.Main_Task1();
                    break;

                case 2:
                   Task2.Program.Main_Task2();
                    break;

                case 3:
                    Console.WriteLine("First part:");
                   Task3_1.Program.Main_Task3_1();
                    Console.WriteLine("Second part:");
                    Task3_2.Program.Main_Task3_2();
                    break;

                case 4:
                    Task4.Program.Main_Task4();
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}