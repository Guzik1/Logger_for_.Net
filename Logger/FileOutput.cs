using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NLogger
{
    public class FileOutput: ILoggerOutput
    {
        string filePath;

        public FileOutput(string filePath)
            => this.filePath = filePath;

        public void Log(LogType logType, string message)
        {
            message += Environment.NewLine;

            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, message);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.AppendAllText(filePath, message);
            }
        }
    }
}
