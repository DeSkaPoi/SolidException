using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidException.Handlers;

namespace SolidException
{
    public class ExceptionHandler
    {
        private readonly NotFindExceptionHandle _notFindExceptionHandle;
        private readonly Dictionary<Type, ExceptionHandleBase> _exceptionHandlerStore = new Dictionary<Type, ExceptionHandleBase>();

        public ExceptionHandler(NotFindExceptionHandle notFindExceptionHandle)
        {
            _notFindExceptionHandle = notFindExceptionHandle;
        }

        public void Handle(Type exception, Action action)
        {
            if(!_exceptionHandlerStore.TryGetValue(exception, out var command))
            {
                command = _notFindExceptionHandle;
            }

            command.HandleException(exception, action);
        } 

        public void RegisterHandler(Type key, ExceptionHandleBase value)
        {
           _exceptionHandlerStore.Add(key, value);
        }
    }
}
