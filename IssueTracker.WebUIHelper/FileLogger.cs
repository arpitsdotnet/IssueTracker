using System;
using System.Configuration;
using System.IO;
using System.Web;
using IssueTracker.WebUIHelper.Helpers;
using Newtonsoft.Json;

namespace IssueTracker.WebUIHelper
{
    public class FileLogger
    {
        private static readonly object _LockStreamWriter = new object();
        private static DateTime _DateTimeNow { get { return DateTime.Now; } }
        private static string _MessageHeader { get { return $"[{_DateTimeNow:dd-MMM-yyyy HH:mm:ss}]"; } }

        public static string Log(string message)
        {
            WriteMessageToFile($"INFO {_MessageHeader} \t{message} \t");
            return message;
        }

        public static string Log(Exception ex, Object obj1 = null, Object obj2 = null)
        {
            WriteMessageToFile($"ERROR {_MessageHeader} \t{ex.Message} \t{ex.InnerException?.Message}", ex, obj1, obj2);
            return $"Oops! Something went wrong, please contact administration. Details: {ex.Message}";
        }

        private static void WriteMessageToFile(string formattedMessage, Exception ex = null, Object obj1 = null, Object obj2 = null)
        {
            lock (_LockStreamWriter)
            {
                string path = GetFilePath();
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("-------------------------------------------------------------------------");
                    sw.WriteLine(formattedMessage);
                    if (ex != null)
                    {
                        sw.WriteLine();
                        sw.WriteLine("EXCEPTION: {0}", JsonConvert.SerializeObject(ex));
                    }
                    if (obj1 != null)
                    {
                        sw.WriteLine();
                        sw.WriteLine("DATA: {0}", JsonConvert.SerializeObject(obj1));
                    }
                    if (obj2 != null)
                    {
                        sw.WriteLine();
                        sw.WriteLine("DATA: {0}", JsonConvert.SerializeObject(obj2));
                    }
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                }
            }
        }


        private static string GetFilePath()
        {
            //var clientCode = ConfigurationHelper.GetKeyValue("CLIENT_CODE");
            var projectEnvironment = ConfigurationHelper.GetKeyValue("PROJECT_ENVIRONMENT");
            var fileLoggerPath = ConfigurationHelper.GetKeyValue("FILE_LOGGER_PATH").TrimStart('/').TrimEnd('/');
           
            //string directory = $"~/{fileLoggerPath}/{clientCode}/{_DateTimeNow:yyyyMM}";
            //directory = HttpContext.Current.Server.MapPath(directory);
            string directory = $"{fileLoggerPath}/{projectEnvironment}/{_DateTimeNow:yyyyMM}";
            
            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            string filePath = $"{directory}/{_DateTimeNow:yyyyMMdd}.txt";   //Text File Name

            if (File.Exists(filePath) == false)
                File.Create(filePath).Dispose();

            return filePath;
        }
    }
}