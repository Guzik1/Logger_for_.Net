using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NLogger
{
    public class MultiFileOutput : ILoggerOutput
    {
        string fileDirectoryPath;
        string fileExtension;

        public MultiFileOutput(string fileDirectoryPath, string fileExtension)
        {
            this.fileDirectoryPath = fileDirectoryPath;
            this.fileExtension = fileExtension;
        }

        public void Log(LogType logType, string message)
        {
            message += Environment.NewLine;
            string path = GetFullFilePath(logType);

            if (!File.Exists(path))
            {
                File.AppendAllText(path, message);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.AppendAllText(path, message);
            }
        }

        string GetFullFilePath(LogType logType)
        {
            return fileDirectoryPath + "/" + logType.ToString() + fileExtension;
        }
    }
}
