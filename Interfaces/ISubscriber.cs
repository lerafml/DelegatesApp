using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp.Interfaces
{
    public interface ISubscriber
    {
        List<string> GetData();
        void OnDataReceived(FileArgs e);
        void OnKeyPressed();
    }
}
