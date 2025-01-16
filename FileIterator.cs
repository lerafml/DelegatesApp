using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp
{
    public class FileIterator
    {
        private string path = Settings.Default.PathToFilesCatalog;
        //private readonly KeyListener listener;
        private List<string> files;
        public delegate void EventHandler(object sender, FileArgs e);
        public event EventHandler FileFound;

        public FileIterator(KeyListener _listener)
        {
            //listener = _listener;
            files = new List<string>();
            //listener.KeyPressed += OnKeyPressed;
        }

        public async void FileCompletedEvent(object sender, FileArgs e)
        {
            //await listener.Listen();

            //foreach (string fileName in Directory.GetFiles(path))
            //{
            //    if (listener.exit)
            //        break;
            //    e.FileName = Path.GetFileNameWithoutExtension(fileName);
            //    files.Add(e.FileName);
            //    Console.WriteLine($"Найден файл {e.FileName}");
            //    FileFound?.Invoke(this, e);
            //}
            Console.WriteLine("Нажмите пробел для остановки...");
            
            foreach (string fileName in Directory.GetFiles(path))
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    break;
                e.FileName = Path.GetFileNameWithoutExtension(fileName);
                files.Add(e.FileName);
                Console.WriteLine($"Найден файл {e.FileName}");
                FileFound?.Invoke(this, e);
            }
        }

        //public async Task OnKeyPressed()
        //{
        //    string maxFile = MyDeledateClass.GetMax<string>(files, MyDeledateClass.convertToNumber);
        //    Console.WriteLine($"Поиск окончен. Максимальный элемент: {maxFile}");
        //    listener.KeyPressed -= OnKeyPressed;
        //}
    }
}
