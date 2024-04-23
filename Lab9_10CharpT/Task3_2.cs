using System;
using System.Collections.Generic;

namespace Task3_2
{
    class Program
    {
        // Клас для перетворення постфіксного виразу у префіксний
        public static class PrefixConverter
        {
            // Метод для перетворення постфіксного виразу у префіксний
            public static string ConvertToPrefixExpression(string expression)
            {
                Stack<string> stack = new Stack<string>();

                // Розділити вираз на токени
                string[] tokens = expression.Split(' ');

                // Перебираємо кожен токен у виразі
                foreach (string token in tokens)
                {
                    // Якщо токен є операндом, поміщаємо його у стек
                    if (IsOperand(token))
                    {
                        stack.Push(token);
                    }
                    // Якщо токен є оператором, видаляємо два верхніх операнди зі стеку,
                    // об'єднуємо їх з оператором і поміщаємо результат у стек
                    else if (IsOperator(token))
                    {
                        string operand2 = stack.Pop();
                        string operand1 = stack.Pop();
                        string newExpression = token + " " + operand1 + " " + operand2;
                        stack.Push(newExpression);
                    }
                }

                // Результатом є останній елемент у стеку
                return stack.Peek();
            }

            // Функція для перевірки, чи є токен операндом
            public static bool IsOperand(string token)
            {
                return !IsOperator(token);
            }

            // Функція для перевірки, чи є токен оператором
            public static bool IsOperator(string token)
            {
                return token == "+" || token == "-" || token == "*" || token == "/";
            }
        }

        public static void Main_Task3_2()
        {
            string postfixExpression = "10 5 + 8 3 - *";
            string prefixExpression = PrefixConverter.ConvertToPrefixExpression(postfixExpression);
            Console.WriteLine("Prefix expression: " + prefixExpression);
        }
    }
}
