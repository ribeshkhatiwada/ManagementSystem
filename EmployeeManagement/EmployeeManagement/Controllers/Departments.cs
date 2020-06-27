//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using EmployeeManagement.Models;
//using EmployeeManagement.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace EmployeeManagement.Controllers
//{
//    [Route("[controller]/[action]")]
//    public class Departments : Controller
//    {
//        private readonly IEmployeeRepostiory _employeeRepostiory;

//        public Departments(IEmployeeRepostiory employeeRepostiory)
//        {
//            this._employeeRepostiory = employeeRepostiory;
//        }
//        [Route("~/")]
//        [Route("~/Home")]
//        public ViewResult Index()
//        {
//            var model = _employeeRepostiory.GetAllEmployees();
//            return View("~/Views/Home/Details.cshtml",model);

//        }

//        [Route("{id?}")]
//        public ViewResult Details(int? id)
//        {
//            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
//            {
//                Employee = _employeeRepostiory.getEmployeeDetails(id ?? 1),
//                PageTitle = "Employee Details"

//            };
//            return View(homeDetailsViewModel);
//        }
//    }
//}
