using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_3
{
    class View8_3
    {
        public void MainView8_3()
        {
            Repository SetRepos = new Repository();
            Console.Clear();
            Console.WriteLine("it is the third part of the task");
            Console.ReadLine();
            Console.Clear();
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("There is a set of numbers" +
                    "\n\r 1-Show; \n\r 2-Add \n\r 3-Exit");
                switch (Console.ReadLine())
                {
                    case "1"://Show
                    {
                            Console.WriteLine("The set has next numbers:");
                            foreach (var i in SetRepos.Show())
                                Console.WriteLine(i);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                     }
                    case "2"://Add
                        {
                            Console.WriteLine("Enter new number");
                            string sTmp=Console.ReadLine();
                            int number;
                            if (int.TryParse(sTmp, out number))
                                if (SetRepos.Add(number))
                                    Console.WriteLine($"Number {number} has been added");
                                else
                                    Console.WriteLine($"Our set has already had number {number}");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                            
                        }
                    case "3"://Exit
                        {
                            flag = true;
                            break;
                        }
                }
                
            }
        }
    }
}
