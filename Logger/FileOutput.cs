using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace NLogger
{
    public class FileOutput: ILoggerOutput
    {
        string filePath;
        string logsToSave;
        int logCount = 10;
        int logLimit;
        readonly object Lock = new object();

        public FileOutput(string filePath)
        {
            this.filePath = filePath;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.OnApplicationExit);
        }

        public FileOutput(string filePath, int logLimit)
        {
            this.filePath = filePath;
            this.logLimit = logLimit;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.OnApplicationExit);
        }

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
