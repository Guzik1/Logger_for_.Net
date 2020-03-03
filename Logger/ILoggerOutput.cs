using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    /// <summary>
    /// Interface for custom logger output.
    /// </summary>
    public interface ILoggerOutput
    {
        /// <summary>
        /// Write log in custom output.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="message">String of message.</param>
        public void Log(LogType logType, string message);
    }
}
