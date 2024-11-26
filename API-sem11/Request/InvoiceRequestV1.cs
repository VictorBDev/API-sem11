namespace API_sem11.Request
{
    public class InvoiceRequestV1
    {
        public int CustomerID { get; set; }
        public DateTime date { get; set; }
        public int InvoiceNumber { get; set; }
        public float total { get; set; }
    }
}
