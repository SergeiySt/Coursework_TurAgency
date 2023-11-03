using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tur_agen_asp_net.Models
{
    public class UserOrderHistory
    {
        [Key]
        public int id_user_order_history { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public Users User { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
