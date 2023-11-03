using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Tur_agen_asp_net.Models
{
    public class Tour
    {
        [Key]
        public int id_tour { get; set; }
        [Required]
        public string? TName_tour { get; set; }
        [Required]
        public string? TCountry { get; set;}
        [Required]
        public string? TTown { get; set;}
        [Required]
        public string? TDescription { get; set; }
        [Required]
        public decimal TPrice { get; set;}
        [Required]
        public int TCount { get; set;}
        [Required]
        public string? TUrl { get; set;}
    }
}
