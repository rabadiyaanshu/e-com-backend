using System.ComponentModel.DataAnnotations;

namespace WebLoginRegisterApi.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }  // ✅ This will store the path to the product image
    }
}
