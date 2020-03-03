using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace NLogger
{
    /// <summary>
    /// Default one file output.
    /// </summary>
    public class FileOutput: ILoggerOutput
    {
        string filePath;
        string logsToSave;
        int logCount = 15;
        int logLimit;
        readonly object Lock = new object();

        /// <summary>
        /// Constructon to set file path. Log limit set to default 15 logs.
        /// </summary>
        /// <param name="filePath">File path whith director file name and file extension.</param>
        public FileOutput(string filePath)
        {
            this.filePath = filePath;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.OnApplicationExit);
        }

        /// <summary>
        /// Constructon to set file path and limit when logs are been save to file. Default limit is 15 logs on all layer.
        /// </summary>
        /// <param name="filePath">File path whith director file name and file extension.</param>
        /// <param name="limitWhenLogSave">Limit at which will be log saved.</param>
        public FileOutput(string filePath, int limitWhenLogSave)
        {
            this.filePath = filePath;
            this.logLimit = limitWhenLogSave;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.OnApplicationExit);
        }

        /// <summary>
        /// Write log to file.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="message">String of formated message.</param>
        public void Log(LogType logType, string message)
        {
            lock (Lock)
            {
                logsToSave += message + Environment.NewLine;
                logCount++;

                if (logCount >= logLimit)
                    RunSaveToFile();
            }
        }

        void RunSaveToFile()
        {
            Thread saveThread = new Thread(new ThreadStart(this.SaveToFile));
            saveThread.Start();
        }

        void SaveToFile()
        {
            lock (Lock)
            {
                if (!File.Exists(filePath))
                {
                    File.AppendAllText(filePath, logsToSave);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.AppendAllText(filePath, logsToSave);
                }

                logsToSave = "";
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            RunSaveToFile();
        }
    }
}
