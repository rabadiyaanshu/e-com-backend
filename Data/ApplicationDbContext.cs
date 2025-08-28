using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OrderModel> Orders { get; set; }

        // ✅ Add this line to enable product queries
        public DbSet<ProductModel> Products { get; set; }
    }
}
