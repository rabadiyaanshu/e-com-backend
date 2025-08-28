using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

      
        public DbSet<UserModel> Users { get; set; }
    }
}
