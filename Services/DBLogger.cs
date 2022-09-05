using System;
namespace WebApiNet.Services
{
    public class DBLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - " + message);
        }
    }
}