using System;
using System.Collections.Generic;
using System.Text;
using NLogger;

namespace NLoggerTests
{
    public class TestLogFormater : ILogFormater
    {
        public string Format(LogType logType, string message)
        {
            throw new NotImplementedException(message);
        }
    }
}
