using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var customers = _db.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _db.Customers.SingleOrDefault(u => u.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

    }
}