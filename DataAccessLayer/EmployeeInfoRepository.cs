using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.DataAccessLayer
{
    public class EmployeeInfoRepository:IEmployeeInfoRepository
    {
        private readonly EmployeeDbContext _EDb;
        public EmployeeInfoRepository(EmployeeDbContext dbContext)
        {
            _EDb = dbContext;
        }
        public EmployeeInfo GetByNumber(long id)
        {
            try
            {
                var num = _EDb.Employee.FromSqlRaw<EmployeeInfo>($"select * from Employee where EmployeeId={id}");
                return num.ToList().FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            try
            {
                IEnumerable<EmployeeInfo> result = _EDb.Employee.FromSqlRaw<EmployeeInfo>($"exec ReadEmployee");
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void EmployeeInsert(EmployeeInfo employee)
        {
            try
            {
                _EDb.Database.ExecuteSqlRaw($"exec EmployeeInsert '{employee.Name}','{employee.DOB}','{employee.MobileNumber}','{employee.Email}','{employee.Address}'");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EmployeeUpdate(long id, EmployeeInfo em)
        {
            try
            {
                _EDb.Database.ExecuteSqlRaw($"exec EmployeeUpdate '{id}','{em.Name}','{em.DOB}','{em.MobileNumber}','{em.Email}','{em.Address}'");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void EmployeeDelete(long id)
        {
            try
            {
                var result = _EDb.Database.ExecuteSqlRaw($"exec EmployeeDelete {id}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

    

