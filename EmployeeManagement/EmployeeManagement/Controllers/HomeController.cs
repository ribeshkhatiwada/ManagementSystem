using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepostiory _employeeRepostiory;
        public HomeController(IEmployeeRepostiory employeeRepostiory)
        {
            this._employeeRepostiory = employeeRepostiory;
        }
        public ViewResult Index(int id)
        {
            var model= _employeeRepostiory.GetAllEmployees();
            return View(model);

        }
        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepostiory.getEmployeeDetails(1),
                PageTitle = "Employee Details"

            };
            return View(homeDetailsViewModel);
        }
        
    }
}
