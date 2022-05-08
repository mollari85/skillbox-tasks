using System;
using System.Text;
using task6.VM;

namespace task6
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            ControllerNote ControlNote = new ControllerNote();
            Console.WriteLine("it is the part 1 of the task");
            while (true)
            {
                MainMenuSelection(ControlNote);

            }
        }
        static void MainMenuSelection(ControllerNote Note)
        {
            try
            {
                string answer;
                Console.Clear();
                Console.WriteLine("this is new emploee dictionary");
                Console.WriteLine("Press:\n\r1-Show all employees\n\r"
                                             + "2-Add\n\r"
                                             + "3-Remove\n\r"
                                             + "4-Exit\n\r");
                answer = Console.ReadLine();
                if (!int.TryParse(answer, out int iAnswer))
                {
                    throw new ArgumentException("the answer is not correct, try again");
                }
                switch (iAnswer)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write(Note.ShowdataInConsole());
                            Console.WriteLine("Press any key to go on");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                
                                SetData del = Note.SetID;
                                ShowPersonTmp delShow = Note.ShowTempPerson;
                                AddingEmployee("Enter ID:", del, delShow);
                                del = Note.SetFullName;
                                AddingEmployee("Enter Surname, First Name and third Name:", del, delShow);
                                del = Note.SetAge;
                                AddingEmployee("Enter Age:", del, delShow);
                                del = Note.SetHeight;
                                AddingEmployee("Enter Height:", del, delShow);
                                del = Note.SetBirthday;
                                AddingEmployee("Enter Birthday yyyy.mm.dd:", del, delShow);
                                del = Note.SetPlaceOfBirth;
                                AddingEmployee("Enter place of birthday:", del, delShow);
                                Note.AddPerson();
                                //show result
                                Console.WriteLine("Result Employee:");
                                AddingEmployee(null, null, delShow);
                                Console.WriteLine("Press Enter to go on");
                                Console.ReadLine();
                            }
                            catch (Exception d) { Console.WriteLine(d.Message); }
                            break;
                        }
                    case 3:
                        {
                            RemoveItemAt delegRemove = Note.RemoveAtPerson;
                            RemoveItem("You want to delete the person. Enter it's ID:", delegRemove);
                        }
                        break;
                    case 4:
                        { Environment.Exit(0); }
                        break;
                    default:
                        {
                            Console.WriteLine("Selection is not correct");
                            Console.ReadLine();
                            Console.Clear();
                            MainMenuSelection(Note);
                        }
                        break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message);Console.ReadLine(); Console.Clear(); MainMenuSelection(Note); }


        }
        public  delegate  void SetData (string s);
        public delegate string ShowPersonTmp();
        static string AddingEmployee(string sTmp, SetData deleg,ShowPersonTmp delegShow)
        {
            try
            {
                Console.Clear();
                //printing the head
                PrintingHead();
                //priniting fulfilled column;
                Console.WriteLine(delegShow?.Invoke());
                //printing the question
                Console.Write(sTmp);
                string answer = Console.ReadLine();
                //checking the answer
                deleg?.Invoke(answer);
            }
            catch(Exception e) { Console.WriteLine(e.Message); Console.WriteLine("Press Enter to go on"); Console.ReadLine(); AddingEmployee(sTmp, deleg, delegShow); }
            return (null);
        }
        static void PrintingHead()
        {
            string sTmp;
            sTmp = ($"{"ID",3}|{"Date and Time",15}|{"FIO",15}|{"Age",4}|{"Height",7}|{"Birthday",10}|{"Place of Birth",15}|\0");
            sTmp += (new string('-', 75) + "\0");
            Console.WriteLine(sTmp);
        }
        public delegate void RemoveItemAt(string s);
        static void RemoveItem(string sTmp,RemoveItemAt deleg)
        {
            try
            {
                Console.WriteLine(sTmp);
                string text = Console.ReadLine();
                deleg(text);
            }
            catch (Exception e){ Console.WriteLine(e.Message); Console.ReadLine(); RemoveItem(sTmp,deleg); }
        }
    }
}
