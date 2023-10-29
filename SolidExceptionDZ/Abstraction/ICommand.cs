using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Abstraction
{
    public interface ICommand 
    {
        bool CanExecute();
        void Invoke();
    }
}
