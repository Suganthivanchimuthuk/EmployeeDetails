using EmployeeDetails.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<EmployeeInfo> Employee { get; set; }
    }
}
