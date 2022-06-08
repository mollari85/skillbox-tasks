using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task8.task8_4
{
    public class PhoneInfo
    {
        private string _mobilePhone;
        private string _flatPhone;
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set
            {
                //89167001122 othere variant of phone number is not included in the task
                string pattern = @"\d{11}";
                Regex rg = new Regex(pattern);
                if (rg.IsMatch(value))
                    _mobilePhone = value;
            }
        }
        public string FlatPhone
        {
            get { return _flatPhone; }
            set
            {
                //84957001122
                string pattern = @"\d{11}";
                Regex rg = new Regex(pattern);
                if (rg.IsMatch(value))
                    _flatPhone = value;
            }
        }
    }
}
