using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidException
{
    public abstract class ExceptionHandleBase
    {
        protected readonly ILogger _logger;

        public ExceptionHandleBase(ILogger logger)
        {
            _logger = logger;
        }

        public abstract void HandleException<TException>(TException exception, Action action);
    }
}
