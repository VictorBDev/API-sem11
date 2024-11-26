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
            return _context.Products.Where(p => !p.IsDeleted).ToList();
        }

        [HttpGet]
        public List<Product> GetByName(string name)
        {
            return _context.Products.Where(p => p.Name.Contains(name) && !p.IsDeleted).ToList();
        }

        [HttpGet]
        public Product GetById(int id)
        {
            return _context.Products.Where(p => p.ProductID == id && !p.IsDeleted).FirstOrDefault();
        }

        //[HttpPost]
        //public void Insert(Product product)
        //{
        //    _context.Products.Add(product);
        //    _context.SaveChanges();
        //}

        [HttpPut]
        public void Update(int id, Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product != null && !product.IsDeleted)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null && !product.IsDeleted)
            {
                product.IsDeleted = true;
                _context.SaveChanges();
            }
        }
        //Un método lista se puede pasar como POST


        [HttpPut]
        public void UpdatePrice(ProductRequestV1 request)
        {
            Product product = _context.Products.Where(x => x.ProductID == request.Id).FirstOrDefault();

            product.Price = request.Price;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpPost]
        public void Insert(ProductInsert reques)
        {
            Product product = new Product
            {
                Name = reques.Name,
                Price = reques.Price,
                IsDeleted = true
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        //Retorna precio
        [HttpGet]
        public List<ProductResponseV1> GetAllPrice()
        {
            List<Product> products = _context.Products.ToList();

            var response = products.Select(x =>
                                                new ProductResponseV1
                                                {
                                                    Id = x.ProductID,
                                                    Price = x.Price
                                                }).ToList();
            return response;
        }

        //Retorna categoría
        [HttpGet]
        public List<ProductResponseV2> GetAllCategory()
        {
            List<Product> products = _context.Products.ToList();

            var response = products.Select(x =>
                                                new ProductResponseV2
                                                {
                                                    Id = x.ProductID,
                                                    Category = x.Category
                                                }).ToList();
            return response;
        }

        //P.08

    }
}