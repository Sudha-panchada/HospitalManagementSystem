using Microsoft.EntityFrameworkCore;

namespace FinancialDataServices.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Financialdata> Financialdata { get; set; }
    }
}
