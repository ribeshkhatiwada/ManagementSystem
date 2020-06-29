﻿using System;
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
        public RedirectToActionResult Create(Employees emp)
        {
           Employees newEmp =  _employeeRepostiory.Add(emp);
            return RedirectToAction("details", new { id = newEmp.Id });
        }
        
        
    }
}
