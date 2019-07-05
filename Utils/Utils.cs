using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;

namespace Common
{
    public static class Utils
    {
        public static Timer SetUpTimer()
        {
            var timer = new Timer()
            {
                //every 10 seconds gets cpu and mem values and insert into database
                Interval = 10000,
                AutoReset = true,
                Enabled = true
            };

            return timer;
        }

        public static int GetCpuValue()
        {
            //categories similar to the existnig ones in perfmon.exe (windows)
            var CpuCounter = new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total");

            //skipping first sample
            CpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);

            //recording sample between two different time stamps
            int gapValue = (int)CpuCounter.NextValue();

            return gapValue;
        }

        public static int GetMemValue()
        {
            var memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            //getting first sample
            int returnValue = (int)memCounter.NextValue();

            return returnValue;
        }
        public static string GetDomainUserName()
        {
            try
            {

                var domain = Environment.UserDomainName;
                var userPrincipal = UserPrincipal.Current;


                return $"{domain}\\{userPrincipal.Name}";
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message, ex.InnerException.Message);
            }

            return null;
        }

    }
}
