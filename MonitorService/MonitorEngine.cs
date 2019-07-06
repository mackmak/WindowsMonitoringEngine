using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MonitorService
{
    partial class MonitorEngine : ServiceBase
    {
        public MonitorEngine()
        {
            InitializeComponent();
        }

        public static Timer _timer;

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            _timer = Common.Utils.SetUpTimer();

            _timer.Elapsed += OnTimedEvent;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs eventsArgs)
        {

            PerformanceAccess.Save(Common.Utils.GetCpuValue(),
                Common.Utils.GetMemValue(), DateTime.Now);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
