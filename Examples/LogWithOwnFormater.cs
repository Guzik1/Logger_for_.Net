using NLogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class LogWithOwnFormater
    {
        public void Example()
        {
            Logger logger = new Logger();
            logger.AddOutput(new ConsoleOutput, new OwnFormater());  // Add default console output with own formater. 

            logger.Info("Info in consol with own foramter.");  // Log on info layer.

            logger.FatalError("Aplication can be stoped!");   // Log on error layer.

            logger.Debug("Method run.");

            logger.Log(LogType.Warning, "warning message ...");  // basic log method, select message layer and set message.
        }
    }

    public class OwnFormater : ILogFormater
    {
        public string Format(LogType logType, string message)
        {
            return $"Own formater ({ logType.ToString() }): { message }";
        }
    }
}
