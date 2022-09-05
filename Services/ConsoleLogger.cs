using System;
namespace WebApiNet.Services
{
    public class ConsoleLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
}