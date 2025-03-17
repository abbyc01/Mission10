using Microsoft.EntityFrameworkCore;

namespace FullStackFun.Data;

public class BowlingDbContext : DbContext
{
    public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options) { }

    public DbSet<Bowler> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>()
            .HasOne(b => b.Team)
            .WithMany(t => t.Bowlers)
            .HasForeignKey(b => b.TeamID);
    }
}
