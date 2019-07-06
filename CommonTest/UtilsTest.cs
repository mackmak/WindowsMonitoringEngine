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
            var firstname = userPrincipal.GivenName;

            //Assert
            Assert.AreEqual($"{domain}\\{userPrincipal.Name}", "MARCOS-SSD\\Marcos");
        }

        [TestMethod]
        public void LoggingTest()
        {
            //Assign
            var log = new Logging
            {
                Exception = "Exception message",
                InnerException = "Inner Exception Message",
                Source = "Source"
                //ExceptionDate = DateTime.Now
            };

            //Act
            //Logging.WriteLog(log);
        }
    }
}
