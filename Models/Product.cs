using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }
<<<<<<< HEAD

        public string Image { get; set; }

        public double Price { get; set; }
=======
>>>>>>> 054a4bacd529ccc22a35d039283f75f5f735bba5
    }
}
