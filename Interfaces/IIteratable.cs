using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp.Interfaces
{
    public interface IIteratable : IDisposable
    {
        void Iterate();
    }
}
