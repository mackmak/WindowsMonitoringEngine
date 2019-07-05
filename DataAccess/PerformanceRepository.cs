using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class PerformanceRepository : Logging
    {

        public static bool Save(Performance performance)
        {
            DbContextTransaction transaction = null;
            try
            {
                using (var _db = new MonitoringContext())
                {
                    using (transaction = _db.Database.BeginTransaction())
                    {

                        _db.Performances.Add(performance);
                        //setting identity field
                        //_db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Performance] ON");
                        _db.SaveChanges();
                        // _db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Performance] OFF");
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

        public static IList<Performance> RetrieveAll()
        {
            try
            {
                using (var _db = new MonitoringContext())
                {
                    using (var transaction = _db.Database.BeginTransaction())
                    {
                        return _db.Performances.ToList();
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
