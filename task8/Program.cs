using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8.task8_2;
using task8.task8_3;
using task8.task8_4;
namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Task1
            //Console.WriteLine("it is the first part of task 8");
            //task8_1 Task1 = new task8_1();
            //Console.WriteLine("Default list:");
            //Task1.PrintList();
            //Task1.DeleteNumbers();
            //Console.WriteLine("List after deleting:");
            //Task1.PrintList();
            //Console.ReadLine();
            //#endregion
            //#region Task2
            //View view = new View();
            //view.MainTask8_2();
            //#endregion
            //#region Task3
            //View8_3 view8_3 = new View8_3();
            //view8_3.MainView8_3();
            //#endregion
            #region task4
            View8_4 view8_4 = new View8_4();
            view8_4.Main();
            #endregion
        }
    }
}
