using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataAccess;

namespace BL
{
    public class PerformanceAccess : Logging
    {
        public static IList<Performance> GetAll()
        {
            return PerformanceRepository.GetAll();
        }

        public static bool Save(Performance performance)
        {
            return PerformanceRepository.Save(performance);
        }

        public static bool Save(int cpuValue, int memValue, DateTime sampleDate)
        {
            try
            {
                //this should be in the Performance class, but as this project is going EF database first, that class is generated
                var performance = new Performance
                {
                    CpuValue = cpuValue,
                    MemValue = memValue,
                    SampleDate = sampleDate
                };

                return PerformanceRepository.Save(performance);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
            return false;
        }
    }
}
