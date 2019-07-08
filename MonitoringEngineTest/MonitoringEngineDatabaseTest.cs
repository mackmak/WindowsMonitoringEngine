using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using DataAccess;

namespace MonitoringEngineTest
{
    [TestClass]
    public class MonitoringEngineDatabaseTest
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
        public void QueryPerformanceTest()
        {
            var performanceResults = PerformanceRepository.GetAll();

            //assert
            Assert.AreNotEqual(performanceResults.Count, 0);
        }

        [TestMethod]
        public void InsertPerformanceTest()
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
        [TestMethod]
        public void QueryAuditLogTest()
        {
            //Assign/Act
            var query = AuditLogAccess.GetAll();

            //Assert
            Assert.AreNotEqual(query.Count, 0);

        }

        [TestMethod]
        public void InsertAuditLogTest()
        {
            //Assign
            bool success = false;
            try
            {
                throw new Exception("Log Saving Test");
            }
            catch (Exception ex)
            {//Act
                success = AuditLogAccess.Save(ex);
            }

            //Assert
            Assert.AreEqual(success, true);
        }

    }
}
