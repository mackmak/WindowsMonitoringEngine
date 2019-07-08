using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataAccess;

namespace BL
{
    public class AuditLogAccess : Logging
    {
        public static IList<AuditLog> GetAll()
        {
            return AuditLogRepository.RetrieveAll();
        }

        public static bool Save(Exception exception)
        {

            return AuditLogRepository.Save(exception);

        }
        public static bool Save(AuditLog auditLog)
        {
            return AuditLogRepository.Save(auditLog);

        }

        public static bool DeleteAll()
        {
            return AuditLogRepository.DeleteAll();
        }
    }
}
