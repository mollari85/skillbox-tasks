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
        UInt32 id;
        public UInt32 ID { get { return (id); } private set { id = value; } }
        public DateTime CorrectionDateTime { get;}

        public ItemPerson(string fullName, int age, int height,
            DateTime birthday, string placeOfBith, UInt32 id, DateTime correctionDateTime) : base(fullName, age, height, birthday, placeOfBith)
        {
            ID = id;
            CorrectionDateTime = correctionDateTime;
        }

        
        
    }
}
