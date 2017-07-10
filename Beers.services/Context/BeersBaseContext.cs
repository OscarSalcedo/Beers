using Beers.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Beers.services.Context
{
    public class BeersBaseContext : DbContext
    {

        public BeersBaseContext(): base("BeersBaseContext")
        {

        }

        //public DbSet<Student> Students { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<BeerType> BeerType { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Tapas> Tapas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
