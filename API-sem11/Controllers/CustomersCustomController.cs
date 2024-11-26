using API_sem11.Models;
using API_sem11.Request;
using API_sem11.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_sem11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomersCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Customer> GetAll()
        {
            return _context.Customers.Where(c => !c.IsDeleted).ToList();
        }

        [HttpGet]
        public List<Customer> GetByName(string name)
        {
            return _context.Customers.Where(c => (c.FirstName + " " + c.LastName).Contains(name) && !c.IsDeleted).ToList();
        }

        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        [HttpPost]
        public void Insert(Customer customer)
        {
            customer.IsDeleted = false;
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(int id, Customer updatedCustomer)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null && !customer.IsDeleted)
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.DocumentNumber = updatedCustomer.DocumentNumber;
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null && !customer.IsDeleted)
            {
                customer.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        //
        [HttpPost]
        public List<CustomerResponseV1> GetClientsBySearch([FromBody] CustomerRequestV1 request)
        {
            // Empezamos con la consulta base
            var query = _context.Customers.AsQueryable();

            // Filtramos según los parámetros proporcionados
            if (!string.IsNullOrEmpty(request.FirstName))
            {
                query = query.Where(c => c.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                query = query.Where(c => c.LastName.Contains(request.LastName));
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(c => c.Email.Contains(request.Email));
            }

            // Realizamos el ordenamiento por apellido de manera descendente
            var customers = query.OrderByDescending(c => c.LastName.Trim())
                      .Select(c => new CustomerResponseV1
                      {
                          CustomerId = c.CustomerID,
                          FirstName = c.FirstName,
                          LastName = c.LastName,
                          Email = c.Email
                      })
                      .ToList();
            return customers;
        }
    }
}