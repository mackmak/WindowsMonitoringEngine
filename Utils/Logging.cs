using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logging
    {
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public string Source { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }

        private static void PersistLog(Logging log)
        {
            PropertyInfo[] properties = log.GetType().GetProperties();

            var sb = new StringBuilder();

            //looking through all log's properties values set
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(log);
                if (propertyValue != null)
                {
                    sb.AppendLine(propertyValue.ToString());
                    sb.AppendLine();
                }

                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                sb.AppendLine("--------------------------------------------------------------");
                sb.AppendLine();
            }
            CreateLogFile(sb);
        }

        public static void WriteLog(Exception ex)
        {
            var log = new Logging
            {
                Exception = ex.Message,
                InnerException = ex.InnerException.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace,
                TargetSite = ex.TargetSite.Name,
                
            };

            PersistLog(log);

        }


        public static void WriteLog(params string[] args)
        {

            var sb = new StringBuilder();

            foreach (var logItem in args)
            {
                sb.AppendLine(logItem);
                sb.AppendLine();
            }

            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sb.AppendLine("--------------------------------------------------------------");
            sb.AppendLine();

            //File.AppendAllText($"{Environment.CurrentDirectory}\\log.txt", sb.ToString());
            CreateLogFile(sb);


        }

        private static void CreateLogFile(StringBuilder sb)
        {
            try
            {
                Directory.CreateDirectory("C:\\Monitoring Service Logs");
                File.AppendAllText("C:\\Monitoring Service Logs\\log.txt", sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sb.Clear();
            }
        }


    }
}
