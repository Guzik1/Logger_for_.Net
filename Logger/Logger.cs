using NLogger;
using System;
using System.Collections.Generic;

namespace NLogger
{
    /// <summary>
    /// Logger main class.
    /// </summary>
    public class Logger
    {
        List<ILoggerOutput> logOutput = new List<ILoggerOutput>();
        List<ILogFormater> formaters = new List<ILogFormater>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Logger() { }

        /// <summary>
        /// Constructor which add output and formater for output.
        /// </summary>
        /// <param name="output">Output when implemented ILoggerOutput</param>
        /// <param name="formater">>Formater for output when implemented ILogFormater</param>
        public Logger(ILoggerOutput output, ILogFormater formater)
            => AddOutput(output, formater);

        /// <summary>
        /// Add default console output and default console formater for output.
        /// </summary>
        public void AddDefaultConsoleOutputAndDefaultConsoleFormater()
        {
            logOutput.Add(new ConsoleOutput());
            formaters.Add(new DefaultConsoleFormater());
        }

        /// <summary>
        /// Add output and formater to this output.
        /// </summary>
        /// <param name="output">Output, class implemented ILoggerOutput</param>
        /// <param name="formater">Formater for output, class implemented ILogFormater</param>
        public void AddOutput(ILoggerOutput output, ILogFormater formater)
        {
            logOutput.Add(output);
            formaters.Add(formater);
        }

        /// <summary>
        /// Delete all output from logger registers.
        /// </summary>
        public void DeleteAllOutput()
        {
            logOutput.Clear();
            formaters.Clear();
        }

        #region Info
        /// <summary>
        /// Log message on Info layer.
        /// </summary>
        /// <param name="message">Info message.</param>
        public void Info(string message)
        {
            Log(LogType.Info, message);
        }

        /// <summary>
        /// Log message on Info layer.
        /// </summary>
        /// <param name="formatedMessage">Info formated message.</param>
        /// <param name="param">Strings to insert in format message.</param>
        public void Info(string formatedMessage, params string[] param)
        {
            string postFormat = String.Format(formatedMessage, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Info2
        /// <summary>
        /// Log message on Info2 layer.
        /// </summary>
        /// <param name="message">Info message.</param>
        public void Info2(string message)
        {
            Log(LogType.Info, message);
        }

        /// <summary>
        /// Log message on Info2 layer.
        /// </summary>
        /// <param name="formatedMessage">Info2 formated message.</param>
        /// <param name="param">Strings to insert in format message.</param>
        public void Info2(string formatedMessage, params string[] param)
        {
            string postFormat = String.Format(formatedMessage, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Error
        /// <summary>
        /// Log message on Error layer.
        /// </summary>
        /// <param name="message">Error message.</param>
        public void Error(string message)
        {
            Log(LogType.Error, message);
        }

        /// <summary>
        /// Log message on Error layer.
        /// </summary>
        /// <param name="formatedMessage">Error formated message.</param>
        /// <param name="param">Strings to insert in format message.</param>
        public void Error(string formatedMessage, params string[] param)
        {
            string postFormat = String.Format(formatedMessage, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Warning
        /// <summary>
        /// Log message on Warning layer.
        /// </summary>
        /// <param name="message">Warning message.</param>
        public void Warning(string message)
        {
            Log(LogType.Warning, message);
        }

        /// <summary>
        /// Log message on Warning layer.
        /// </summary>
        /// <param name="formatedMessage">Warning formated message.</param>
        /// <param name="param">Strings to insert in format message.</param>
        public void Warning(string formatedMessage, params string[] param)
        {
            string postFormat = String.Format(formatedMessage, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region Debug
        /// <summary>
        /// Log message on Debug layer.
        /// </summary>
        /// <param name="message">Debug message.</param>
        public void Debug(string message)
        {
            Log(LogType.Debug, message);
        }

        /// <summary>
        /// Log message on Debug layer.
        /// </summary>
        /// <param name="formatedMessage">Debug formated message.</param>
        /// <param name="param">Strings to insert in format message.</param>
        public void Debug(string formatedMessage, params string[] param)
        {
            string postFormat = String.Format(formatedMessage, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        #region FatalError
        /// <summary>
        /// Log message on FatalError layer.
        /// </summary>
        /// <param name="message">Debug message.</param>
        public void FatalError(string message)
        {
            Log(LogType.FatalError, message);
        }

        /// <summary>
        /// Log message on FatalError layer.
        /// </summary>
        /// <param name="formatedMessage">FatalError formated message.</param>
        /// <param name="param">Strings to insert in format message.</param>
        public void FatalError(string formatedMessage, params string[] param)
        {
            string postFormat = String.Format(formatedMessage, param);

            Log(LogType.Info, postFormat);
        }
        #endregion

        /// <summary>
        /// Log message on selected layer.
        /// </summary>
        /// <param name="logType">Log layer.</param>
        /// <param name="message">String of message.</param>
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
