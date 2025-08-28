using Microsoft.EntityFrameworkCore;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Data
{
    public class GeneralFormContext : DbContext
    {
        public GeneralFormContext(DbContextOptions<GeneralFormContext> options) : base(options)
        {
        }

       
        public DbSet<GeneralForm> Forms { get; set; }
    }
}
