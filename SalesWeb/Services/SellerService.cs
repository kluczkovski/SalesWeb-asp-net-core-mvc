using System;
using SalesWeb.Data;
using SalesWeb.Models;
using System.Linq;
using System.Collections.Generic;

namespace SalesWeb.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;

        public SellerService(SalesWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }

        public Seller FindById(int id)
        {
            return _context.Seller.Find(id);
        }

        public void Remove(int id)
        {
            var obj = FindById(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}
