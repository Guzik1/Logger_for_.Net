using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    public class DefaultFileFormater : ILogFormater
    {
        public string Format(LogType logType, string message)
        {
            DefaultConsoleFormater dcf = new DefaultConsoleFormater();

            if (logType == LogType.FatalError || logType == LogType.Error)
                message = message.ToUpper();

            return $"{ logType.ToString() }: { dcf.Format(logType, message) }";
        }
    }
}
