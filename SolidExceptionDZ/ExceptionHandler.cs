using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidExceptionDZ.Abstraction;
using SolidExceptionDZ.Commands;

namespace SolidExceptionDZ
{
    public class ExceptionHandler
    {
        private readonly Dictionary<Type, ICommand> _exceptionHandlerStore = new Dictionary<Type, ICommand>();
        private readonly ICommand _command;

        public ExceptionHandler(ICommand command)
        {
            _command = command;
        }

        public void Handle(Exception exception)
        {
            if (!_exceptionHandlerStore.TryGetValue(exception.GetType(), out var command))
            {
                return;
            }


            if(command is IInject<Exception> inject)
            {
                inject.Inject = exception;
                _command.Invoke();
            }
            return;
        }

        public void RegisterHandler(Type key, ICommand value)
        {
            _exceptionHandlerStore.Add(key, value);
        }
    }
}
