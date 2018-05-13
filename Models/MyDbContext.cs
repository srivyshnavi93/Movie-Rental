using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Vidly.Models
{
	public class MyDbContext : DbContext
	{

		public DbSet<Movie> movies { get; set;}
		public DbSet<Customer> customers { get; set; }
		public DbSet<MembershipType> membershipTypes { get; set; }
		public DbSet<Genre> genres { get; set; }
		public DbSet<Rental> rentals { get; set; }



	}
	
}