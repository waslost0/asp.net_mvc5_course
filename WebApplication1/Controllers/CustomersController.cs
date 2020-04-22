using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult New()
        {
            var membershipTypes = _db.MembershipTypes.ToList();
            var customer = new Customer { };
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = customer
            };


            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        public IActionResult Save(Customer customer)
        {


            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {

                    Customer = customer,
                    MembershipTypes = _db.MembershipTypes.ToList()
            };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _db.Customers.Add(customer);
            }
            else
            {
                _db.Customers.Update(customer);
                //var customerInDb = _db.Customers.Single(c => c.Id == customer.Id);

                //customerInDb.Name = customer.Name;
                //customerInDb.Birthdate = customer.Birthdate;
                //customerInDb.MembershipType = customer.MembershipType;
                //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Index()
        {
            var customers = _db.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _db.Customers.Include(u => u.MembershipType).SingleOrDefault(u => u.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _db.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }


        #region APICalls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _db.Customers.Include(u => u.MembershipType).ToListAsync(); 

            return Json(new { data = await _db.Customers.ToListAsync() });
        }
        #endregion

    }
}