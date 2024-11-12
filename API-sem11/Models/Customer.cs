using System.ComponentModel.DataAnnotations;

namespace API_sem11.Models
{
    public class Customer
    {
        
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        //Relación 1 a muchos:
        public ICollection<Detail> Details { get; set; }
    }
}
