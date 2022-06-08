using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_4
{
    interface ICommunication
    {
        void SendToFile(IEnumerable<Person> per);
        IEnumerable<Person> GetFromFile();

    }
}
