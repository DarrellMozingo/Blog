using System.Collections.Generic;
using System.Web.Mvc;
using MvcContribFluentHtml.Models;

namespace MvcContribFluentHtml.Controllers
{
	public class CustomerController : Controller
	{
		// In reality, we'd take in a customer Id and use that to load the customer from the database.
		public ActionResult Edit()
		{
			var customerViewModelLoadedFromDatabase = new CustomerViewModel
			                                          	{
			                                          		Id = 10,
			                                          		Name = "John",
			                                          		Type = CustomerType.Standard,
			                                          		Address = new AddressViewModel
			                                          		          	{
			                                          		          		Street = "123 Easy St.",
			                                          		          		City = "Beverly Hills",
			                                          		          		State = "CA",
			                                          		          		Zip = "90210"
			                                          		          	},
			                                          		Orders = new List<OrderViewModel>
			                                          		         	{
			                                          		         		new OrderViewModel
			                                          		         			{
			                                          		         				Id = 300,
			                                          		         				ApplyDiscount = true,
			                                          		         				Quantity = 10
			                                          		         			},
			                                          		         		new OrderViewModel
			                                          		         			{
			                                          		         				Id = 301,
			                                          		         				ApplyDiscount = false,
			                                          		         				Quantity = 20
			                                          		         			}
			                                          		         	}
			                                          	};

			return View("Edit", customerViewModelLoadedFromDatabase);
		}

		public ActionResult Update(CustomerViewModel viewModel)
		{
			// Update customer using populated viewModel here.

			TempData["Id"] = viewModel.Id;
			TempData["Name"] = viewModel.Name;
			TempData["Type"] = viewModel.Type;
			TempData["Street"] = viewModel.Address.Street;
			TempData["Order1Quantity"] = viewModel.Orders[0].Quantity;
			TempData["Order2ApplyDiscount"] = viewModel.Orders[1].ApplyDiscount;

			return this.RedirectToAction("Edit");
		}
	}
}