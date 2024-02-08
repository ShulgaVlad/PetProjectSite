using System.ComponentModel.DataAnnotations;

namespace PetProjSite.Models
{
    public class UserProfile
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "e-mail")]
        public string e_mail { get; set; }

        public int? phone_number { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string surname { get; set; }

        [Required]
        public string password { get; set; }
    }
}
