using NLogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class LogToMultiFile
    {
        // Changes in incjalization field.
        public void Example()
        {
            string directory = @"C://logs/";
            string extension = @".txt";

            Logger logger = new Logger();
            logger.AddOutput(new MultiFileOutput(directory, extension), new DefaultConsoleFormater());  // Log to multiple files.

            logger.Info("Info in consol and file.");  // Log on info layer.

            logger.FatalError("Aplication can be stoped!");   // Log on error layer.

            logger.Log(LogType.Warning, "warning message ...");  // basic log method, select message layer and set message.
        }
    }
}
