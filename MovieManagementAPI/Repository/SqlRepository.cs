
using MovieManagementAPI.DBContext;
using MovieManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.Repository
{
    public class SqlRepository : IMovieRepository
    {
        MovieDBContext _movieDBContext;

        public SqlRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public List<Movie> GetMovies()
        {
            return _movieDBContext.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _movieDBContext.Movies.FirstOrDefault(m => m.MovieId == id);
        }

        public void AddMovie(Movie movie)
        {
            movie.CreatedDate = DateTime.Now;
            
            _movieDBContext.Movies.Add(movie);
            _movieDBContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            var movieToBeUpdated = GetMovieById(movie.MovieId);
            if(movieToBeUpdated != null)
            {
                var movieChanges = _movieDBContext.Movies.Attach(movie);
                movieChanges.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _movieDBContext.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            var movieToBeDeleted = GetMovieById(id);
            if(movieToBeDeleted != null)
            {
                _movieDBContext.Movies.Remove(movieToBeDeleted);
                _movieDBContext.SaveChanges();
            }
        }

        public List<Movie> GetMoviesByNameOrLanguage(string searchQuery)
        {
            List<Movie> movies = _movieDBContext.Movies.ToList();
            List<Movie> filteredMovies = movies.FindAll(m => m.MovieName.ToLower() == searchQuery.ToLower() || m.MovieLanguage.ToLower() == searchQuery.ToLower());
            return filteredMovies;
        }
        
    }
}
