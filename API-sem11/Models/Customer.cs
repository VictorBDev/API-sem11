using System.ComponentModel.DataAnnotations;

namespace API_sem11.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        //public ICollection<Invoice> Invoices { get; set; }

        //Relación 1 a muchos:
        //public ICollection<Detail> Details { get; set; }
    }
}
