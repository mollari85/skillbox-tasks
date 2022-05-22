using System;
using System.Linq;
using System.Text;
using task6.model;
using task6.Tools;


namespace task6.VM
{
    class ControllerRepos : ICommandConsole
    {
        const int idLen = 3, dTLen = 15, fIOLen = 15, ageLen = 4, heightLen = 7, birthLen = 10, placeOfBirthLen = 15;
        EmployeeRepository Note;
        //string Path { get; set; }
        //string Message { get; set; }

        public ControllerRepos()
        {
            Note = new EmployeeRepository();
            ShowAllCommand = new RelayCommand(ShowAllInConsoleCommandTest);
            ShowAllOrderedCommand = new RelayCommand(ShowAllInConsoleOrderedTest);
            ShowAllInConsoleInRangeCommand = new RelayCommand(ShowAllConsoleInRangeTest);

        }
        private string TextHead()
        {
            string result = ($"{"ID",idLen}|{"Date and Time",dTLen}|{"FullName",fIOLen}|{"Age",ageLen}|{"Height",heightLen}|{"Birthday",birthLen}|{"Place of Birth",placeOfBirthLen}|\n\r");
            result += (new string('-', 75) + "\n\r");
            return (result);
        }
        private string TextPerson(ItemPerson i)
        {

            string result=(($"{i.ID,idLen}|{i.CorrectionDateTime.ToShortDateString(),dTLen}|{i.FullName,fIOLen}|{i.Age,ageLen}|" +
                   $"{i.Height,heightLen}|{i.BirthDay.ToShortDateString(),birthLen}|{i.PlaceOfBith,placeOfBirthLen}|\n\r"));

            return (result);
        }
        public RelayCommand ShowAllCommand;
        public RelayCommand ShowAllOrderedCommand;
        public RelayCommand ShowAllInConsoleInRangeCommand;
        public string ShowAllInConsole()
        {
            StringBuilder result = new StringBuilder();
            result.Append(TextHead());
            foreach (var i in Note.GetAll())
            {
                ItemPerson Person = i as ItemPerson;
                result.Append(TextPerson(Person));
            }

            return (result.ToString());
        }
        public void ShowAllInConsoleCommandTest(object o=null)
        {
            Console.WriteLine(ShowAllInConsole());
        }
        public void ShowAllInConsoleOrderedTest(object o = null)
        {
            Console.WriteLine(ShowAllInConsoleOrdered());
        }
        public string ShowAllConsoleInRangeTest(object TextStart, object TextEnd)
        {
            string result=ShowAllInConsoleInRange(TextStart.ToString(), TextEnd.ToString());
            return (result);
        }
        public string ShowAllInConsoleOrdered()
        {
            StringBuilder result = new StringBuilder();
            result.Append(TextHead());
            var OrderedNote = Note.GetAll().OrderByDescending(i => i.CorrectionDateTime).Reverse();
            foreach (var i in OrderedNote)
            {
                ItemPerson Person = i as ItemPerson;
                result.Append(TextPerson(Person));
            }

            return (result.ToString());

        }
        public DateTime CheckingDateTime(string text)
        {
            if (!DateTime.TryParse(text, out DateTime dt))
                throw new ArgumentException($"The text {text} doesn't look like  date and time");
            return (dt);

        }
        public string ShowAllInConsoleInRange(DateTime StartDate, DateTime EndDate)
        {
            StringBuilder result = new StringBuilder();
            result.Append(TextHead());
            var RangeNote = Note.GetAll().Where(i => (i.CorrectionDateTime>=StartDate)& 
            i.CorrectionDateTime<=EndDate);
            foreach (var i in RangeNote)
            {
                ItemPerson Person = i as ItemPerson;
                result.Append(TextPerson(Person));
            }

            return (result.ToString());

        }
        public string ShowAllInConsoleInRange(string TextStartDate, string TextEndDate)
        {
            DateTime StartDate=CheckingDateTime(TextStartDate);
            DateTime EndDate = CheckingDateTime(TextEndDate);
            return(ShowAllInConsoleInRange(StartDate, EndDate));
        }

