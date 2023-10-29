using SolidExceptionDZ.Abstraction;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Commands
{
    public class RepeaterCommand : IInject<ICommand>
    {
        private readonly BlockingCollection<ICommand> _commands;
        private ICommand _command;

        public RepeaterCommand(ICommand command, BlockingCollection<ICommand> commands)
        {
            _command = command;
            _commands = commands;
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
            _commands.Add(_command);
        }
    }
}
