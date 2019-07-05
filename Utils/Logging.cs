using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logging 
    {
        public static void WriteLog(params string[] args)
        {

            var sb = new StringBuilder();

            foreach (var logItem in args)
            {
                sb.AppendLine(logItem);
                sb.AppendLine();
            }
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine();

            //File.AppendAllText($"{Environment.CurrentDirectory}\\log.txt", sb.ToString());
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
