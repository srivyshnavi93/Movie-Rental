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
	public class CustomersController : ApiController
	{

		private MyDbContext _context;

		public CustomersController()
		{
			_context = new MyDbContext();
		}

		//GET /api/customers
		public IEnumerable<CustomerDto> GetCustomers()
		{
			return _context.customers
				.Include(c => c.MembershipType)
				.ToList()
				.Select(Mapper.Map<Customer,CustomerDto>);
		}

		//GET /api/customers/1
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return NotFound();

			return Ok(Mapper.Map<Customer,CustomerDto>(customer));


		}

		//POST /api/customers

		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{

			if (!ModelState.IsValid)
				return BadRequest();

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

			_context.customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id= customer.Id;

			return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
		}

		//PUT /api/customers/1
		[HttpPut]
		public void Updatecustomer(int id, CustomerDto customerDto)
		{

			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(customerDto, customerInDb);

			_context.SaveChanges();
		}

		//DELETE /api/customers/1
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.customers.Remove(customerInDb);
			_context.SaveChanges();

		}
	}
}
