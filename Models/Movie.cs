using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie 
	{
		
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public String Name { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Genre")]
		[Required]
		public byte GenreId { get; set; }

		public DateTime DateAdded { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime? ReleaseDate { get; set; }

		[Display(Name = "Number in Stock")]
		[Range(1, 20)]
		public byte NumberInStock { get; set; }

		public byte NumberAvailable { get; set; }
	}
}