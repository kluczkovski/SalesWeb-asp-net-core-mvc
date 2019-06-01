using System;
using System.Linq;
using System.Collections.Generic;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services.Exceptions;

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


        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(s => s.Id == seller.Id))
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }


    }
}
