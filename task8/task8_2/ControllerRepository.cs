using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task8.task8_2
{
    class ControllerRepository
    {
        
        public Dictionary<string, Person> PersonsDictionary;
        private Repository PersonRepository;
        public ControllerRepository()
        {
            PersonRepository = new Repository();
            PersonsDictionary = PersonRepository.GetAll().ToDictionary(i=>i.PhoneNumber,i=>i);
        }
        public bool IsPhone(string phone)
        {
            //8916-219-22-22   89162192222 
            string pattern = @"\d{4}-?\d{3}-?\d{2}-?\d{2}";
            Regex reg = new Regex(pattern);
            bool result=reg.IsMatch(phone);
            return (result);
        }
        private string NormalizedPhone(string phone)
        {
            string normalizedPhone = phone.Replace("-","");
            normalizedPhone = normalizedPhone.Insert(9, "-");
            normalizedPhone = normalizedPhone.Insert(7, "-");
            normalizedPhone = normalizedPhone.Insert(4, "-");
            return (normalizedPhone);
        }

        public Dictionary<string,Person> GetPersonByPhone(string textPhone)
        {
            
            if (!IsPhone(textPhone))
                return (null);
            string phone= NormalizedPhone(textPhone);
            if (!PersonsDictionary.ContainsKey(phone))//doubt that it is needed but let's leave it
            {
                return (null);
            }
               var Result =PersonsDictionary.Where(i => i.Value.FullName == PersonsDictionary[phone].FullName);
            return (Result.ToDictionary(x=>x.Key,y=>y.Value));
        }
        public void Add(string phone, string fullName)
        {
            if (!PersonsDictionary.ContainsKey(phone))
            {
                phone = this.NormalizedPhone(phone);
                PersonsDictionary.Add(phone, new Person(fullName, phone));
                PersonRepository.UpdateRepository(PersonsDictionary.Values.ToList());
            }
        }
        public bool IsContain(string phone)
        {           
            bool result = PersonsDictionary.ContainsKey(phone) ? true:false;
            return (result);
        }
        public bool RemoveAtKey(string phone)
        {
            phone = this.NormalizedPhone(phone);
            if (this.IsPhone(phone) & (this.IsContain(phone)))
            {
                PersonsDictionary.Remove(phone);
                return (true);
            }
            return (false);
        }
    }
}
