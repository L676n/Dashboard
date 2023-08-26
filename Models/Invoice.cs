using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Invoice
    {
        //every table must have a ID as primary key
        [Key]
        public int Id { get; set; }

        //prop + Double tab
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }

        public int QTY { get; set; }

        public float Tax { get; set; }

        public float Discount { get; set; }

        public double Total { get; set; }
    }
}
