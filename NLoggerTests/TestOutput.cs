using System;
using System.Collections.Generic;
using System.Text;
using NLogger;

namespace NLoggerTests
{
    public class TestOutput : ILoggerOutput
    {
        public void Log(LogType logType, string message)
        {
            throw new NotImplementedException(message);
        }
    }
}