        public int? ID { get; set; }
        public DateTime? CorrectionDateTime { get; set;}
        public string FullName { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public DateTime? BirthDay { get; set; }
        public string PlaceOfBirth { get; set; }

        public DateTime SetDateTime()
        {
            return (DateTime.Now);
        }
        public void CancelAddingPerson()
        {
            ID = null;
            FullName = null;
            Age = null;
            Height = null;
            BirthDay = null;
            PlaceOfBirth = null;
        }
        public void AddPerson()
        {
            Note.AddItemToRepository(new ItemPerson(FullName,Age.Value,Height.Value,BirthDay.Value,PlaceOfBirth,ID.Value,DateTime.Now));
        }
        public void RemoveAtPerson(string text)
        {
            if(!int.TryParse(text, out int iD))
                throw new ArgumentException($"Text {text} doesn't look like ID");
            if (!Note.IsContainID(iD))           
                throw new ArgumentException($"Dictionary doesn't contain ID={iD}");
            Note.RemoveItemFromRepository(iD);                      
        }
        public void EditAtPerson(string text)
        {
            if (!int.TryParse(text, out int id))
            {
                throw new ArgumentException($"The {text} can not be ID");
            }
            if (!CheckID(id))
            {
                throw new ArgumentException($"There is no ID {id.ToString()} in database");
            }
            
            ShowTempPerson(id.ToString());
            RemoveAtPerson(id.ToString());
        }
        private bool CheckID(int id)
        {
            if (!Note.IsContainID(id))
            {
                throw new ArgumentException($"There is no ID {id.ToString()} in database");
            }
            return (true);
        }
        public void SetID(string text)
        {
            if (!int.TryParse(text, out int id))
            {
                throw new ArgumentException($"The {text} can not be ID");
            }
            if (Note.IsContainID(id))
            {            
                throw new ArgumentException($"The ID {id.ToString()} is not available");                
            }
            else
            {
                ID = id;
            }           
        }        
        public void SetFullName(string text)
        {
            text = text.Trim(' ');
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Full name can't be empty");
            }
            #region  make FullName firts letter with upper case and rest part with low case

            string[] sTmp = text.Split(' ');
            string result = null;
            for (int i = 0; i < sTmp.Length; i++)
            {
                if (sTmp[i].Length > 1)
                {
                    result += sTmp[i].Substring(0, 1).ToUpper() + sTmp[i].Substring(1).ToLower();
                }
            }
            #endregion
            FullName = result;
        }
        public void SetAge(string text)
        {
            if (!Int32.TryParse(text, out int age))
            {
                throw new ArgumentException($"The text {text} doesn't look like an age");
            }
            if ((age > 120) | (age <= 0))
            {
                throw new ArgumentException($"The age={text} can't be less or equal 0 and more than 120");
            }
            this.Age = age;
           
        }
        public void SetHeight(string text)
        {
            if (!Int32.TryParse(text, out int height))
                throw new ArgumentException($"The text {height} doesn't look like an height");
            if ((height<20)|(height>240))
                throw new ArgumentException($"The height={height} can't be less than 20 and more than 240");
            this.Height = height;
        }
        public void SetBirthday(string text)
        {
            if(!DateTime.TryParse(text,out DateTime birthday))
                throw new ArgumentException($"The text {text} doesn't look like  date and time");
            if ((DateTime.Now.Year-birthday.Year)>120)
                throw new ArgumentException($"The birthday={birthday} can't be so old");
            this.BirthDay = birthday;
        }
        public void SetPlaceOfBirth(string text)
        {
            text = text.Trim(' ');
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Place of birth can't be empty");
            }
            #region  make Place of birth firts letter with upper case and rest part with low case  like Saunt Louse

            string[] sTmp = text.Split(' ');
            string result = null;
            for (int i = 0; i < sTmp.Length; i++)
            {
                if (sTmp[i].Length > 1)
                {
                    result += sTmp[i].Substring(0, 1).ToUpper() + sTmp[i].Substring(1).ToLower();
                }
            }
            #endregion
            this.PlaceOfBirth = result;
        }
        public string ShowTempPerson()
        {
            string sDT = (BirthDay is null) ? null : BirthDay.Value.ToShortDateString();
            return ((($"{ID,idLen}|{SetDateTime().ToShortDateString(),dTLen}|{FullName,fIOLen}|{Age,ageLen}|" +
                    $"{Height,heightLen}|{sDT,birthLen}|{PlaceOfBirth,placeOfBirthLen}|")));
        }
        public string ShowTempPerson(string textId)
        {
            if (!int.TryParse(textId, out int id))
            {
                throw new ArgumentException($"The {textId} can not be ID");
            }
            if (!Note.IsContainID(id))
            {
                throw new ArgumentException($"There is no person with ID={id.ToString()}");
            }
            ItemPerson PersonTmp=Note.GetItemPersonFromRepository(id);
            ID = PersonTmp.ID;
            CorrectionDateTime = PersonTmp.CorrectionDateTime;
            FullName =PersonTmp.FullName;
            Age = PersonTmp.Age;
            Height = PersonTmp.Height;
            BirthDay =PersonTmp.BirthDay;
            PlaceOfBirth = PersonTmp.PlaceOfBith;

            return (ShowTempPerson());
            
        }
    }
}
