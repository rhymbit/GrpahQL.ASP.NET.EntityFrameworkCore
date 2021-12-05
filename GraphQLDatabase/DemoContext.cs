using Microsoft.EntityFrameworkCore;

namespace GraphQLDatabase
{
    public class DemoContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;user id=postgres;port=5432;password=postgres;database=graphql";

        public DemoContext() { }
        
        public DemoContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
                options.UseNpgsql(ConnectionString);

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Movie>()
                .HasKey(m => m.Id);

            builder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    Name = "Intestellar",
                    Released = "2021-02-03",
                    Actors = "Martin Corsezi",
                    Writers = "Some Writer",
                    Director = "Joel Shoemacker"
                });

            builder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 2,
                    Name = "The Matrix",
                    Released = "2021-02-03",
                    Actors = "Keanu Reeves",
                    Writers = "Some Writer",
                    Director = "Lana Wachowski"
                });
        }
    }
}
