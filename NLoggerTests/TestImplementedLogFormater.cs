using System;
using System.Collections.Generic;
using System.Text;
using NLogger;

namespace NLoggerTests
{
    public class TestImplementedLogFormater : ILogFormater
    {
        public string Format(LogType logType, string message)
        {
            return $"{ logType.ToString() }: { message }";
        }
    }
}
