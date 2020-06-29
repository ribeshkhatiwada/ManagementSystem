using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepositroy : IEmployeeRepostiory
    {
        private readonly AppDbContext _context;
        public SQLEmployeeRepositroy(AppDbContext context)
        {
            this._context = context;

        }

        public Employees Add(Employees employees)
        {
            _context.Employees.Add(employees);
            _context.SaveChanges();
            return employees;
        }

        public Employees Delete(int id)
        {
            Employees emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return emp;

        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employees getEmployeeDetails(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employees Update(Employees employeeschanges)
        {
            var employee = _context.Employees.Attach(employeeschanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employeeschanges;
        }
    }
}
