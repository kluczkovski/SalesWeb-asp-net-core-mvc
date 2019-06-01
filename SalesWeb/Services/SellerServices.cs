using System;
using SalesWeb.Data;
using SalesWeb.Models;
using System.Linq;
using System.Collections.Generic;

namespace SalesWeb.Services
{
    public class SellerServices
    {
        private readonly SalesWebContext _context;

        public SellerServices(SalesWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
