using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_4
{
    public class AddressInfo
    {
        public string Street { get; set; }
        public int _houseNumber;
        public int HouseNumber { get { return (_houseNumber);} set { if (value > 0) _houseNumber = value; } }
        private int _flatNumber;
        public int FlatNumber { get { return (_flatNumber); } set { if (value > 0) _flatNumber = value; } }
    }
}
