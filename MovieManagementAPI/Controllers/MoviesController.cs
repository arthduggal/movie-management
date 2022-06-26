using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagementAPI.Model;
using MovieManagementAPI.Repository;
using MovieManagementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("/api/Movies")]
        [Authorize]
        public IActionResult GetMovies()
        {
            var allMovies = _movieRepository.GetMovies();
            return Ok(allMovies);
        }

        [HttpGet]
        [Route("/api/Movies/{id}")]
        [Authorize]
        public IActionResult MovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound($"Movie with Id = {id} is not found");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("/api/Movies/Search/{searchQuery}")]
        [Authorize]
        public IActionResult SearchMovieByName(string searchQuery)
        {
            var movies = _movieRepository.GetMoviesByNameOrLanguage(searchQuery);
            if (movies == null)
            {
                return NotFound($"No Movies found");
            }
            return Ok(movies);
        }

        [HttpPost]
        [Route("/api/Movies")]
        [Authorize]
        public IActionResult AddMovie([FromBody] AddMovieViewModel addMovieViewModel)
        {
            Movie movie = new Movie
            {
                MovieName=addMovieViewModel.MovieName,
                MovieLanguage=addMovieViewModel.MovieLanguage,
                MovieCategory=addMovieViewModel.MovieCategory,
                MovieDescription=addMovieViewModel.MovieDescription,
                MovieRentalPrice=addMovieViewModel.MovieRentalPrice
            };
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            movie.CreatedBy = this.User.Identity.Name;
            _movieRepository.AddMovie(movie);
            return CreatedAtAction("MovieById", new { id = movie.MovieId }, movie);
        }


        [HttpPut]
        [Authorize]
        [Route("/api/Movies/{id}")]
        public IActionResult EditMovie(int id, [FromBody] EditMovieViewModel editMovieViewModel)
        {
            Movie movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound($"Movie with Id = {id} is not found");
            }
            movie.MovieRentalPrice = editMovieViewModel.MovieRentalPrice;
            movie.MovieName = editMovieViewModel.MovieName;
            movie.MovieLanguage = editMovieViewModel.MovieLanguage;
            movie.MovieDescription = editMovieViewModel.MovieDescription;
            movie.MovieCategory = editMovieViewModel.MovieCategory;

            _movieRepository.UpdateMovie(movie);
            return Ok(movie);
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/Movies/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound($"Movie with Id = {id} is not found");
            }
            _movieRepository.DeleteMovie(id);
            return Ok();
        }
    }
}
