using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    public interface ILogFormater
    {
        public string Format(LogType logType, string message);
    }
}
