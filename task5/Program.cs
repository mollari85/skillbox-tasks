using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("it is the first part");
            string text = GetTextFromUser();
            PrintWords(GetWords(text));

            Console.WriteLine("it is the second part of the task");
            string text2 = GetTextFromUser();
            string[] words = GetReversText(text2);
            PrintWords(words);
            Console.ReadLine();

        }

        static string GetTextFromUser()
        {
            Console.WriteLine("Enter text:");
            return (Console.ReadLine());
        }
        static string[] GetWords(string text)
        {
            string[] words=text.Split(' ');
            return (words);
        }
        static void PrintWords(string[] words)
        {
            foreach (var i in words)
            {
                Console.WriteLine(i);
            }
        }
        static string[] GetReversText(string text)
        {
            string[] words = GetWords(text);
            string[] revText = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                revText[revText.Length - i-1] = words[i];
            }
            return (revText);
        }
    }
}
