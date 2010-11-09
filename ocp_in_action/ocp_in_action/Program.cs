using System;
using System.Collections.Generic;
using StructureMap;

namespace ocp_in_action
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			ObjectFactory.Initialize(y => y.Scan(x =>
			                                     {
			                                     	x.TheCallingAssembly();
													x.AddAllTypesOf<ICustomer_check>();
			                                     }));

			var customers = get_customers_from_somewhere();

			var check_runner = ObjectFactory.GetInstance<Check_runner>();
			var warnings = check_runner.run_checks_on(customers);

			foreach (var warning in warnings)
			{
				Console.WriteLine(warning);
			}

			Console.ReadLine();
		}

		private static IEnumerable<Customer> get_customers_from_somewhere()
		{
			// database, webservice, whatever.
			return new[]
			       	{
			       		new Customer
			       			{
			       				name = "Joe Smith",
			       				credit_card = new Credit_card { is_valid = true },
			       				balance = 100,
			       				is_preferred = true
			       			},
			       		new Customer
			       			{
			       				name = "Nathan Hawes",
			       				credit_card = new Credit_card { is_valid = false },
			       				balance = 0,
			       				is_preferred = true
			       			},
			       		new Customer
			       			{
			       				name = "Melinda Plunkett",
			       				credit_card = new Credit_card { is_valid = true },
			       				balance = -100,
			       				is_preferred = false
			       			}
			       	};
		}
	}
}