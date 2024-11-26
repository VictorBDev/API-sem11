using API_sem11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_sem11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoicesCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Invoice> GetAll()
        {
            return _context.Invoices.Where(c=> !c.IsDeleted).ToList();
        }

        [HttpPost]
        public void Insert(Invoice invoice)
        {
            invoice.IsDeleted = true;
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(int id, Invoice updateInvoice)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null && !invoice.IsDeleted)
            {
                invoice.
            }
        }


    }
}
