﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidException.Handlers
{
    public class NullReferenceExceptionHandle : ExceptionHandleBase
    {
        public NullReferenceExceptionHandle(ILogger logger) : base(logger)
        {
        }

        public override void HandleException<TException>(TException exception, Action action)
        {
            _logger.LogWarning($"Не найден соответсующий обработчик для ошибки: {exception} в методе {action.Method}");
        }
    }
}
