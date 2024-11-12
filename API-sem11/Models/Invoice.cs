namespace API_sem11.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public double Total { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Detail> Details { get; set; }
    }
}
