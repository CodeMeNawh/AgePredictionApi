using AgePredictionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgePredictionApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AgePrediction> AgePredictions { get; set; }
    }
}
