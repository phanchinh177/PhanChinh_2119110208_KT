using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cau1.DAL;
using Cau1.Model;

namespace Cau1.BAL
{
    public class DepartmentBAL
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<Department> ReadAreaList()
        {
            List<Department> lstDepart = dal.ReadAreaList();
            return lstDepart;
        }
    }
}
