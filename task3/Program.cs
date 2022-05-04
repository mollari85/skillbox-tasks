using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //first task
           int x= GetNumber("Enter any number and get the answer if it is odd or not");
            Console.WriteLine($"number {x} is {Odd(x)}");


            //second task
            Console.WriteLine("\n\r " +
                             "It is the second part.\n\r");
            int cardsNumber = GetNumber("You have some cards on you hands.Tell me thier number");
            int sum = 0;
            for (int i = 1; i <= cardsNumber; i++)
            {
                sum += GetCardsWeight(i, $"Enter {i} card on you hand:");
            }
            Console.WriteLine($"You have summar ={sum}");

            // third task
            Console.WriteLine("\n\r It is the third pard of the task");
            int Number = GetNumber("Enter any positive number and get the answer if it is prime number or not:");
            string sTmp =  IsPrimeNumber(Number) ? "prime" : "not prime";
            Console.WriteLine($"Number {Number.ToString()} is {sTmp}");
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
                    result=Console.ReadLine();
                }
                
            }
            Environment.Exit(0);
            return (0);
        }
        static string Odd(int x)
        {
            return (x % 2 == 0 ? "odd" : "not odd");
        }
        static int GetCardsWeight(int number, string AskForCard)
        {
            string resQuit = "q";
            string result = "no";
            int pictureWeight = 10;
            string card;
            while (result.ToUpper() != resQuit.ToUpper())
            {
                Console.WriteLine(AskForCard);
                card = Console.ReadLine();
                int cardNumber;
                if ((Int32.TryParse(card, out cardNumber)) & cardNumber < 11 & cardNumber > 5)
                {
                    return (cardNumber);
                }
                switch(card.ToUpper())
                {
                    case "J":
                        return (pictureWeight);break;                        
                    case "Q":
                        return (pictureWeight); break;
                    case "K":
                        return (pictureWeight); break;
                    case "T":
                        return (pictureWeight); break;
                    
                }
                Console.WriteLine("You have entered wrong number or letter. Please try again");
                Console.WriteLine("If you would like to quite press q");
            }
            Environment.Exit(0);
            return (0);
        }
        static bool IsPrimeNumber(int x)
        {
            
            int i = 2;
            while ((x % i != 0)& (i<x))
            {
                i++;
            }
            return (i < x ? false : true);
        }
    }
}
