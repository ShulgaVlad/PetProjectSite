using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetProjSite.Models
{
    public class AdminProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "e-mail")]
        public string? Email { get; set; }
    }
}
