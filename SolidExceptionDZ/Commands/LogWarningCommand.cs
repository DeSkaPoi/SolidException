using SolidExceptionDZ.Abstraction;
using SolidExceptionDZ.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Commands
{
    public class LogWarningCommand : LogBaseCommand
    {
        public LogWarningCommand(Exception exception, ILogger loger) : base(exception, loger)
        {
        }

        public override void Invoke()
        {
            _logger.LogWarning(_logInfo.Message);
        }
    }
}
