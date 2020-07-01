using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpstatusCodeHandler(int statusCode)
        {
            if (statusCode==404)
            {
                ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
            }
            return View("NotFound");
        }
    }
}
