using System;
namespace Lab_3
{
    public interface ILogger
    {
        void Log(string message);
    }
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Записываем в файл: {message}");
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Выводим в консоль: {message}");
        }
    }
    public abstract class LoggerFactory
    {
        public abstract ILogger CreateLogger();
        public void LogMessage(string message)
        {
            ILogger logger = CreateLogger();
            logger.Log(message);
        }
    }
    public class FileLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new FileLogger();
        }
    }
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new ConsoleLogger();
        }
    }

}
class Program
{
    static void Main()
    {
        ConsoleLoggerFactory _consoleFactory = new ConsoleLoggerFactory();
        ILogger _console = _consoleFactory.CreateLogger();
        _console.Log("Тест номер 1");

        FileLoggerFactory _fileFactory = new FileLoggerFactory();
        ILogger _file = _fileFactory.CreateLogger();
        _file.Log("Тест номер 2");
    }
}
