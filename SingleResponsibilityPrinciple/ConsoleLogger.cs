using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("INFO: ", message), args);
        }

        private void LogMessage(string msgType, string message, params object[] args)
        {
            Console.WriteLine(msgType + " :" + message, args);
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>" + msgType + "</type><message>" + message + "</message></log> ", args);
            }
        }
    }
}
