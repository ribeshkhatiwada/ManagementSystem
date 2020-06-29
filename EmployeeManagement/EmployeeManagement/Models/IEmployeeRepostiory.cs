using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
   public interface IEmployeeRepostiory
    {
        Employees getEmployeeDetails(int? id);
        IEnumerable<Employees> GetAllEmployees();
        Employees Add(Employees employees);

    }
}
