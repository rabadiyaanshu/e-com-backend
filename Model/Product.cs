namespace WebLoginRegisterApi.Model
{
    public class Product
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // ✅ Add this line if missing
        public string ImageUrl { get; set; }
    }
}