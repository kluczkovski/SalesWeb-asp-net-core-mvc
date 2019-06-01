using System;
using System.Linq;
using System.Collections.Generic;
using SalesWeb.Models;
using SalesWeb.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWeb.Services
{
    public class DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService(SalesWebContext salesWebContext)
        {
            _context = salesWebContext;
        }

        public async Task<IEnumerable<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }

    }
}
