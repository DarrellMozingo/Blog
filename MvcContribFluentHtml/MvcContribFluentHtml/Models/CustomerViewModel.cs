using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcContribFluentHtml.Models
{
	public class CustomerViewModel
	{
		public int Id { get; set; }

		[StringLength(5)]
		public string Name { get; set; }

		public CustomerType Type { get; set; }
		public AddressViewModel Address { get; set; }
		public IList<OrderViewModel> Orders { get; set; }
	}
}