using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task8.task8_4
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public AddressInfo Address;
        public PhoneInfo Phones;
        public Person()
        {
            Name = null;
            Address = new AddressInfo();
            Phones = new PhoneInfo();

        }
    }
}
