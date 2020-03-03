using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    /// <summary>
    /// Deafult formater for console output.
    /// </summary>
    public class DefaultConsoleFormater : ILogFormater
    {
        /// <summary>
        /// Format message.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="message">String message.</param>
        /// <returns>Formated message (format: "HH:MM:SS - message").</returns>
        public string Format(LogType logType, string message)
        {
            DateTime dt = DateTime.Now;

            string messageFormat = $"{ dt.Hour }:{ dt.Minute }:{ dt.Second } - { message }";

            return messageFormat;
        }
    }
}
