using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tur_agen_asp_net.Models
{
    public class TourOrder
    {
        [Key]
        public int id_tour_order { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public Tour? Tour { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public Users? User { get; set; }

        [Required]
        public int TOQuantity { get; set; }

        [Required]
        public decimal TOPrice { get; set; }

        public decimal TotalAmount => TOQuantity * TOPrice;
    }
}
