using API_sem11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_sem11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public ProductsCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        [HttpGet]
        public List<Product> GetByName(string name)
        {
            return _context.Products.Where(x => x.Name.Contains(name)).ToList();
        }

        [HttpGet]
        public Product GetById(int id)
        {
            return _context.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }

        [HttpPost]
        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            
        }
        
        [HttpPut]
        public Product Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductID);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);
                _context.SaveChanges();
            }
            return product;
        }

        [HttpDelete]
        public Product Delete (int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

    }
}
