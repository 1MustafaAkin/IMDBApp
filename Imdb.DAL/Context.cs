using Imdb.DAL.Mapping;
using Imdb.DATA.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public static Context Create()
        {
            return new Context();
        }
        public Context():base("DefaultContext")
        {
            //Database.Connection.ConnectionString = @"server = (localdb)\MSSQLLocalDB; database = Imdb; Trusted_Connection=True;";
        }
        
        public DbSet<Categories> Category { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<MoviesSeriesCategory> MoviesSeriesCategory { get; set; }
        public DbSet<MoviesSeriesEmployee> MoviesSeriesEmployee { get; set; }
        public DbSet<MoviesSeries> MoviesSeries { get; set; }
        public DbSet<MoviesSeriesWatchList> MoviesSeriesWatchList { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Season> Season { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WatchList> WatchList { get; set; }
        public DbSet<WatchState> WatchState { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CountryMapping());
            modelBuilder.Configurations.Add(new EmployeeMapping());
            modelBuilder.Configurations.Add(new MoviesSeriesCategoryMapping());
            modelBuilder.Configurations.Add(new MoviesSeriesEmployeeMapping());
            modelBuilder.Configurations.Add(new MoviesSeriesMapping());
            modelBuilder.Configurations.Add(new MovieSeriesWatchListMapping());
            modelBuilder.Configurations.Add(new NewsMapping());
            modelBuilder.Configurations.Add(new RatingMapping());
            modelBuilder.Configurations.Add(new RolesMapping());
            modelBuilder.Configurations.Add(new SeasonMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new WatchListMapping());
            modelBuilder.Configurations.Add(new WatchStateMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
