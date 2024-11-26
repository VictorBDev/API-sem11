using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_sem11.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; } //Eliminación lógica

        [NotMapped]
        public string Category { get; set; }
        [NotMapped]
        public string Date { get; set; }
        [NotMapped]
        public string Description { get; set; }
    }
}
