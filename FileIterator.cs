using DelegatesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp
{
    public class FileIterator : IIteratable, IWaiter
    {
        private string path = Settings.Default.PathToFilesCatalog;
        private ISubscriber subscriber;
        public delegate void EventHandler(FileArgs e);
        public event EventHandler FileFound;
        public delegate void KeyPressedEventHandler();
        public event KeyPressedEventHandler KeyPressed;

        public FileIterator(ISubscriber _subscriber)
        {
            subscriber = _subscriber;
            FileFound += subscriber.OnDataReceived;
            KeyPressed += subscriber.OnKeyPressed;
        }
        public void Iterate()
        {
            Task task = Task.Run(() => { Listen(); });
            foreach (string fileName in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                if (task.IsCompleted) break;
                FileCompletedEvent(new FileArgs { FileName = Path.GetFileNameWithoutExtension(fileName) });
            }
        }

        public void FileCompletedEvent(FileArgs e)
        {
            Console.WriteLine("Найден файл!");
            FileFound?.Invoke(e);
        }

        public void Listen()
        {
            Console.WriteLine("Нажмите ESC для остановки...");
            do { } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            KeyPressed?.Invoke();
        }

        public void Dispose()
        {
            Console.WriteLine($"Максимальный элемент: {subscriber.GetData().GetMax<string>(MyDelegateClass.convertToNumber)}");
            FileFound -= subscriber.OnDataReceived;
            KeyPressed -= subscriber.OnKeyPressed;
        }
    }
}
