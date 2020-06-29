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

        public Employees Delete(int id)
        {
           Employees emps= _employees.FirstOrDefault(e => e.Id == id);
            if(emps != null)
            {
                _employees.Remove(emps);
            }
            return emps;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return _employees;
        }

        public Employees getEmployeeDetails(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public Employees Update(Employees employeeschanges)
        {
            Employees emps = _employees.FirstOrDefault(e => e.Id == employeeschanges.Id);
            if (emps != null)
            {
                emps.Name = employeeschanges.Name;
                emps.Email = employeeschanges.Email;
                emps.Department = employeeschanges.Department;
            }
            return emps;
        }
    }
}
