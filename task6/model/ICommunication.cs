using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace task6.model
{
    public interface ICommunication
    {
        event PropertyChangedEventHandler PropertyChanged;
        string Message { get; set;}
        string ReadDataFromFile(string path = "Notes.txt");
        /// <summary>
        /// Write a text to file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="Append">true add the text to file, false re-write the file></param>
        /// <param name="path"></param>
        void WriteTextToFile(string text, bool Append, string path = "Notes.txt");
    }
}
