using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8.task8_4.Base;

namespace task8.task8_4
{
    class View8_4
    {
        public void Main()
        {
            ControllerRepository Controller = new ControllerRepository();
            Console.Clear();
            Console.WriteLine("it is the forth part of the task");
            Console.ReadLine();
             
            bool flagExit = false;
            while (!flagExit)
            {
                Console.WriteLine("there is a person database: \n\r 1-Show \n\r" +
                    "2-Add\n\r 3-Remove\n\r 4-Exit\n\r 9-add Default");
                switch (Console.ReadLine())
                {
                    case "1"://show
                        {
                            Console.Clear();
                            Controller.ShowHead();
                            Controller.ShowAll();
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }
                    case "2"://Add
                        {
                            Console.Clear();
                            Controller.Add();
                            Console.Clear();
                            break;
                        }
                    case "3"://Remove
                        {
                            Console.Clear();
                            Console.WriteLine("Enter person you would like to remove:");
                            string sTmp = Console.ReadLine();
                            Controller.Remove(sTmp);
                            break;
                        }
                    case "4"://Exit
                        {
                            flagExit = true;
                            break;
                        }
                    case "9"://Add
                        {
                            Console.Clear();
                            Controller.AddDefault();
                            Console.Clear();
                            break;
                        }
                }
            }
        }
    }
}
