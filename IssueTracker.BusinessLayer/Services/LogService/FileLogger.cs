using System;
using System.Configuration;
using System.IO;
using IssueTracker.BusinessLayer.Services.Abstracts;
using Newtonsoft.Json;

namespace IssueTracker.BusinessLayer.Services.LogService
{
    public class FileLogger<T> : ILogger<T>
    {
        private static readonly object _LockStreamWriter = new object();
        private static DateTime _DateTimeNow { get { return DateTime.Now; } }
        private static string _MessageHeader { get { return $"[{_DateTimeNow:dd-MMM-yyyy HH:mm:ss}]"; } }

        public string Log(string message)
        {
            WriteMessageToFile($"INFO {_MessageHeader} \t{typeof(T).FullName} \t{message} \t");
            return message;
        }
        public string Log(string message, object object1 = null, object object2 = null)
        {
            WriteMessageToFile($"INFO {_MessageHeader} \t{typeof(T).FullName} \t{message} \t", obj1: object1, obj2: object2);
            return message;
        }

        public string Log(Exception ex, object object1 = null, object object2 = null)
        {
            WriteMessageToFile($"ERROR {_MessageHeader} \t{typeof(T).FullName} \t{ex.Message} \t{ex.InnerException?.Message}", ex, object1, object2);
            return $"Oops! Something went wrong, please contact administration. Details: {ex.Message}";
        }

        private void WriteMessageToFile(string formattedMessage, Exception ex = null, object obj1 = null, object obj2 = null)
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
                        if (ex.InnerException != null)
                        {
                            sw.WriteLine();
                            sw.WriteLine("INNER-EXCEPTION: {0}", JsonConvert.SerializeObject(ex.InnerException));
                        }
                        if (ex.StackTrace != null)
                        {
                            sw.WriteLine();
                            sw.WriteLine("STACK-TRACE: {0}", JsonConvert.SerializeObject(ex.StackTrace));
                        }
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


        private string GetFilePath()
        {
            var fileLoggerPath = string.Empty;
            try
            {
                fileLoggerPath = ConfigurationManager.AppSettings["FILE_LOGGER_PATH"].ToString().TrimStart('/').TrimEnd('/');
            }
            catch
            {
                throw new ArgumentNullException("Unable to find FILE_LOGGER_PATH setting.");
            }

            string directory = $"{fileLoggerPath}/{_DateTimeNow:yyyyMM}";
            //string directoryPath = HttpContext.Current.Server.MapPath(directory);

            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            string filePath = $"{directory}/{_DateTimeNow:yyyyMMdd}.txt";   //Text File Name

            if (File.Exists(filePath) == false)
                File.Create(filePath).Dispose();

            return filePath;
        }
    }
}