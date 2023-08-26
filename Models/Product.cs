using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }
    }
}
