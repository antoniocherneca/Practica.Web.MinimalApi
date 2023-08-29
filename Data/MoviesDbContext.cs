using Microsoft.EntityFrameworkCore;
using Practica.Web.MinimalApi.Models;

namespace Practica.Web.MinimalApi.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
            FillMovies();
        }

        public DbSet<Movie> Movies { get; set; }

        private void FillMovies()
        {
            if (Movies.Count() == 0)
            {
                Movies.Add(new Movie { Id = 1, Description = "Scream VI", Duration = 123, Gender = "Terror" });
                Movies.Add(new Movie { Id = 2, Description = "Sisu", Duration = 91, Gender = "Bélica" });
                Movies.Add(new Movie { Id = 3, Description = "Air", Duration = 112, Gender = "Drama" });
                SaveChanges();
            }
        }
    }
}
