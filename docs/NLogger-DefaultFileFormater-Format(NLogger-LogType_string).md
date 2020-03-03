#### [NLogger](./index.md 'index')
### [NLogger](./NLogger.md 'NLogger').[DefaultFileFormater](./NLogger-DefaultFileFormater.md 'NLogger.DefaultFileFormater')
## DefaultFileFormater.Format(NLogger.LogType, string) Method
Format message.  
```csharp
public string Format(NLogger.LogType logType, string message);
```
#### Parameters
<a name='NLogger-DefaultFileFormater-Format(NLogger-LogType_string)-logType'></a>
`logType` [LogType](./NLogger-LogType.md 'NLogger.LogType')  
Log type.  
  
<a name='NLogger-DefaultFileFormater-Format(NLogger-LogType_string)-message'></a>
`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String message.  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Formated message (format: "logType: HH:MM:SS - message"), change message to upper case for error and fatal error  
