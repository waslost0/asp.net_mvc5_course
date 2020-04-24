using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Repositories;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly ICustomersRepository _repo;

        public CustomersController(ApplicationDbContext db)
        {
            _repo = new CustomersRepository(db);
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
            var mapper = new Mapper(config);

            var users = mapper.Map<List<Customer>>(_repo.GetAll());

            return new OkObjectResult(users);

            //return CreatedAtAction(nameof(customers), customers);
        }


        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetCustomer(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
            var mapper = new Mapper(config);

            var customer = mapper.Map<CustomerDto>(_repo.GetCustomer(id));

            //var customer = _repo.GetCustomer(id);

            if (customer == null)
            {
                return NotFound(customer);
            }

            return new OkObjectResult(customer);
        }


        // POST: api/customers/create
        [HttpPost("create")]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _repo.CreateCustomer(customer);

            //return new ObjectResult(customer) { StatusCode = 400 };
            return Created(Url.ActionLink("CreateCustomer", "CustomersController"), customer);

        }


        // PUT: api/customers/update
        [HttpPut("update")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return new ObjectResult(customer) { StatusCode = 400 };

            var customerInDb = _repo.UpdateCustomer(id, customer);


            return !customerInDb ?
                new ObjectResult(new { customerInDb }) { StatusCode = 400 } :
                new OkObjectResult(new { customerInDb }) { StatusCode = 200 };
        }

        // DELETE api/customers/delete
        [HttpDelete("delete")]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_repo.DeleteCustomer(id))
                return BadRequest();

            return new OkObjectResult(id) { StatusCode = 201};
        }
    }


}