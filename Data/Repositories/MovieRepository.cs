using Practica.Web.MinimalApi.Data.Interfaces;
using Practica.Web.MinimalApi.Models;

namespace Practica.Web.MinimalApi.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _dbContext;

        public MovieRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void CreateMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }
    }
}
