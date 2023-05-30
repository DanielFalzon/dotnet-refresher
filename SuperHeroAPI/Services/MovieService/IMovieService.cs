using System;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.MovieService
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        public Movie? GetSingleMovie(int id);
        public List<Movie>? AddMovie(Movie movie);
        public List<Movie>? UpdateMovie(int id, Movie request);
        public List<Movie>? DeleteMovie(int id);
    }
}