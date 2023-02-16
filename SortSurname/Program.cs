using System;
using System.Collections.Generic;
using static SortSurname.Program;

namespace SortSurname
{
    public class Program
    {
        public delegate void Notify();

        static List<string> surnames = new List<string> { "Иванов", "Петров", "Сидоров", "Васильев", "Крылов" };
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += ShowNumber;

            while (true)
            {
                try
                {
                    numberReader.Read();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
                catch (SuperException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void ShowNumber(int number)
        {
            switch (number)
            {
                case 1:
                    surnames.Sort();
                    Console.WriteLine(string.Join(", ", surnames));
                    break;
                case 2:
                    surnames.Sort();
                    surnames.Reverse();
                    Console.WriteLine(string.Join(", ", surnames));
                    break;
            }
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;
        public void Read()
        {
            Console.Write("Необходимо ввести значение 1 или 2: ");

            int number = Convert.ToInt32(Console.ReadLine());

            if(number != 1 && number != 2) { throw new SuperException("Хорошо, что вы ввели цифру, но нужно ввести либо 1 либо 2"); }

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent.Invoke(number);
        }
    }
}
