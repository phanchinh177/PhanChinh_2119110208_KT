using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.Model
{
    public class Department
    {
        public List<Employee> Employees { get; set; }
        public string IdDepartment { set; get; }
        public String Name_Department { set; get; }
    }
}
