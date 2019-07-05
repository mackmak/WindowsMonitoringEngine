using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BL
{
    public class PerformanceAccess
    {
        public static IList<Performance> GetAll()
        {
            return PerformanceRepository.RetrieveAll();
        }

        public static bool InsertPerformanceValue(Performance performance)
        {
            return PerformanceRepository.Save(performance);
        }

        public static bool InsertPerformanceValue(int cpuValue, int memValue, DateTime sampleDate)
        {
            var performance = new Performance
            {
                CpuValue = cpuValue,
                MemValue = memValue,
                SampleDate = sampleDate
            };

            return PerformanceRepository.Save(performance);
        }
    }
}
