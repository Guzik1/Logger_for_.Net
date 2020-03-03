using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    /// <summary>
    /// Deafult file formater for one file output. 
    /// </summary>
    public class DefaultFileFormater : ILogFormater
    {
        /// <summary>
        /// Format message.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="message">String message.</param>
        /// <returns>Formated message (format: "logType: HH:MM:SS - message"), change message to upper case for error and fatal error</returns>
        public string Format(LogType logType, string message)
        {
            DefaultConsoleFormater dcf = new DefaultConsoleFormater();

            if (logType == LogType.FatalError || logType == LogType.Error)
                message = message.ToUpper();

            return $"{ logType.ToString() }: { dcf.Format(logType, message) }";
        }
    }
}
