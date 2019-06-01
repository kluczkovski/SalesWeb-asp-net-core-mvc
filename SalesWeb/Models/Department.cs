using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

    
        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSelle(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void RemoveSelle(Seller seller)
        {
            Sellers.Remove(seller);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sellers.Sum(s => s.TotalSales(inicial, final));
        }
    }
}
