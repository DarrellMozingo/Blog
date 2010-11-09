using System.Collections.Generic;

namespace ocp_in_action
{
	public class Check_runner
	{
		private readonly IEnumerable<ICustomer_check> _customer_checks;

		public Check_runner(IEnumerable<ICustomer_check> customerChecks)
		{
			_customer_checks = customerChecks;
		}

		public IEnumerable<string> run_checks_on(IEnumerable<Customer> customers)
		{
			var warnings = new List<string>();

			foreach (var customer in customers)
			{
				foreach (var check in _customer_checks)
				{
					if (check.failsFor(customer))
					{
						warnings.Add(check.buildWarningFor(customer));
					}
				}
			}

			return warnings;
		}
	}
}