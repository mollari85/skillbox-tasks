using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace task8.task8_2
{
    class Communication:ICommunication
    {
        public const string pathJson="JsonRepos.json";

        public IEnumerable<Person> GetRepository(string path=pathJson)
        {
            IEnumerable<Person> Result = null;
            try
            {

                JsonSerializer jSerializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(path))
                using (JsonReader jReader = new JsonTextReader(sr))
                { 
                     Result = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
                }             
            }
            catch (Exception e) { }
            return (Result);
        }

        public void SendRepository(IEnumerable<Person> repository, string path=pathJson)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter jWriter = new JsonTextWriter(sw))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(jWriter, repository);
                }
            }
            catch (Exception e){ }
        }
    }
}
