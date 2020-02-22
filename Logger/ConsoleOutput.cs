using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    public class ConsoleOutput: ILoggerOutput
    {
        Dictionary<LogType, ConsoleColor> colors = new Dictionary<LogType, ConsoleColor>();

        public ConsoleOutput()
        {
            ResetColorsToDefaultColor();
        }

        public void Log(LogType logType, string message)
        {
            Console.ForegroundColor = GetConsoleColor(logType);

            Console.WriteLine(message);

            Console.ResetColor();
        }

        public void ChangeColor(LogType logType, ConsoleColor color)
        {
            if (colors.ContainsKey(logType))
                colors[logType] = color;
            else
                colors.Add(logType, color);
        }

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
