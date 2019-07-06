using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuditLogRepository:Logging
    {
        public static bool Save(AuditLog auditLog)
        {
            DbContextTransaction transaction = null;
            try
            {
                using (var _db = new MonitoringContext())
                {
                    using (transaction = _db.Database.BeginTransaction())
                    {
                        _db.AuditLogs.Add(auditLog);
                        //_db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[AuditLog] ON");
                        _db.SaveChanges();
                        // _db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[AuditLog] OFF");
                        transaction.Commit();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, ex.InnerException.Message);
            }

            return false;
        }
        public static IList<AuditLog> RetrieveAll()
        {
            DbContextTransaction transaction = null;
            try
            {
                using (var _db = new MonitoringContext())
                {
                    using (transaction = _db.Database.BeginTransaction())
                    {
                        return _db.AuditLogs.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, ex.InnerException.Message);
            }

            return null;
        }
    }

    
}
