using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp
{
    public class KeyListener
    {
        public delegate Task KeyEventHandler();
        public event KeyEventHandler KeyPressed;
        public bool exit = false;

        public async Task Listen()
        {
            await Task.Run(() =>
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (Console.ReadKey(true).Key == ConsoleKey.End)
                {
                    exit = true;
                }
            });
            KeyPressed?.Invoke();
        }
    }
}
