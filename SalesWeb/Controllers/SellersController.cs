using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Services;
using SalesWeb.Models;


namespace SalesWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerServices;

        public SellersController(SellerServices sellerServices)
        {
            _sellerServices = sellerServices;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _sellerServices.FindAll();
            ViewData["Test"] = "EVerton";
            return View(list);
        }

        // GET: Crate Seller
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Seller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
