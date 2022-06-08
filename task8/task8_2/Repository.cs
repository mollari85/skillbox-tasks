using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task8.task8_2
{
    class Repository
    {
        const string pathJson = "JsonRepos.json";
        List<Person> repository;
        ICommunication communicate;
        Communication comJSon = new Communication();
        public Repository()
        {
            communicate = comJSon;
            if (File.Exists(pathJson))
                repository = comJSon.GetRepository().ToList();
            else
            {
                repository = new List<Person>();
                GenerateRepository();
                UpdateRepository();
            }
        }
        public void UpdateRepository(List<Person> repos)
        {
            communicate.SendRepository(repos, pathJson);
        }
        public void UpdateRepository()
        {
            communicate.SendRepository(repository, pathJson);
        }
        public IEnumerable<Person> GetAll()
        {
            return (repository);
        }
        private void GenerateRepository()
        {
            repository.Add(new Person("Ivan", "8916-217-22-22"));
            repository.Add(new Person("Ivan", "8916-217-22-23"));
            repository.Add(new Person("Ivan", "8916-217-22-24"));
            repository.Add(new Person("Stepan", "8916-217-33-33"));
            repository.Add(new Person("Ilya", "8916-217-44-44"));
            repository.Add(new Person("WalkingDead", "8495-555-55-55"));
        }

    }
}
