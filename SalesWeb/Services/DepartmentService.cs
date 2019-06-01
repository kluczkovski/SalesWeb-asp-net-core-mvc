using System;
using System.Linq;
using System.Collections.Generic;
using SalesWeb.Models;
using SalesWeb.Data;

namespace SalesWeb.Services
{
    public class DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService(SalesWebContext salesWebContext)
        {
            _context = salesWebContext;
        }

        public IEnumerable<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }

    }
}
