using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("it is the first part");
            int matrixRow = GetNumber("Enter row number of the matrix");
            int matrixColumn = GetNumber("Enter column number of the matrix");
            int[,] myArray = GetMatrix(matrixRow, matrixColumn);
            ShowMatrix(myArray);
            int sum = SumAllElements(myArray);
            Console.WriteLine($"Sum of all elements={sum}");


            Console.WriteLine("\n\r It is the second part of the task");
            int matrixLenght = GetNumber("Enter length of the matrix");
            GetMatrixFromUser(matrixLenght, out int[] userArray);
            int min = MinValue(userArray);
            Console.WriteLine("Min value is:" + min);

            Console.WriteLine("\n\r It is the third part of the task");
            int range = GetNumber("Enter the range from 0 to :");
            int computerNumber = GetRandomNumberInRange(range);
            Guessing(computerNumber, range);



            Console.ReadLine();

        }

        static int GetNumber(string AskForNumber)
        {
            string resQuit = "q";
            string result = "no";
            int value;
            while (result.ToUpper() != resQuit.ToUpper())
            {
                Console.WriteLine(AskForNumber);
                if (Int32.TryParse(Console.ReadLine(), out value))
                    return (value);
                else
                {
                    Console.WriteLine("You have entered wrong number. Please try again");
                    Console.WriteLine("If you would like to quite press q");
                    result = Console.ReadLine();
                }

            }
            Environment.Exit(0);
            return (0);
        }
        static int[,] GetMatrix(int row, int column=0)
        {
            int[,] a=new int[row,column];
            Random rn = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                {
                    a[i, j] = rn.Next(0, 100);
                }
            return (a);
        }
        static void ShowMatrix(int[,] a)
        {

            Console.WriteLine($"Our matrix has {a.Length} elements");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write( "{0:00} ",a[i, j]);
                }
                Console.WriteLine();
            }

        }
        static int SumAllElements(int[,] a)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j];
                }
                
            }
            return (sum);
        }
        static int[] GetMatrixFromUser(int length, out int[] myArray)
        {
            myArray = new int[length];
            for (var i = 0; i < length; i++)
            {
                myArray[i] = GetNumber($"Enter {i} element of the matrix");
            }
            return (myArray);
        }
        static int MinValue(int[] array)
        {
            int min = array[0];
            for (var i = 1; i < array.Length; i++)
            {
                min = array[i] < min ?array[i]:min;
            }
            return (min);
        }
        static int GetRandomNumberInRange(int maxValue)
        {
            Random rn = new Random(DateTime.Now.Millisecond);
            return (rn.Next(0, maxValue));
        }
        /// <summary>
        /// guessing,
        /// </summary>
        /// <param name="it is guessed number by app"></param>
        /// <param name="max value"></param>
        static void Guessing(int computerNumber, int range)
        {

            while (true)
            {
                Console.WriteLine("Enter a number from the range 0 to " + range);
                string sTmp = Console.ReadLine();
                if (string.IsNullOrEmpty(sTmp))
                {
                    Console.WriteLine("Guessed number is " + computerNumber);
                    break;
                }
                if ((Int32.TryParse(sTmp, out int userNumber))&(userNumber<range)& (userNumber>=0))
                {
                    if (userNumber > computerNumber) Console.WriteLine($"Your number is more then guessed number");
                    else if (userNumber < computerNumber) Console.WriteLine($"Your number is less then guessed number");
                    else
                    {
                        Console.WriteLine($"Your are right. Guessed number is " + computerNumber);
                        break;
                    }
                }
            }
        }


    }
}
