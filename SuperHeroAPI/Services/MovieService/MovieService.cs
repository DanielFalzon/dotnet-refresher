using System;
using SuperHeroAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SuperHeroAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        public readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public List<Movie>? AddMovie(Movie movie)
        {
            if (_context.Movies.Where(m => m.Title == movie.Title).Count() > 0) return null;

            _context.Movies.Add(movie);

            _context.SaveChanges();

            return _context.Movies.ToList<Movie>();
        }

        public List<Movie>? DeleteMovie(int id)
        {
            Movie? movie = _context.Movies.Find(id);

            if (movie == null) return null;

            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return _context.Movies.ToList<Movie>();
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList<Movie>();
        }

        public Movie? GetSingleMovie(int id)
        {
            return _context.Movies.Find(id);
        }

        public List<Movie>? UpdateMovie(int id, Movie request)
        {
            Movie? movie = _context.Movies.Find(id);

            if (movie == null) return null;

            //Null checks prior to assigning
            movie.ReleaseDate = !(request.ReleaseDate == DateTime.MinValue) ? request.ReleaseDate : movie.ReleaseDate;
            movie.Title = !String.IsNullOrEmpty(request.Title) ? request.Title : movie.Title;
            movie.DateModified = DateTime.Now;

            _context.SaveChanges();

            return _context.Movies.ToList<Movie>();
        }
    }
}