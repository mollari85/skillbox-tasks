using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {

        static void Main(string[] args)
        {
            string fullName = "Ivanov Ivan Ivanovich";
            int age = 31;
            string eMail = "Ivanov@mail.ru";
            int gradeMath = 3;
            int gradePhisics = 4;
            int gradeProgramming = 3;
            double avgGrade = avgResult(gradeMath, gradePhisics, gradePhisics);

            Console.WriteLine($"{fullName} with eMail {eMail} has grades:" +
                $" \n{new string('-', 60)} \n\r" +
                $"Grade Math: \t\t {gradeMath}\n\r" +
                $"Grade Phishics: \t {gradePhisics}\n\r" +
                $"Grade Programming: \t {gradeProgramming}\n\r" +
                $"{new string('-', 60)} \n\r" +
                $"Result: \t\t {avgGrade.ToString("#.###")}");
            Console.ReadLine();
        }

        static double avgResult(int math, int phisics, int programming)
        {
            double sum = math + phisics + programming;
            double avgResult = sum / 3;
            return (avgResult);
           // return ((math + phisics + programming) / 3);
        }
    }
}
