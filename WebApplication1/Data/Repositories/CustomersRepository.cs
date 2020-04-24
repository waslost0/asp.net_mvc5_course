using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
 
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomersRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Customers.Include(c => c.MembershipType).ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public void CreateCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
       
            var customerInDb = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return false;
            }

            _db.Customers.Update(customer);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var customerInDb = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return false;
            }

            _db.Customers.Remove(customerInDb);
            _db.SaveChanges();
            return true;
        }
    }
}
