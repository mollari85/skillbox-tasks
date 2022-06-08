using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8.task8_4
{
    class Repository
    {
        List<Person> _PersonRepository;
        Communication _ICom;
        public Repository(Communication com)
        {
            _ICom = com;
            _PersonRepository = new List<Person>();// method uses XType (XElement, xDocument)
           // _PersonRepository = _ICom.GetFromFile("dd").ToList<Person>(); // method uses XMLType (XMLElement, XMLDocument)
           // _PersonRepository = _ICom.GetFromFileSer().ToList<Person>();//method uses XML Serialization
        }
        public IEnumerable<Person> GetAll()
        {
            return (_PersonRepository);
        }
        public void Add(Person person)
        {
            _PersonRepository.Add(person);
            _ICom.SendToFile(_PersonRepository);

        }
        public void Remove(string FullName)
        {
            
            _PersonRepository.RemoveAll((n => n.Name == FullName));
            _ICom.SendToFile(_PersonRepository);
        }
    }
}
