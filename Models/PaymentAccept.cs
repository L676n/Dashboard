using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
	public class PaymentAccept
	{
		[Key]
		public int Id { get; set; }

		[Required]
        public string Payment { get; set; }
    }
}
