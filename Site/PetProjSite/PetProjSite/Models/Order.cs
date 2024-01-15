using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetProjSite.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]

        public UserProfile? UserProfile { get; set; }       
        [ForeignKey("ProductId")]

        public Product? Product { get; set; }
    }
}
