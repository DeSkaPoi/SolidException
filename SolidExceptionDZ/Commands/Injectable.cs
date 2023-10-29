using SolidExceptionDZ.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Commands
{
    public class Injectable : IInject<ICommand>
    {
        private ICommand _command;

        public Injectable(ICommand command)
        {
            _command = command;
        }

        public ICommand Inject { set => _command = value; }

        public bool CanExecute()
        {
            try
            {
                Invoke();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Invoke()
        {
            _command.Invoke();
        }
    }
}
