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
	public class CustomersController : Controller
	{

		public MyDbContext _context;

		public CustomersController()
		{
			_context = new MyDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		 
		// GET: Customers
	
		public ActionResult Index()
		{
			/*  var movie = new List<Movie>{
				  new Movie { Name="Vyshnavi" },
				  new Movie { Name="Pavani" } };


			  var customers = new List<Customer>{
				  new Customer { Name="Customer 1" },
				  new Customer { Name="Customer 2" } };

			  var viewModel = new RandomMovieViewModel { Movie = movie, Customers = customers };

			  var viewResult = new ViewResult();
			  viewResult.ViewData.Model = movie;*/

		var customers = _context.customers.Include(c => c.MembershipType).ToList();

			
			return View(customers);
		}

		
		

		public ActionResult Details(int id)
		{
			var customer = _context.customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();
			return View(customer);
		}

		public ActionResult New()
		{
			var membershipTypes = _context.membershipTypes.ToList();

			var viewModel = new CustomerFormViewModel()
			{
				
				MembershipTypes = membershipTypes
			};

			return View("CustomerForm",viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel(customer)
				{
					
					MembershipTypes = _context.membershipTypes.ToList()
				};

				return View("CustomerForm", viewModel);
			}



			if (customer.Id == 0)
			{
				_context.customers.Add(customer);
			}
			else
			{
				var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
				//TryUpdateModel(customerInDb);

				customerInDb.Name = customer.Name;
				customerInDb.BirthDate = customer.BirthDate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			
			_context.SaveChanges();

			return RedirectToAction("Index","Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.customers.SingleOrDefault(c => c.Id == id);
			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel(customer)
			{
				
			    MembershipTypes = _context.membershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}
	}
}