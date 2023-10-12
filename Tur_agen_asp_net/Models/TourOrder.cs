using System.ComponentModel.DataAnnotations;

namespace Tur_agen_asp_net.Models
{
    public class TourOrder
    {
        [Key]
        public int id_tour_oder { get; set; }
        public int id_tour { get; set; }
        public int id_users { get; set; }
        public int TOCount { get; set;}
        public decimal TOSumm { get; set; }


        //public Tour Tour { get; set; }
        //public Users User { get; set; }
    }
}
