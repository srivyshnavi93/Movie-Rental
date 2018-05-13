using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{

		public MyDbContext _context;

		public MoviesController()
		{
			_context = new MyDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}



		// GET: Movies/Random
		public ActionResult Random()
		{


			var movies = _context.movies.Include(m=>m.Genre).ToList();


			return View(movies);   

		}

		public ActionResult Edit1(int id)
		{
			return Content("Id  " + id);
		}

		public ActionResult Index(int? pageIndex,String sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (String.IsNullOrWhiteSpace(sortBy))
				sortBy = "Name";

			return Content(String.Format("pageindex={0} sortby={1}",pageIndex,sortBy));
		}

		[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
		public ActionResult ByReleaseDate(int? year,int? month)
		{

			return Content(year+"/"+ month);
		}

		public ActionResult FindDetails(int id)
		{
			var movie = _context.movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();
			return View(movie);
		}

		public ActionResult New()
		{
			var genres = _context.genres.ToList();

			var viewModel = new MovieFormViewModel()
			{
			  
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{

			var movie = _context.movies.SingleOrDefault(m => m.Id == id);
			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel(movie)
			{
				

				
				Genres = _context.genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.genres.ToList()
				};

				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.movies.Single(m => m.Id == movie.Id);
				//TryUpdateModel(customerInDb);

				
				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();

			return RedirectToAction("Random", "Movies");
		}
	}
}