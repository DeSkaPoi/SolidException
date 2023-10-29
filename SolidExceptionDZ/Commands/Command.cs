using SolidExceptionDZ.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Commands
{
    public class Command : IInject<Action>
    {
        private Action _command;
        public Command(Action action) => _command = action;

        public Action Inject { set => _command = value; }

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
