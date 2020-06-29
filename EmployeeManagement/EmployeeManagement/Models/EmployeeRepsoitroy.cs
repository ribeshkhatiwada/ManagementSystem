using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepsoitroy : IEmployeeRepostiory
    {
        private List<Employees> _employees;
        public EmployeeRepsoitroy()
        {
            _employees = new List<Employees>()
            {
                new Employees { Id =1, Name = "Ribesh",Department=Dept.HR, Email = "Ribesh@gamil.com" },
                new Employees { Id =2, Name = "JPT", Department = Dept.IT, Email = "JPT@gmail.com"}
            };
            
        }

        public Employees Add(Employees employees)
        {
            employees.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employees);
            return employees;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return _employees;
        }

        public Employees getEmployeeDetails(int? id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
