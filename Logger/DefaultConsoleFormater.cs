using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    public class DefaultConsoleFormater : ILogFormater
    {
        public string Format(LogType logType, string message)
        {
            DateTime dt = DateTime.Now;

            string messageFormat = $"{ dt.Hour }:{ dt.Minute }:{ dt.Second } - { message }";

            return messageFormat;
        }
    }
}
