using HireIntelligence.Models;
using Microsoft.EntityFrameworkCore;

namespace HireIntelligence.DB
{
    public class CumulativeViewsDbContext : DbContext
    {
        public DbSet<CumulativeView> CumulativeViews { get; set; }


        public CumulativeViewsDbContext(DbContextOptions<CumulativeViewsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CumulativeView>().ToView("View_CumulativeViews");
        }
    }
}
