using FantasyGame.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace FantasyGame.Services;

public class LoggerService : ILoggerService
{
    public static void Info(string message, [CallerFilePath]string file = "", [CallerMemberName]string memberName = "", [CallerLineNumber]int lineNumber = 0)
    {
        Console.Write($"{message}, {file}, {memberName}, {lineNumber}");
    }
}