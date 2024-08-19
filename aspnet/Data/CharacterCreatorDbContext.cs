using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Data
{
    public class CharacterCreatorDbContext : DbContext
    {
        public CharacterCreatorDbContext(DbContextOptions<CharacterCreatorDbContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Race> Races { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Race)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.RaceId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Faction)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.FactionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Location)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}