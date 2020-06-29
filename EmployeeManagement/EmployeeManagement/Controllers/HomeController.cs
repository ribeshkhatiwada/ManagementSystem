using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepostiory _employeeRepostiory;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepostiory employeeRepostiory, IHostingEnvironment hostingEnvironment)
        {
            this._employeeRepostiory = employeeRepostiory;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var model= _employeeRepostiory.GetAllEmployees();
            return View(model);

        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepostiory.getEmployeeDetails(id??1),
                PageTitle = "Employee Details"

            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreatViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                  string uploadsFolder =  Path.Combine(hostingEnvironment.WebRootPath, "images");
                  uniqueFileName= Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                Employees newEmp = new Employees
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepostiory.Add(newEmp);
                return RedirectToAction("details", new { id = newEmp.Id });
            }
            return View();
           
        }
        
        
    }
}
