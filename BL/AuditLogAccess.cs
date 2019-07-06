using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BL
{
    public class AuditLogAccess
    {
        public static void Save(AuditLog auditLog)
        {
            AuditLogRepository.Save(auditLog);
        }

        public static IList<AuditLog> GetAll()
        {
            return AuditLogRepository.RetrieveAll();
        }

        public static void Save(string message, string innerException, string source, 
            string targetSite, string stackTrace)
        {
            var auditLog = new AuditLog
            {
                Message = message,
                InnerException = innerException,
                Source = source,
                StackTrace = stackTrace,
                TargetSite = targetSite,
                ExceptionDate = DateTime.Now
            };

            AuditLogRepository.Save(auditLog);
        }
    }
}
