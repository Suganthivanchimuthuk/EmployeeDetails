using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.DataAccessLayer
{
    public interface IEmployeeInfoRepository
    {
        public void EmployeeInsert(EmployeeInfo employee);
        public IEnumerable<EmployeeInfo> GetAllEmployee();
        public EmployeeInfo GetByNumber(long id);
        public void EmployeeUpdate(long id, EmployeeInfo em);
        public void EmployeeDelete(long id);

    }
}
