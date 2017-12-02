using BravisWorkplanner.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BravisWorkplanner.Data
{
    public class BravisDbContext : DbContext
    {
        public BravisDbContext(DbContextOptions<BravisDbContext> options)
            :base(options)
        {
        }
        public DbSet<WorkOrder> WorkOrders { get; set; }
    }
}