using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace SalesWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Department> list = new List<Department>
            {
                new Department {Id = 1, Name="Eletronics"},
                new Department {Id = 2, Name="Fashion"},
                new Department {Id = 3, Name="Books"},
                new Department {Id = 4, Name="Homes"},
            };

            return View(list);
        }
    }
}
