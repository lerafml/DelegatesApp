using DelegatesApp;
using System.Collections;
using System.Runtime.CompilerServices;

string path = Settings.Default.PathToFilesCatalog;
FileIterator fileIterator = new FileIterator();
Subscriber subscriber = new Subscriber();
fileIterator.FileFound += subscriber.OnDataReceived;
fileIterator.KeyPressed += subscriber.OnKeyPressed;
Task task = Task.Run(() => { fileIterator.Listen(); });
foreach (string fileName in Directory.GetFiles(path))
{
    if (!task.IsCompleted)
        fileIterator.FileCompletedEvent(new FileArgs { FileName = Path.GetFileNameWithoutExtension(fileName) });
}
 Console.WriteLine($"Максимальный элемент: {MyDelegateClass.GetMax<string>(subscriber.files, MyDelegateClass.convertToNumber)}");
fileIterator.FileFound -= subscriber.OnDataReceived;
fileIterator.KeyPressed -= subscriber.OnKeyPressed;

public class FileIterator
{
    public delegate void EventHandler(FileArgs e);
    public event EventHandler FileFound;
    public delegate void KeyPressedEventHandler();
    public event KeyPressedEventHandler KeyPressed;

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
}

public class Subscriber
{
    public List<string> files = new List<string>();
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