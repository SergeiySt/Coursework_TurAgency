using System.ComponentModel.DataAnnotations;

namespace Tur_agen_asp_net.Models
{
    public class Users
    {
		[Key]
		public int id_users { get; set; }
        [Required]
        public string? UName { get; set; }
        [Required]
        public string? USurname { get; set; }
        [Required]
        public string? ULogin { get; set; }
        [Required]
        public string? UPassword { get; set; }
        [Required]
        public string? UEmail { get; set; }
        [Required]
        public int UPhone { get; set; }

        public bool UIsAdmin { get; set; }
    }
}
