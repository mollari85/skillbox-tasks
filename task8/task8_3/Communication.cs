using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace task8.task8_3
{
    class Communication
    {
        public void SendToFile(List<int> data, string path)
        {
            JsonSerializer jSerializer = new JsonSerializer();
            using (StreamWriter tw = new StreamWriter(path))
            using (JsonTextWriter jWriter = new JsonTextWriter(tw))
            {
                jSerializer.Serialize(jWriter, data);
            }
        }

        public  List<int> GetFromFile(string path)
        {
            List<int> result;
            if (!File.Exists(path))
            {
                result = new List<int>();
                return (result);
            }
            using (TextReader tr = new StreamReader(path))
            {
                result=JsonConvert.DeserializeObject<List<int>>(tr.ReadToEnd());
            }
            return (result);
        }
    }
}
