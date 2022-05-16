using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6.model
{
    /// <summary>
    /// Person with all Properties belongs to person
    /// </summary>
    class Person
    {
            string fullName;
        public string FullName { get { return(fullName);} set { if (!string.IsNullOrEmpty(value)) { fullName = value; } } }
            int age;
        public int Age { get { return (age);} set { if (value > 0) { age = value; } } }
            int height;
        public int Height { get { return (height);} set { if ((value > 10)&&(value<250)) height = value; }  }
            DateTime birthday;
        public DateTime BirthDay { get { return (birthday); } private set{ if (value > DateTime.Now.AddYears(-120)) { birthday = value; } } }
            string placeOfBith;
        public string PlaceOfBith { get { return (placeOfBith); } set{ if (!string.IsNullOrEmpty(value)){ placeOfBith = value;  } } }

        public Person(string fullName, int age, int height, DateTime birthday, string placeOfBith)
        {
            this.FullName = fullName;
            this.Age = age;
            this.Height = height;
            this.BirthDay = birthday;
            this.PlaceOfBith = placeOfBith;
        }
    }
}
