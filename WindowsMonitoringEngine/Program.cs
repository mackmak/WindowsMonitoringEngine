using BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsMonitoringEngine
{
    public class Program
    {

        /// <summary>
        /// timer that runs every 10 seconds to execute the code
        /// </summary>
        private static Timer _timer;
        public static void Main(string[] args)
        {

            _timer = Common.Utils.SetUpTimer();

            _timer.Elapsed += OnTimedEvent;

            Console.WriteLine("The monitor is on....");
            Console.ReadLine();  
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs eventsArgs)
        {

            //var tableAdapter = new DataCollectedTableAdapter();
            //tableAdapter.InsertNewRecord(GetCpuValue(), GetMemValue(), DateTime.Now);

            PerformanceAccess.Save(Common.Utils.GetCpuValue(),
                Common.Utils.GetMemValue(), DateTime.Now);
        } 

    }
}
