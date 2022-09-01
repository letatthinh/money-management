using Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DatabaseContexts
{
    public class MoneyManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConstants.ConnectionString);
        }
    }
}
