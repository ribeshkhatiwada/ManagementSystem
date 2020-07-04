using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepostiory _employeeRepostiory;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepostiory employeeRepostiory, IHostingEnvironment hostingEnvironment)
        {
            this._employeeRepostiory = employeeRepostiory;
            this.hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model= _employeeRepostiory.GetAllEmployees();
            return View(model);

        }
        [AllowAnonymous]

        public ViewResult Details(int? id)
        {
            Employees employees = _employeeRepostiory.getEmployeeDetails(id.Value);
            if(employees == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee =employees,
                PageTitle = "Employee Details"

            };
            return View(homeDetailsViewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            EmployeeCreatViewModel models = new EmployeeCreatViewModel();
            Employees model = _employeeRepostiory.getEmployeeDetails(id);
            if (model.PhotoPath != null)
            {
               
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.PhotoPath);
                    System.IO.File.Delete(filePath);
                
                model.PhotoPath = ProcessUploadedFile(models);


            }
            _employeeRepostiory.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public IActionResult Create(EmployeeCreatViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
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

        private string ProcessUploadedFile(EmployeeCreatViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);

                }
            }

            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult edit(int id)
        {
            var employee = _employeeRepostiory.getEmployeeDetails(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email,
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employees employees = _employeeRepostiory.getEmployeeDetails(model.Id);
                employees.Name = model.Name;
                employees.Email = model.Email;
                employees.Department = model.Department;
                if(model.Photo != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                       string filePath= Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employees.PhotoPath = ProcessUploadedFile(model);


                }
                _employeeRepostiory.Update(employees);
                return RedirectToAction("index");
            }
            return View();
        }
        
        
    }
}
