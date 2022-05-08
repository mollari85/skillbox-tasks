using System;
using System.Text;
using task6.model;


namespace task6.VM
{
    class ControllerNote
    {
        const int idLen = 3, dTLen = 15, fIOLen = 15, ageLen = 4, heightLen = 7, birthLen = 10, placeOfBirthLen = 15;
        ItemsNote Note;
        string Path { get; set; }
        string Message { get; set; }

        public ControllerNote()
        {
            Note = new ItemsNote();

        }
        public string ShowdataInConsole()
        {
            StringBuilder result = new StringBuilder();
            string sTmp;
            sTmp = ($"{"ID",idLen}|{"Date and Time",dTLen}|{"FIO",fIOLen}|{"Age",ageLen}|{"Height",heightLen}|{"Birthday",birthLen}|{"Place of Birth",placeOfBirthLen}|\n\r");
            sTmp += (new string('-', 75) + "\n\r");
            result.Append(sTmp);
            foreach (var i in Note.GetDictinary())
            {
                result.Append(($"{i.Value.ID,idLen}|{i.Value.CorrectionDateTime.ToShortDateString(),dTLen}|{i.Value.FullName,fIOLen}|{i.Value.Age,ageLen}|" +
                    $"{i.Value.Height,heightLen}|{i.Value.BirthDay.ToShortDateString(),birthLen}|{i.Value.PlaceOfBith,placeOfBirthLen}|\n\r"));

            }
            
            return (result.ToString());
        }

        UInt32? ID;       
        string FIO;
        int? age;
        int? height;
        DateTime? birthDay;
        String placeOfBirth;
        public DateTime SetDateTime()
        {
            return (DateTime.Now);
        }

        public void CancelAddingPerson()
        {
            ID = null;
            FIO = null;
            age = null;
            height = null;
            birthDay = null;
            placeOfBirth = null;
        }
        public void AddPerson()
        {
            Note.AddItemToDictinary(new ItemPerson(FIO,age.Value,height.Value,birthDay.Value,placeOfBirth,ID.Value,DateTime.Now));
        }
        public void RemoveAtPerson(string text)
        {
            if(!UInt32.TryParse(text, out UInt32 iD))
                throw new ArgumentException($"Text {text} doesn't look like ID");
            if (!Note.IsContainID(iD))           
                throw new ArgumentException($"Dictionary doesn't contain ID={iD}");
            Note.RemoveItemFromDictinary(iD);                      
        }
        public void SetID(string text)
        {
            if (!UInt32.TryParse(text, out UInt32 id))
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
            #region  make FIO firts letter with upper case and rest part with low case

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
            FIO = result;
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
            this.age = age;
           
        }
        public void SetHeight(string text)
        {
            if (!Int32.TryParse(text, out int height))
                throw new ArgumentException($"The text {height} doesn't look like an height");
            if ((height<20)|(height>240))
                throw new ArgumentException($"The height={height} can't be less than 20 and more than 240");
            this.height = height;
        }
        public void SetBirthday(string text)
        {
            if(!DateTime.TryParse(text,out DateTime birthday))
                throw new ArgumentException($"The text {text} doesn't look like  date and time");
            if ((DateTime.Now.Year-birthday.Year)>120)
                throw new ArgumentException($"The birthday={birthday} can't be so old");
            this.birthDay = birthday;
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
            this.placeOfBirth = result;
        }
        public string ShowTempPerson()
        {
            string sDT = (birthDay is null) ? null : birthDay.Value.ToShortDateString();
            return ((($"{ID,idLen}|{SetDateTime().ToShortDateString(),dTLen}|{FIO,fIOLen}|{age,ageLen}|" +
                    $"{height,heightLen}|{sDT,birthLen}|{placeOfBirth,placeOfBirthLen}|")));
        }
    }
}
