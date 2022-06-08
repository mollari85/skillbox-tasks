using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task8.task8_2
{
    class Person
    {
        /// <summary>
        /// First Name and Second Name
        /// </summary>
        public string FullName { get; set;}
        /// <summary>
        /// phone number in Russian format 7-xxx-xxx-xx-xx
        /// </summary>
        private string phoneNumber;
        public string PhoneNumber { get { return (phoneNumber); } set { phoneNumber = value; } }
        public string HiddenProperty { get; set;}
        public Person(string FullName, string Phone)
        {
            this.FullName = FullName;
            this.PhoneNumber = Phone;
        }
    }
}
