using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_4.Base
{
    class ControllerRepository
    {

        Repository Repository;
        Communication communicationToXML;
        public ControllerRepository()
        {
            communicationToXML = new Communication(null);
            Repository = new  Repository(communicationToXML);
        }
        public void ShowHead()
        {
            Console.WriteLine($"{"Full Name",10} | {"Street",10} | {"House N",7} |{"Flat N",7} | " +
                $"{"MobilePhone",15} | {"FlatPhone",15}");
            Console.WriteLine(new String('-',79));
        }
        public void ShowPerson(Person Person)
        {
            Console.WriteLine($"{Person.Name,10} | {Person.Address.Street,10} | {Person.Address.HouseNumber,7} " +
                $"|{Person.Address.FlatNumber,7} | " +
            $"{Person.Phones.MobilePhone,15} | {Person.Phones.FlatPhone,15}");
        }
        public void ShowAll()
        {
            var PersonsList=Repository.GetAll();
            if (PersonsList == null)
                return;
            foreach(var Person in PersonsList)
            Console.WriteLine($"{Person.Name,10} | {Person.Address.Street,10} | {Person.Address.HouseNumber,7} " +
                $"|{Person.Address.FlatNumber,7} | " +
            $"{Person.Phones.MobilePhone,15} | {Person.Phones.FlatPhone,15}");
        }
        public void Add()
        {
            try
            {
                //no checking for entering
                Person PersonTmp = new Person();
                Console.Write("Enter Full Name ");
                PersonTmp.Name = Console.ReadLine();
                Console.Write("Enter Street name ");
                
                PersonTmp.Address.Street = Console.ReadLine();  
                Console.Write("Enter HouseNUmber ");
                int iTmp;
                int.TryParse(Console.ReadLine(), out iTmp);
                PersonTmp.Address.HouseNumber = iTmp;
                Console.Write("Enter Flat Number ");
                int.TryParse(Console.ReadLine(), out iTmp);
                PersonTmp.Address.FlatNumber = iTmp;
                Console.Write("Enter Cell Phone Number (format 89167001122) ");
                PersonTmp.Phones.MobilePhone = Console.ReadLine();
                Console.Write("Enter Flat Phone Number  (format 89167001122) ");
                string stmp = Console.ReadLine();
                PersonTmp.Phones.FlatPhone = stmp;

                Repository.Add(PersonTmp);
                Console.WriteLine("added successful");
                Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine("Wrong with Entering"); 
Console.ReadLine(); }
        }
        public void AddDefault()
        {
            Person PersonTmp = new Person();
            PersonTmp.Name = "Den";
            PersonTmp.Address.Street = "Salt";
            PersonTmp.Address.FlatNumber = 1;
            PersonTmp.Address.HouseNumber = 2;
            PersonTmp.Phones.FlatPhone = "84951001010";
            PersonTmp.Phones.MobilePhone = "89162223344";

            Repository.Add(PersonTmp);
        }
        public void Remove(string FullName)
        {
            Repository.Remove(FullName);
        }
    }
}
