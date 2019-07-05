using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;

namespace MonitoringEngineTest
{
    [TestClass]
    public class MonitoringEngineTest
    {
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        [TestMethod]
        public void QueryTest()
        {
            var performanceResults = PerformanceRepository.RetrieveAll();

            //assert
            Assert.AreEqual(performanceResults.Count,16);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Assign
            var performance = new Performance
            {
                ID = 15,
                CpuValue = 13,
                MemValue = 8,
                SampleDate = DateTime.Now
            };

            //Act
            var success = PerformanceRepository.Save(performance);

            //Assert
            Assert.AreEqual(success, true);

        }

    }
}
