using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task6.model;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace task6.model
{
    /// <summary>
    /// 
    /// </summary>
    class EmployeeRepository:INotifyPropertyChanged
    {
        public EmployeeRepository()
        {
            ComWithFile = new Communication();
            CreateRepository();
        }
        List <ItemPerson> Repository=new List<ItemPerson>();

        public event PropertyChangedEventHandler PropertyChanged;
        ICommunication ComWithFile;
        public String Path { get; set; }
        private string message;
        public String Message { get { return (message); } set { message = value; OnPropertyChanged(); } }
        
        private void CreateRepository(string path=Settings.path)
        {
            string sTmp=ComWithFile.ReadDataFromFile();
            if (String.IsNullOrEmpty(sTmp))
                return;
            string[] asTmp = sTmp.Split('\n');
            foreach (var i in asTmp)
            {
                ItemPerson itemPersonTmp = GetItemPersonFromString(i);
                Repository.Add(itemPersonTmp);
            }

        }
        public List<ItemPerson> GetAll()
        {
            return (Repository);
        }

        public bool RemoveItemFromRepository(ItemPerson Person, string path = Settings.path)
        {
            
            if (Repository.Contains(Person))
            {
                Repository.Remove(Person);
                string sTmp = GetTextFromRepository();
                ComWithFile.WriteTextToFile(sTmp, false, path);
                return (true);
            }
            return (false);

        }
//check it later
        public bool RemoveItemFromRepository(int ID, string path=Settings.path)
        {
            ItemPerson personTmp=Repository.FirstOrDefault(i => i.ID == ID);
            if (personTmp!=default)
            {
                Repository.Remove(personTmp);
                string sTmp = GetTextFromRepository();
                ComWithFile.WriteTextToFile(sTmp,false,path);
                return (true);
            }
            return (false);

        }
        public bool AddItemToRepository(ItemPerson itPerson,string path=Settings.path)
        {
            if (!Repository.Contains(itPerson))
            {
                Repository.Add(itPerson);
                string sTmp = GetStringFromItemPerson(itPerson);
                ComWithFile.WriteTextToFile(sTmp, true, path);
                return (true);
            }
            Message = "The Repository already has the ID" + itPerson.ID.ToString();
            return (false);
        }
        public bool IsContainID(int ID)
        {
            ItemPerson personTmp = Repository.FirstOrDefault(i => i.ID == ID);
            return (Repository.Contains(personTmp));
        }

        private ItemPerson GetItemPersonFromString(string line)
        {
            if (String.IsNullOrEmpty(line))
                throw new ArgumentNullException("Person can't be null");
            string[] s = line.Split('#');
            int id = int.Parse(s[0]);
            DateTime dt = DateTime.Parse(s[1]);
            string fullName = s[2];
            int age = int.Parse(s[3]);
            int height = int.Parse(s[4]);
            DateTime bith = DateTime.Parse(s[5]);
            string placeBirth = s[6];
        return (new ItemPerson(fullName, age, height, bith, placeBirth, id, dt));
        }
        private string GetStringFromItemPerson(ItemPerson p)
        {
            string s = p.ID + "#" + p.CorrectionDateTime + "#" + p.FullName + "#" + p.Age + "#" + p.Height +
                "#" + p.BirthDay + "#" + p.PlaceOfBith;
            return (s);
        }
        private string GetTextFromRepository()
        {
            StringBuilder sbTmp = new StringBuilder();
            foreach(var i in Repository)
            {
                string sTmp = GetStringFromItemPerson(i);
                sbTmp.Append(sTmp + "\0");
            }
            return (sbTmp.ToString());
        }

        public ItemPerson GetItemPersonFromRepository(int ID)
        {
            return (Repository[ID]);
        }
        public void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
