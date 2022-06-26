using MovieManagementAPI.Model;
using MovieManagementAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        List<Movie> _movieList;

        public MovieRepository()
        {
            _movieList = new List<Movie>();
        }

        public List<Movie> GetMovies()
        {
            return _movieList;
        }

        public Movie GetMovieById(int id)
        {
            return _movieList.Find(m => m.MovieId == id);
        }

        public void AddMovie(Movie movie)
        {
            movie.MovieId = _movieList.Count > 0 ? _movieList.Max(m => m.MovieId) + 1 : 1;
            movie.CreatedDate = DateTime.Now;
            _movieList.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            Movie movieToBeEdited = GetMovieById(movie.MovieId);
            if (movieToBeEdited != null)
            {
                movieToBeEdited.MovieName = movie.MovieName;
                movieToBeEdited.MovieDescription = movie.MovieDescription;
                movieToBeEdited.MovieLanguage = movie.MovieLanguage;
                movieToBeEdited.MovieCategory = movie.MovieCategory;
                movieToBeEdited.MovieRentalPrice = movie.MovieRentalPrice;
            }
        }

        public void DeleteMovie(int id)
        {
            Movie movieToBeDeleted = GetMovieById(id);
            if (movieToBeDeleted != null)
            {
                _movieList.Remove(movieToBeDeleted);
            }
        }

        public List<Movie> GetMoviesByNameOrLanguage(string searchQuery)
        {
            List<Movie> movies = _movieList.FindAll(m => m.MovieName.ToLower() == searchQuery.ToLower() || m.MovieLanguage.ToLower() == searchQuery.ToLower());
            return movies;
        }

    }
}
