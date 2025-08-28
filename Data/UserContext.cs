using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Model;



namespace WebLoginRegisterApi.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) :base(options){ }
        public DbSet<User> Users { get; set; }
    }
}
