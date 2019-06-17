using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWeb.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;


        public SellerService(SalesWebContext context)
        {
            _context = context;
        }


        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }


        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

        }


        public async Task<Seller> FindByIdAsync(int id)
        {
            //.Include, puts the Department included to join.
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            //return _context.Seller.Find(id);
            //return _context.Seller.FirstOrDefault(s=> s.Id == id);
        }


        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await FindByIdAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }


        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(s => s.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }


    }
}
