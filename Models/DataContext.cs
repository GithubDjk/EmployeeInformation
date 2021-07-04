using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInformation.Models
{
    public class DataContext:DbContext
    {
        public virtual DbSet<EmployeeeData> Employeees { get; set; }
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

/*        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source = D:\\Database.db");*/
    }
}
