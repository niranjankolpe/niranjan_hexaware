using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AssetManagement
{
    public static class LogException
    {
        public static readonly string logFilePath = @"C:\Users\niran\Desktop\My Files\Hexaware\Codes\GitHub Repository\Case Studies\Case Study 2 - CSharp - Digital Asset Management Application\AssetManagement\AssetManagement.Exception\LogException.txt";
        public static void LogCurrentException(string source, string message, string exceptionString, string stackTrace, DateTime exceptionDateTime) {
            string logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logData = $"Error Log Details\nSource: {source}\nMessage: {message}\nException String: {exceptionString}\nStack Trace: {stackTrace}\nTimestamp: {exceptionDateTime}\n\n";
            File.AppendAllText(logFilePath, logData);
        }
    }
}
