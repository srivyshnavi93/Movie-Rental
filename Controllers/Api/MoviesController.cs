using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private MyDbContext _context;

		public MoviesController()
		{
			_context = new MyDbContext();
		}

		public IEnumerable<MovieDto> GetMovies()
		{
			return _context.movies
				.Include(m => m.Genre)
				.ToList()
				.Select(Mapper.Map<Movie, MovieDto>);
		}

		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.movies.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		[HttpPost]
		
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			_context.movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		[HttpPut]
		
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movieInDb = _context.movies.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
				return NotFound();

			Mapper.Map(movieDto, movieInDb);

			_context.SaveChanges();

			return Ok();
		}

		[HttpDelete]
	
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.movies.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
				return NotFound();

			_context.movies.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}