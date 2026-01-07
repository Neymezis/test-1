using System;
namespace Lab_4
{
    public class ExternalLogger
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine($"Внешний лог: {msg}");
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class LoggerAdapter : ILogger
    {
        private ExternalLogger _externalLogger;

        public LoggerAdapter(ExternalLogger externalLogger)
        {
            _externalLogger = externalLogger;
        }

        public void Log(string message)
        {
            _externalLogger.LogMessage(message);
        }
    }
}
class Program
{
    static void Main()
    {
        ExternalLogger oldLogger = new ExternalLogger();
        ILogger logger = new LoggerAdapter(oldLogger);
        logger.Log("Тестовое сообщение");
        logger.Log("Еще одно сообщение");
    }
}




