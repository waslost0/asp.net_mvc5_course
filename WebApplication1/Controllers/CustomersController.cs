using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _repo;
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _repo = new CustomersRepository(db);
            _db = db;
        }

        public IActionResult New()
        {
            var customer = new Customer { };
            var membershipTypes = _db.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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
                _repo.CreateCustomer(customer);
            }
            else
            {
                _repo.UpdateCustomer(customer.Id, customer);
            }

            return RedirectToAction("Index", "Customers");
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var customers = _repo.GetAll();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _repo.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _repo.GetCustomer(id);
            if (customer == null)
                return NotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _db.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var customer = _repo.GetCustomer(id);
            if (customer == null)
                return NotFound();
            _repo.DeleteCustomer(id);
            return View("Index");
        }

    }
}