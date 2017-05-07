using System.Data.Entity;
using Domain;

namespace Kladr.Core.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConection") { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Flat> Flats { get; set; }
    }
}
