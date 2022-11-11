using Microsoft.EntityFrameworkCore;
using SoftAllianceRestApi.Models;

namespace SoftAllianceRestApi.DbContexts
{
    public class MovieInfoContext : DbContext
    {
        public DbSet<Movie> movies { set; get; }
        public DbSet<Genre> genres { set; get; }
        public MovieInfoContext(DbContextOptions<MovieInfoContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //    modelBuilder.Entity<Movie>()
            //        .HasData(
            //       new Movie("Love movie", "Teachning Love", 4, 8, "Germany", DateTime.Now, "erdeedsdsbase64")
            //       {
            //           Id = 1,

            //       },

            //        new Movie("Action movie", "Teachning Action", 4, 7, "Nig", DateTime.Now, "erdeedsdsbase64")
            //        {
            //         Id = 2
            //        });


            //    modelBuilder.Entity<Genre>()
            //     .HasData(
            //       new Genre("Central")
            //       {
            //           Id = 1,
            //          movieId = 1,

            //       },
            //       new Genre("Empire")
            //       {
            //           Id = 2,
            //           movieId = 2,
            //       }
            //       );
            //    base.OnModelCreating(modelBuilder);
            //}

        }
    }
}
