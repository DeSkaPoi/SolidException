using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Abstraction
{
    public interface IAddInQueueCommand<T> : ICommand, IInject<T>
    {
    }
}
