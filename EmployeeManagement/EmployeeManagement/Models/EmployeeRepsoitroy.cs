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
                new Employees { Id =1, Department="HR", Email = "Ribesh@gamil.com", Name = "Ribesh"},
                new Employees { Id =2, Name = "JPT", Email = "JPT@gmail.com", Department = "IT"}
            };
            
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
