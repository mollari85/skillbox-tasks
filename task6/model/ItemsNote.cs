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
    class ItemsNote:INotifyPropertyChanged
    {
        public ItemsNote()
        {
            ComWithFile = new Communication();
            CreateDictionary();
        }
        Dictionary<UInt32, ItemPerson> MyDictinary=new Dictionary<uint, ItemPerson>();

        public event PropertyChangedEventHandler PropertyChanged;
        ICommunication ComWithFile;
        public String Path { get; set; }
        private string message;
        public String Message { get { return (message); } set { message = value; OnPropertyChanged(); } }
        
        private void CreateDictionary(string path=Settings.path)
        {
            string sTmp=ComWithFile.ReadDataFromFile();
            if (String.IsNullOrEmpty(sTmp))
                return;
            string[] asTmp = sTmp.Split('\n');
            foreach (var i in asTmp)
            {
                ItemPerson itemPersonTmp = GetItemPersonFromString(i);
                MyDictinary.Add(itemPersonTmp.ID, itemPersonTmp);
            }

        }
        public Dictionary<UInt32, ItemPerson> GetDictinary()
        {
            return (MyDictinary);
        }

        public bool RemoveItemFromDictinary(UInt32 i, string path=Settings.path)
        {
            if (MyDictinary.ContainsKey(i))
            {
                MyDictinary.Remove(i);
                string sTmp = GetTextFromDictinary();
                ComWithFile.WriteTextToFile(sTmp,false,path);
                return (true);
            }
            return (false);

        }
        public bool AddItemToDictinary(ItemPerson itPerson,string path=Settings.path)
        {
            if (!MyDictinary.ContainsKey(itPerson.ID))
            {
                MyDictinary.Add(itPerson.ID, itPerson);
                string sTmp = GetStringFromItemPerson(itPerson);
                ComWithFile.WriteTextToFile(sTmp, true, path);
                return (true);
            }
            Message = "The Dictinary already has the ID" + itPerson.ID.ToString();
            return (false);
        }
        public bool IsContainID(UInt32 id)
        {
            return(MyDictinary.ContainsKey(id));
        }

        private ItemPerson GetItemPersonFromString(string line)
        {
            if (String.IsNullOrEmpty(line))
                throw new ArgumentNullException("Person can't be null");
            string[] s = line.Split('#');
            UInt32 id = UInt32.Parse(s[0]);
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
        private string GetTextFromDictinary()
        {
            StringBuilder sbTmp = new StringBuilder();
            foreach(var i in MyDictinary)
            {
                string sTmp = GetStringFromItemPerson(i.Value);
                sbTmp.Append(sTmp + "\0");
            }
            return (sbTmp.ToString());
        }
        public void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
