using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class CustomerFormViewModel
	{
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		//public Customer Customer { get; set; }

		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public String Name { get; set; }

		[Display(Name = "Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? BirthDate { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		public CustomerFormViewModel()
		{
			Id = 0;
		}

		public CustomerFormViewModel(Customer customer)
		{
			Id = customer.Id;
			Name = customer.Name;
			BirthDate = customer.BirthDate;
			IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			MembershipTypeId = customer.MembershipTypeId;

		}
	}
}