using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models.DTOs;
using SuperHeroAPI.Services.MovieService;
namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IMovieService _movieService { get; }
        public IMapper _mapper { get; }

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAllMovies()
        {
            return Ok(_movieService.GetAllMovies()
                .Select(movie => _mapper.Map<MovieDto>(movie))
            );
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetSingleMovie(int id)
        {
            Movie? movie = _movieService.GetSingleMovie(id);
            if (movie is null)
                return NotFound("Movie not found.");

            return Ok(_mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public ActionResult<List<MovieDto>?> AddMovie(MovieDto newMovie)
        {
            Movie movie = _mapper.Map<Movie>(newMovie);

            List<Movie>? result = _movieService.AddMovie(movie);

            if (result is null) return Conflict("Movie already created");

            return Ok(result
                .Select(movie => _mapper.Map<MovieDto>(movie))
            );
        }

        [HttpPut("{id}")]
        public ActionResult<List<MovieDto>> Updatemovie(int id, MovieDto updatedMovie)
        {
            Movie movie = _mapper.Map<Movie>(updatedMovie);

            List<Movie>? result = _movieService.UpdateMovie(id, movie);
 
            if (result is null)
                return NotFound("Movie not found");

            return Ok(result
                .Select(movie => _mapper.Map<MovieDto>(movie))
            );
        }

        [HttpDelete("{id}")]
        public ActionResult<List<MovieDto>> DeleteMovie(int id)
        {
            List<Movie>? result = _movieService.DeleteMovie(id);

            if (result is null)
                return NotFound("Movie not found.");

            return Ok(result
                .Select(movie => _mapper.Map<MovieDto>(movie))
            );
        }
    }
}
