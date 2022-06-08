using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_2
{
    class View
    {
        ControllerRepository controlRepository;
       // Repository repository;
        
        public void MainTask8_2()
        {
            controlRepository = new ControllerRepository();

            Console.WriteLine("it is the second part of the program");
            Console.ReadLine();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
               
                Console.WriteLine("Selecte action: \n\r" +
                                                  "1-Show All \n\r" +
                                                  "2-Show Person \n\r"+
                                                  "3-Add \n\r"+
                                                  "4-Remove\n\r"+
                                                  "5-Exit");
                string choice=Console.ReadLine();
                switch(choice)
                {
                    case "1"://showAll
                        {
                            ShowAll(controlRepository.PersonsDictionary);
                            //show;
                            break;
                        }
                    case "2"://showPerson
                        {
                            ShowPersonByPhone(controlRepository);
                            break;
                        }
                    case "3"://Add
                        {
                            Add(controlRepository);
                            break;
                        }
                    case "4"://Remove
                        {
                            Remove(controlRepository);
                            break;
                        }
                    case "5"://Exit
                        {
                            exit = true;
                            break;
                        }
                }
            }
            Console.ReadLine();

        }
        void ShowHead()
        {

            Console.WriteLine($"{"Full Name",15} | {"Phone Number",15} |");
            Console.WriteLine(new string('_',50));
        }
        public void ShowAll(Dictionary<string,Person> PersonPhones)
        { 
            ShowHead();
            foreach (var i in PersonPhones)
            {
                string s = $"{i.Value.FullName,15} | {i.Value.PhoneNumber,15}|";
                Console.WriteLine(s);
            }
            Console.ReadLine();
            
        }
        public void ShowPersonByPhone(ControllerRepository controller)
        {
            Console.Write("Enter Phone Number:");
            string phone=Console.ReadLine();
            Dictionary<string,Person> TempDictionary=controller.GetPersonByPhone(phone);
            if (TempDictionary == null)
            {
                Console.WriteLine($"there is no person with phone{phone}");
                return;
            }
            bool flag = true;
            ShowHead();
            foreach (var i in TempDictionary)
            {
                string s = flag ? ($"{i.Value.FullName,15} | {i.Value.PhoneNumber,11}|") : ($"{null,15} | {i.Value.PhoneNumber,11}|");
                flag = false;
                Console.WriteLine(s);
            }


            Console.ReadLine();

        }
        public void Add(ControllerRepository controller)
        {
            Console.WriteLine("You would like enter new Person. /n/r " +
                                "Enter FullName:");
            string FullName = Console.ReadLine();
            Console.WriteLine("Leave empty string to stop entering phone numbers./n/r" +
                "Enter phone number.:");
            string sTmpPhone;
            while ((sTmpPhone = Console.ReadLine()) != "")
            {
                if ((controller.IsPhone(sTmpPhone)) & (!controller.IsContain(sTmpPhone)))
                    controller.Add(sTmpPhone, FullName);
                Console.WriteLine("Leave empty string to stop entering phone numbers./n/r" +
                "Enter phone number.:");
            }
        }
        public void Remove(ControllerRepository controller)
        {
            Console.WriteLine("Remove person. Enter its phone number");
            string sTmp = Console.ReadLine();
            string Message = (controller.RemoveAtKey(sTmp)) ? "The phone has been deleted" :
                                                            $"There is no phone nummber {sTmp}";
            Console.ReadLine();
        }
    }
}
