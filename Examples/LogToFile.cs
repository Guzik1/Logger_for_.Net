using NLogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class LogToFile
    {
        public void Example()
        {
            string path = @"C://logs/log.txt";

            Logger logger = new Logger();
            logger.AddOutput(new FileOutput(path), new DefaultFileFormater());
            // or //
            logger = new Logger(new FileOutput(path), new DefaultFileFormater());

            logger.Info("Info");  // Log info layer.

            logger.FatalError("Aplication can be stoped!");   // Log on error layer.

            logger.Log(LogType.Warning, "warning message ...");  // basic log method, select message layer and set message.

        }
    }
}
