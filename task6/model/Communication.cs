using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace task6.model
{
    class Communication:ICommunication
    {
            
            public event PropertyChangedEventHandler PropertyChanged;
            private string message;
            public String Message { get { return (message); } set { message = value; OnPropertyChanged(); } }
            public string ReadDataFromFile(string path = "Notes.txt")
            {
                int i = 0;
                StringBuilder sbText = new StringBuilder();
            if (!File.Exists(path))
                File.CreateText(path);
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {                            
                    while (!sr.EndOfStream)
                    {
                        try
                        {

                        sbText.Append(sr.ReadLine()+"\n");

                        }
                        catch (Exception) { Message += $"String {i} is not readable \n\r"; }
                        finally { i++; }
                    }
                sbText.Remove(sbText.Length-1, 1);
                }
            return (sbText.ToString());
            }
        /// <summary>
        /// Write a text to file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="Append">true add the text to file, false re-write the file></param>
        /// <param name="path"></param>
            public void WriteTextToFile(string text,bool Append, string path = "Notes.txt")
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, Append, Encoding.UTF8))
                    {

                      sw.WriteLine(text);
                    }
                }
                catch (Exception) { Message = "Can't write to the file"; }
            }
            public void OnPropertyChanged([CallerMemberName]string PropertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
            

    }
    
}
