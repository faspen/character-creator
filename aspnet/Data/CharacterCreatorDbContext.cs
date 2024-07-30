using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Data
{
    public class CharacterCreatorDbContext : DbContext
    {
        public CharacterCreatorDbContext(DbContextOptions<CharacterCreatorDbContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
    }
}