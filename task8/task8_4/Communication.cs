using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace task8.task8_4
{
    class Communication : ICommunication
    {

        private string _Path { get; set; }
        public Communication(string path)
        {
            if (File.Exists(path))
                _Path = path;
            else
                _Path = "xmlPerson.xml";
     
        }
        public IEnumerable<Person> GetFromFile()
        {
            List<Person> ResultList = new List<Person>();
            XDocument xDoc = XDocument.Load(_Path);                        
            XElement xRoot = xDoc.Root;
           
            var RootElementTmp=xRoot.Elements();
            if (RootElementTmp == null)
                return (null);
            foreach (XElement iElement in RootElementTmp)
            {
                Person PersonTmp = new Person();
                PersonTmp.Name = iElement.Attribute(nameof(PersonTmp.Name)).Value;
                {
                    XElement xElementAddress= iElement.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Address));
                    PersonTmp.Address.Street = xElementAddress.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Address.Street)).Value;
                    PersonTmp.Address.HouseNumber= int.Parse(xElementAddress.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Address.HouseNumber)).Value);
                    PersonTmp.Address.FlatNumber = Convert.ToInt32(xElementAddress.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Address.FlatNumber)).Value);

                    XElement xElementPhones = iElement.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Phones));
                    PersonTmp.Phones.FlatPhone = xElementPhones.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Phones.FlatPhone)).Value;
                    PersonTmp.Phones.MobilePhone = xElementPhones.Elements().FirstOrDefault(x => x.Name == nameof(PersonTmp.Phones.MobilePhone)).Value;
                }

                ResultList.Add(PersonTmp);
            }           
            return (ResultList);
            
        }
        public IEnumerable<Person> GetFromFile(string plug)
        {
            List<Person> ResultList = new List<Person>();
            
            XmlDocument xmlDoc =new  XmlDocument();
            xmlDoc.Load(_Path);
            XmlElement RootElement = xmlDoc.DocumentElement;
            if (RootElement == null)
                return(ResultList);
            foreach (XmlElement iXmlElement in RootElement)
            {
                Person PersonTmp = new Person();
                PersonTmp.Name = iXmlElement.GetAttribute(nameof(Person.Name));

                var AddressTmp=iXmlElement.SelectSingleNode(nameof(Person.Address));
                PersonTmp.Address.Street= AddressTmp.SelectSingleNode(nameof(Person.Address.Street)).InnerText;
                PersonTmp.Address.FlatNumber = int.Parse(AddressTmp.SelectSingleNode(nameof(Person.Address.FlatNumber)).InnerText);
                PersonTmp.Address.HouseNumber = int.Parse(AddressTmp.SelectSingleNode(nameof(Person.Address.HouseNumber)).InnerText);

                var PhonesTmp = iXmlElement.SelectSingleNode(nameof(Person.Phones));
                PersonTmp.Phones.FlatPhone = PhonesTmp.SelectSingleNode(nameof(Person.Phones.FlatPhone)).InnerText;
                PersonTmp.Phones.MobilePhone = PhonesTmp.SelectSingleNode(nameof(Person.Phones.MobilePhone)).InnerText;

                ResultList.Add(PersonTmp);
            }
            return (ResultList);
        }
        public IEnumerable<Person> GetFromFileSer()
        {
            List<Person> ResultList = new List<Person>();
            XmlSerializer SerializerXml = new XmlSerializer(typeof(List<Person>));
            if (!File.Exists(_Path))
                return (ResultList);
                      
            using (FileStream fs = new FileStream(_Path,FileMode.Open))
            {
                     ResultList = SerializerXml.Deserialize(fs) as List<Person>;
            }
            return (ResultList);
        }
        public void SendToFile(IEnumerable<Person> PersonList,string plug)
        {

            XmlSerializer SerializerXml = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream(_Path, FileMode.OpenOrCreate))
            {
                SerializerXml.Serialize(fs,PersonList);
            }

        }
        public void SendToFile(IEnumerable<Person> PersonList)
        {
            XElement RootElement = new XElement("Root");
            foreach (var iPerson in PersonList)
            {
                RootElement.Add(PersonToXElement(iPerson));

            }
            XDocument xDoc = new XDocument();
            xDoc.Add(RootElement);
            xDoc.Save(_Path);
        }
        private XElement PersonToXElement(Person PersonIn)
        {
            
            XElement mainElement = new XElement(nameof(Person).ToString());
           // XAttribute mainAttribute = new XAttribute("name",PersonIn.Name);           
            XElement AddressElement = new XElement(nameof(PersonIn.Address).ToString());
                 AddressElement.Add(new XElement(nameof(PersonIn.Address.Street), PersonIn.Address.Street));
                 AddressElement.Add(new XElement(nameof(PersonIn.Address.FlatNumber), PersonIn.Address.FlatNumber.ToString()));
                 AddressElement.Add(new XElement(nameof (PersonIn.Address.HouseNumber), PersonIn.Address.HouseNumber.ToString()));
            XElement PhonesElement = new XElement(nameof(PersonIn.Phones).ToString());
                PhonesElement.Add(new XElement(nameof(PersonIn.Phones.FlatPhone), PersonIn.Phones.FlatPhone));
                PhonesElement.Add(new XElement(nameof(PersonIn.Phones.MobilePhone), PersonIn.Phones.MobilePhone));          
            mainElement.SetAttributeValue(nameof(PersonIn.Name), PersonIn.Name);
            mainElement.Add(AddressElement);
            mainElement.Add(PhonesElement);

            return (mainElement);
        }
    }
}
