using DelegatesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp
{
    public class Subscriber : ISubscriber
    {
        public List<string> files = new List<string>();

        public List<string> GetData()
        {
            return files;
        }

        public void OnDataReceived(FileArgs e)
        {
            files.Add(e.FileName);
            Console.WriteLine($"Имя файла: {e.FileName}");
        }

        public void OnKeyPressed()
        {
            Console.WriteLine("Нажата клавиша ESC");
        }
    }
}
