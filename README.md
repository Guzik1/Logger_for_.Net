# Logger for C#/.Net

This project is a simple log manager with multi output and formaters.

## General info
### Features:
- simple logs
- 6 layer (Info, Info2, Warning, Error, FatalError, Debug)
- default formater for console and files
- console output (different colour for each layer)
- file and multi-file outputs
- Add own formater
- Add own output

## Setup
[Nuget package available here!](https://www.nuget.org/packages/NLogger/1.0.0)
Compiling bin library is located in /bin folder. <br />
Copy NLogger (.dll files) to your project.<br />

## Simple code example
```C#
string path = @"C://logs/log.txt";

Logger logger = new Logger();
logger.AddOutput(new FileOutput(path), new DefaultConsoleFormater());  // Add log to file output and custor formater.
logger.AddDefaultConsoleOutputAndDefaultConsoleFormater();  // Log on screen in console.

logger.Info("Info in consol and file.");  // Log on info layer.
logger.Debug("Method has run test!");  // Log on debug layer.

logger.FatalError("Aplication can be stoped!");   // Log on fatal error layer.

logger.Log(LogType.Warning, "warning message ...");  // basic log method, select message layer and send message.
```
For view examples click [here](https://github.com/Guzik1/Logger_for_.Net/tree/master/Examples).

## Built with
- .Net Core 3.1
- NUnit Framework (for testing)

## Status
Version: 1.0.0

## License
[MIT License](https://github.com/Guzik1/Logger_for_.Net/blob/master/LICENSE) © [Sebastian Guzik](https://github.com/Guzik1).

