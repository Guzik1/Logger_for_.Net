using NLogger;
using System;
using System.Collections.Generic;

namespace NLogger
{
    public class Logger
    {
        List<ILoggerOutput> logOutput = new List<ILoggerOutput>();
        List<ILogFormater> formaters = new List<ILogFormater>();

        public Logger() { }

        public Logger(ILoggerOutput output, ILogFormater formater)
            => AddOutput(output, formater);

        public void AddDefaultConsoleOutputAndDefaultConsoleFormater()
        {
            logOutput.Add(new ConsoleOutput());
            formaters.Add(new DefaultConsoleFormater());
        }

        public void AddOutput(ILoggerOutput output, ILogFormater formater)
        {
            logOutput.Add(output);
            formaters.Add(formater);
        }

        public void DeleteAllOutput()
        {
            logOutput.Clear();
            formaters.Clear();
        }

        #region Info
        public void Info(string message)
        {
            Log(LogType.Info, message);
        }

        public void Info(string format, params string[] param)
        {
            string postFormat = String.Format(format, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Error
        public void Error(string message)
        {
            Log(LogType.Error, message);
        }

        public void Error(string format, params string[] param)
        {
            string postFormat = String.Format(format, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Warning
        public void Warning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void Warning(string format, params string[] param)
        {
            string postFormat = String.Format(format, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Debug
        public void Debug(string message)
        {
            Log(LogType.Debug, message);
        }

        public void Debug(string format, params string[] param)
        {
            string postFormat = String.Format(format, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region FatalError
        public void FatalError(string message)
        {
            Log(LogType.FatalError, message);
        }

        public void FatalError(string format, params string[] param)
        {
            string postFormat = String.Format(format, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        public void Log(LogType logType, string message)
        {
            for(int i = 0; i < logOutput.Count; i++)
            {
                string formatedMessage = formaters[i].Format(logType, message);

                logOutput[i].Log(logType, formatedMessage);
            }

        }
    }
}
