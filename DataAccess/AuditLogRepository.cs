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
                WriteLog(ex);
            }

            return false;
        }
        public static bool Save(Exception exception)
        {
            DbContextTransaction transaction = null;
            try
            {
                using (var _db = new MonitoringContext())
                {
                    using (transaction = _db.Database.BeginTransaction())
                    {
                        //this should be in the AuditLog class, but as this project is going EF database first, that class is generated
                        var auditLog = new AuditLog
                        {
                            Message = exception.Message,
                            InnerException = exception.InnerException?.Message,
                            Source = exception.Source,
                            StackTrace = exception.StackTrace,
                            TargetSite = exception.TargetSite.Name,
                            ExceptionDate = DateTime.Now
                        };

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
                WriteLog(ex);
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
                WriteLog(ex);
            }

            return null;
        }
    }

    
}
