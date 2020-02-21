using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    public interface ILoggerOutput
    {
        public void Log(LogType logType, string message);
    }
}
