using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    /// <summary>
    /// Standard console output, implemented ILoggerOutput.
    /// </summary>
    public class ConsoleOutput: ILoggerOutput
    {
        Dictionary<LogType, ConsoleColor> colors = new Dictionary<LogType, ConsoleColor>();

        /// <summary>
        /// Constructor, set default color.
        /// </summary>
        public ConsoleOutput()
        {
            ResetColorsToDefaultColor();
        }

        /// <summary>
        /// Write log on screen.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="message">String of formated message.</param>
        public void Log(LogType logType, string message)
        {
            Console.ForegroundColor = GetConsoleColor(logType);

            Console.WriteLine(message);

            Console.ResetColor();
        }

        /// <summary>
        /// Change one color for one log type.
        /// </summary>
        /// <param name="logType">Type of log, for which change color.</param>
        /// <param name="newColor">New color.</param>
        public void ChangeColor(LogType logType, ConsoleColor newColor)
        {
            if (colors.ContainsKey(logType))
                colors[logType] = newColor;
            else
                colors.Add(logType, newColor);
        }

        /// <summary>
        /// Reste log colors to default.
        /// </summary>
        public void ResetColorsToDefaultColor()
        {
            colors = new Dictionary<LogType, ConsoleColor>
            {
                { LogType.Info, ConsoleColor.DarkGreen },
                { LogType.Info2, ConsoleColor.DarkMagenta },
                { LogType.Warning, ConsoleColor.DarkYellow },
                { LogType.Error, ConsoleColor.DarkRed },
                { LogType.Debug, ConsoleColor.DarkBlue },
                { LogType.FatalError, ConsoleColor.Red }
            };
        }

        ConsoleColor GetConsoleColor(LogType type)
        {
            return colors[type];
        }
    }
}
