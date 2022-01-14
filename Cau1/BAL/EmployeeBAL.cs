using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cau1.DAL;
using Cau1.Model;

namespace Cau1.BAL
{
    public class EmployeeBAL
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<Employee> ReadCustomer()
        {
            List<Employee> lstEmpl = dal.ReadCustomer();
            return lstEmpl;
        }
        public void NewEmployee(Employee emp)
        {
            dal.NewEmployee(emp);
        }
        public void EditEmployee(Employee emp)
        {
            dal.EditEmployee(emp);

        }
        public void DeleteEmployee(Employee emp)
        {
            dal.DeleteEmployee(emp);
        }


    }
}
