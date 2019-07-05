using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MonitoringContext : DbContext
    {

        public MonitoringContext() : base("name=MonitorServiceDBEntities")
        {

        }
        public virtual DbSet<Performance> Performances { get; set; }



    }
}
