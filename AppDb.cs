using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask
{
    public class AppDb :DbContext
    {
        public DbSet<DrillBlock> DrillBlocks => Set<DrillBlock>();
        public DbSet<Hole> Holes => Set<Hole>();
        public DbSet<DrillBlockPoint> DrillBlockPoints => Set<DrillBlockPoint>();
        public DbSet<HolePoint> HolePoints => Set<HolePoint>();

        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DrillBlock>().HasData(
                new { Id = 1, Name = "Drill 1", UpdateDate = DateTime.Now.AddMonths(1) },
                new { Id = 2, Name = "Drill 2", UpdateDate = DateTime.Now.AddDays(1) },
                new { Id = 3, Name = "Drill 3", UpdateDate = DateTime.Now.AddMonths(2) }
                );

            modelBuilder.Entity<Hole>().HasData(
                new { Id = 1, Name = "Hole 1", DrillBlockId = 1, Depth = 10.0 },
                new { Id = 2, Name = "Hole 2", DrillBlockId = 1, Depth = 12.0 },
                new { Id = 3, Name = "Hole 3", DrillBlockId = 2, Depth = 15.0 }
                );

            modelBuilder.Entity<DrillBlockPoint>().HasData(
                new { Id = 1, DrillBlockId = 1, Sequence = 1.0, X = 0.0, Y = 0.0, Z = 0.0 },
                new { Id = 2, DrillBlockId = 1, Sequence = 2.0, X = 1.0, Y = 0.0, Z = 0.0 },
                new { Id = 3, DrillBlockId = 2, Sequence = 3.0, X = 0.0, Y = 1.0, Z = 0.0 },
                new { Id = 4, DrillBlockId = 3, Sequence = 4.0, X = 0.0, Y = 0.0, Z = 1.0 }
                );

            modelBuilder.Entity<HolePoint>().HasData(
                new { Id = 1, HoleId = 1, X = 1.0, Y = 0.0, Z = 0.0 },
                new { Id = 2, HoleId = 1, X = 0.0, Y = 1.0, Z = 0.0 },
                new { Id = 3, HoleId = 1, X = 0.0, Y = 0.0, Z = 1.0 }
                );
        }
    }
}
