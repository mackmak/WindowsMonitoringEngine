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
        public static void Save(AuditLog auditLog)
        {
            AuditLogRepository.Save(auditLog);
        }

        public static IList<AuditLog> GetAll()
        {
            return AuditLogRepository.RetrieveAll();
        }

        public static void Save(Exception exception)
        {
            try
            {
                AuditLogRepository.Save(exception);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
    }
}
