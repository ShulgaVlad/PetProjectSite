using System.ComponentModel.DataAnnotations;

namespace PetProjSite.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]

        public string? product_name { get; set; }
        [Required]

        public int? product_price { get; set; }
		[Required]

		public string? product_description { get; set; }
		[Required]

		public string? product_photo { get; set; }
		[Required]

		public string? total_category { get; set; }
		[Required]

		public string? sub_category { get; set; }
	}
}
