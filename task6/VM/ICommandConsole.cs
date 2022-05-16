using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6.VM
{
    interface ICommandConsole
    {
        void SetID(string text);
        void SetFullName(string text);
        void SetAge(string text);
        void SetHeight(string text);
        void SetBirthday(string text);
        void SetPlaceOfBirth(string text);
        void AddPerson();
        string ShowTempPerson();
        string ShowAllInConsole();
        string ShowAllInConsoleOrdered();
        string ShowAllInConsoleInRange(string StartDate, string EndDate);
        void RemoveAtPerson(string text);
        

        void EditAtPerson(string text);
        

        //int? ID { get; set; }
        //DateTime? CorrectionDateTime { get; set; }
        //string FullName { get; set; }
        //int? Age { get; set; }
        //int? Height { get; set; }
        //DateTime? BirthDay { get; set; }
        //string PlaceOfBirth { get; set; }


    }
}
