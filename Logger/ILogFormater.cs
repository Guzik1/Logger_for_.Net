using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    /// <summary>
    /// Interface for custom logger formater.
    /// </summary>
    public interface ILogFormater
    {
        /// <summary>
        /// Format message.
        /// </summary>
        /// <param name="logType">Log type</param>
        /// <param name="message">String of message.</param>
        /// <returns>Formated message.</returns>
        public string Format(LogType logType, string message);
    }
}
