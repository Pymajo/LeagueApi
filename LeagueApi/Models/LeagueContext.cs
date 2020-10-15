using Microsoft.EntityFrameworkCore;

namespace LeagueApi.Models
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options)
            : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<BuildItem> BuildItems { get; set; }
    }
}
