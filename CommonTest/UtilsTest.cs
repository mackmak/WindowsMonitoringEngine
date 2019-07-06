using System;
using System.DirectoryServices.AccountManagement;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTest
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void GetDomainUserNameTest()
        {
            //Assign
            var domain = Environment.UserDomainName;
            var userPrincipal = UserPrincipal.Current;

            //Assert
            Assert.AreEqual($"{domain}\\{userPrincipal.Name}", "MARCOS-SSD\\Marcos");
        }

        [TestMethod]
        public void LoggingTest()
        {
            //Assign
            try
            {
                throw new Exception("Logging Test");
            }
            catch (Exception ex)
            {
                //Act
                Logging.WriteLog(ex);
            }

        }
    }
}
