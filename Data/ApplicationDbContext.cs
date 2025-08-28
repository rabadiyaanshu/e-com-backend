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

       
        public DbSet<ProductModel> Products { get; set; }
    }
}
