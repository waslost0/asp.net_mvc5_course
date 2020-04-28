using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetCustomer(int id);
        void CreateCustomer(Customer customer);

        bool UpdateCustomer(int id, Customer customer);

        bool DeleteCustomer(int id);

    }
}
