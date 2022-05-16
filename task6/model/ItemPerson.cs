using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6.model
{
    class ItemPerson:Person
    {
        // ID must be unique and obviousle shouldn't have SET. think over it later. 
        /// <summary>
        /// One item/string in a file/note
        /// </summary>
        int id;
        public int ID { get { return (id); } private set { id = value; } }
        public DateTime CorrectionDateTime { get;}

        public ItemPerson(string fullName, int age, int height,
            DateTime birthday, string placeOfBith, int id, DateTime correctionDateTime) : base(fullName, age, height, birthday, placeOfBith)
        {
            ID = id;
            CorrectionDateTime = correctionDateTime;
        }

        
        
    }
}
