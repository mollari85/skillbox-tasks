using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_2
{
    interface ICommunication
    {
        void SendRepository(IEnumerable<Person> repository, string path);
        IEnumerable<Person> GetRepository(string path);
    }
}
