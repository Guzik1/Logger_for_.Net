using System;
using System.Collections.Generic;
using System.Text;
using NLogger;

namespace Examples
{
    public class LogToOwnOutput
    {
        public void Example()
        {
            Logger logger = new Logger();
            logger.AddOutput(new OwnConsoleOutput(), new DefaultConsoleFormater());

            logger.Info("Info in own consol output.");  // Log on info layer.

            logger.Debug("test");

            logger.Log(LogType.Warning, "warning message ...");  // basic log method, select message layer and set message.

        }
    }

    public class OwnConsoleOutput : ILoggerOutput
    {
        public void Log(LogType logType, string message)
        {
            Console.WriteLine(message);
        }
    }
}
