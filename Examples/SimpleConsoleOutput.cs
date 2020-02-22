using System;
using NLogger;

namespace Examples
{
    public class SimpleConsoleOutput
    {
        public void Example()
        {
            Logger logger = new Logger();
            logger.AddDefaultConsoleOutputAndDefaultConsoleFormater();   // add default console output and console formater to logger

            logger.Info("Info");  // Log info layer.

            bool condition = true;
            logger.Info("Condition: {0}", condition.ToString());  // Log info.

            logger.Error("Error ...");   // Log on error layer.

            logger.Log(LogType.Warning, "warning message ...");  // basic log method, select message layer and set message.
        }
    }
}
