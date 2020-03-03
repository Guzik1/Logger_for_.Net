using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace NLogger
{
    /// <summary>
    /// Default multiple file output (one file for one log layer), file name is a layer name. Implemented ILoggerOutput interface.
    /// </summary>
    public class MultiFileOutput : ILoggerOutput
    {
        string fileDirectoryPath;
        string fileExtension;

        string[] logsToSave;
        int[] logCount;
        int logLimit = 10;
        readonly object Lock = new object();

        /// <summary>
        /// Constructon to set file directory and file extension. Log limit set to default 10 logs on one layer. File name is a layer name.
        /// </summary>
        /// <param name="fileDirectoryPath">File directory.</param>
        /// <param name="fileExtension">File extension.</param>
        public MultiFileOutput(string fileDirectoryPath, string fileExtension)
        {
            this.fileDirectoryPath = fileDirectoryPath;
            this.fileExtension = fileExtension;

            InicjalizeArrays();
        }

        /// <summary>
        /// Constructon to set file directory and file extension. Log limit set to default 10 logs on one layer. File name is a layer name.
        /// </summary>
        /// <param name="fileDirectoryPath">File directory.</param>
        /// <param name="fileExtension">File extension.</param>
        /// <param name="logLimit">Limit at which will be log saved.</param>
        public MultiFileOutput(string fileDirectoryPath, string fileExtension, int logLimit)
        {
            this.fileDirectoryPath = fileDirectoryPath;
            this.fileExtension = fileExtension;
            this.logLimit = logLimit;

            InicjalizeArrays();
        }

        void InicjalizeArrays()
        {
            int count = Enum.GetValues(typeof(LogType)).Cast<int>().Last();
            logsToSave = new string[count];
            logCount = new int[count];
        }

        /// <summary>
        /// Write log to files.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="message">String of formated message.</param>
        public void Log(LogType logType, string message)
        {
            lock(Lock){
                int index = (int)logType;

                logsToSave[index] += message + Environment.NewLine;
                logCount[index]++;

                if (logCount[index] >= logLimit)
                    RunSaveToFile(logType);
            }

        }

        void RunSaveToFile(LogType logType)
        {
            Thread saveThread = new Thread(this.SaveToFile);
            saveThread.Start(logType);
        }

        void SaveToFile(object logType)
        {
            lock (Lock)
            {
                int index = (int)logType;
                string path = GetFullFilePath((LogType)logType);

                if (!File.Exists(path))
                {
                    File.AppendAllText(path, logsToSave[index]);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    File.AppendAllText(path, logsToSave[index]);
                }

                logsToSave[index] = "";
            }
        }

        string GetFullFilePath(LogType logType)
        {
            return fileDirectoryPath + "/" + logType.ToString() + fileExtension;
        }
    }
}
