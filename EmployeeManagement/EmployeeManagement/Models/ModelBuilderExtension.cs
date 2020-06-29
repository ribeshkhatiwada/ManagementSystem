using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasData(
                new Employees
                {
                    Id = 4,
                    Name = "Mark",
                    Department = Dept.IT,
                    Email = "Mark@gmail.com"
                }
                );
        }
    }
}
