using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    public class ConsoleOutput: ILoggerOutput
    {
        ConsoleColor[] colors = new ConsoleColor[5];

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
            switch(logType)
            {
                case LogType.Info:
                    colors[0] = color;
                    break;
                case LogType.Warning:
                    colors[1] = color;
                    break;
                case LogType.Error:
                    colors[2] = color;
                    break;
                case LogType.Debug:
                    colors[3] = color;
                    break;
                case LogType.FatalError:
                    colors[4] = color;
                    break;
            };
        }

        public void ResetColorsToDefaultColor()
        {
            colors[0] = ConsoleColor.DarkGreen;
            colors[1] = ConsoleColor.DarkYellow;
            colors[2] = ConsoleColor.DarkRed;
            colors[3] = ConsoleColor.DarkBlue;
            colors[4] = ConsoleColor.Red;
        }

        ConsoleColor GetConsoleColor(LogType type)
        {
            return type switch
            {
                LogType.Info => colors[0],
                LogType.Warning => colors[1],
                LogType.Error => colors[2],
                LogType.Debug => colors[3],
                _ => colors[4],
            };
        }
    }
}
