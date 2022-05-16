using System;
using System.Text;
using task6.VM;

namespace task6
{
    class Program
    {
      


        static void Main(string[] args)
        {
            //i am trying to use command 
            ICommandConsole NoteCommand;                    
            ControllerRepos ControlNote = new ControllerRepos();
            NoteCommand = ControlNote;    
            Console.WriteLine("it is the part 1 of the task");
            while (true)
            {
                MainMenuSelection(ControlNote);

            }
        }
        static void MainMenuSelection(ICommandConsole NoteCommand)
        {
            try
            {
                string answer;
                Console.Clear();
                Console.WriteLine("this is new emploee dictionary");
                Console.WriteLine("Press:\n\r1-Show all employees\n\r"
                                             + "2-Add\n\r"
                                             + "3-Remove\n\r"
                                             + "4-Edit\n\r"
                                             + "5-Select Person in a range \n\r"
                                             + "6-Show all employees ordered \n\r"
                                             + "9-Exit\n\r");
                answer = Console.ReadLine();
                if (!int.TryParse(answer, out int iAnswer))
                {
                    throw new ArgumentException("the answer is not correct, try again");
                }
                switch (iAnswer)
                {
                    case 1://Show
                        {
                            Console.Clear();
                            Console.Write(NoteCommand.ShowAllInConsole());
                            Console.WriteLine("Press any key to go on");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2://Add
                        {
                            try
                            {
                                
                                SetData delegSetData = NoteCommand.SetID;
                                ShowPersonTmp delegShow = NoteCommand.ShowTempPerson;
                                AddingEmployee("Enter ID:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetFullName;
                                AddingEmployee("Enter Surname, First Name and third Name:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetAge;
                                AddingEmployee("Enter Age:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetHeight;
                                AddingEmployee("Enter Height:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetBirthday;
                                AddingEmployee("Enter Birthday yyyy.mm.dd:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetPlaceOfBirth;
                                AddingEmployee("Enter place of birthday:", delegSetData, delegShow);
                                NoteCommand.AddPerson();
                                //show result
                                Console.WriteLine("Result Employee:");
                                AddingEmployee("Press Enter to go on", null, delegShow);
                                Console.ReadLine();
                            }
                            catch (Exception d) { Console.WriteLine(d.Message); }
                            break;
                        }
                    case 3://Remove
                        {
                            Console.Clear();
                            Console.Write(NoteCommand.ShowAllInConsole());
                            RemoveItemAt delegRemove = NoteCommand.RemoveAtPerson;
                            RemoveItem("Press Enter to Cancel.\n\r " +
                                "You want to delete the person. Enter it's ID:", delegRemove);
                        }
                        break;
                    case 4://Edit
                        {
                            try
                            {
                                Console.Clear();
                                SetData delegSetData = NoteCommand.SetID;
                                ShowPersonTmp delegShow = NoteCommand.ShowTempPerson;
                                Console.Write(NoteCommand.ShowAllInConsole());
                                EditItemAt delegEdit = NoteCommand.EditAtPerson;
                                EditItem("You want to edit the person. Enter it's ID:", delegEdit);
                                AddingEmployee("Enter ID:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetFullName;
                                AddingEmployee("Enter Surname, First Name and third Name:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetAge;
                                AddingEmployee("Enter Age:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetHeight;
                                AddingEmployee("Enter Height:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetBirthday;
                                AddingEmployee("Enter Birthday yyyy.mm.dd:", delegSetData, delegShow);
                                delegSetData = NoteCommand.SetPlaceOfBirth;
                                AddingEmployee("Enter place of birthday:", delegSetData, delegShow);
                                NoteCommand.AddPerson();
                                //show result
                                Console.WriteLine("Result Employee:");
                                AddingEmployee("Press Enter to go on", null, delegShow);
                                Console.ReadLine();
                            }
                            catch (Exception d) { Console.WriteLine(d.Message); }
                            break;
                        }
                        break;
                    case 5://range
                        {
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter start date yyyy.mm.dd:");
                                string textStartDate = Console.ReadLine();
                                Console.WriteLine("Enter end date yyyy.mm.dd:");
                                string textEndDate = Console.ReadLine();
                                string result = NoteCommand.ShowAllInConsoleInRange(textStartDate, textEndDate);
                                Console.WriteLine(result);
                                Console.ReadLine();
                             }
                            catch (Exception d) { Console.WriteLine(d.Message); }
                        }
                        break;
                    case 6://Ordering
                        {
                            Console.Clear();
                            string result=NoteCommand.ShowAllInConsoleOrdered();
                            Console.WriteLine(result);
                            Console.ReadLine();
                        }
                        break;
                    case 9:
                        { Environment.Exit(0); }
                        break;
                    default:
                        {
                            
                            Console.WriteLine("Selection is not correct");
                            Console.ReadLine();
                            Console.Clear();
                            MainMenuSelection(NoteCommand);
                        }
                        break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message);Console.ReadLine(); Console.Clear(); MainMenuSelection(NoteCommand); }


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
                if (string.IsNullOrEmpty(text))
                    return;
                deleg(text);
            }
            catch (Exception e){ Console.WriteLine(e.Message); Console.ReadLine(); RemoveItem(sTmp,deleg); }
        }



        public delegate void EditItemAt(string s);
        static void EditItem(string sTmp, EditItemAt EditDeleg)
        {
            try
            {
                Console.WriteLine(sTmp);
                string text = Console.ReadLine();
                EditDeleg(text);
            }
            catch (Exception e) { Console.WriteLine(e.Message); Console.ReadLine(); EditItem(sTmp, EditDeleg); }
        }
    }
}
