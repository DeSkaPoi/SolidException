using SolidExceptionDZ.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Commands
{
    public class MacroCommand : ICommand
    {
        private readonly IReadOnlyList<ICommand> _value;
        public MacroCommand(IReadOnlyList<ICommand> value) => _value = value;

        public bool CanExecute()
        {
            return true;
        }

        public void Invoke()
        {
            foreach (var command in _value) 
            {
                command.Invoke();
            }
        }
    }
}
