using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_3
{
    class Repository
    {

        //in this task i will use hashset insted of LIst.
        Communication com;
        HashSet<int> repository;
        static string path = "JsonTask8_3";
        public Repository()
        {            
            com = new Communication();
            repository = new HashSet<int>(com.GetFromFile(path));
        }
        public bool Add(int number)
        {

            int res = repository.LastOrDefault(n => n == number);
            if (!(res == 0))
                return (false);
            repository.Add(number);
            com.SendToFile(repository.ToList(),path);
            return (true);
        }
        public IEnumerable<int> Show()
        {
            return (repository);
        }
    }
}
