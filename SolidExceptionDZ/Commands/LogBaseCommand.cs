using SolidExceptionDZ.Abstraction;
using SolidExceptionDZ.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Commands
{
    public abstract class LogBaseCommand : IInject<Exception>
    {
        protected Exception _logInfo;
        protected readonly ILogger _logger;

        public Exception Inject { set => _logInfo = value; }

        public LogBaseCommand(Exception exception, ILogger logger)
        {
            _logInfo = exception;
            _logger = logger;
        }

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

        public abstract void Invoke();
    }
}
