using System.Collections.Generic;

namespace ocp_in_action.ocp_violation
{
	// OCP violation in action here.
	public class Check_runner
	{
		private static readonly IList<string> _warnings = new List<string>();

		public IEnumerable<string> run_checks_on(IEnumerable<Customer> customers)
		{
			foreach (var customer in customers)
			{
				check_that_only_preferred_customer_can_have_a_negative_balance(customer);
				check_that_on_file_credit_card_is_not_expired(customer);
				// additional checks in the future...
			}

			return _warnings;
		}

		private static void check_that_on_file_credit_card_is_not_expired(Customer customer)
		{
			if (customer.credit_card.is_valid)
			{
				return;
			}

			_warnings.Add("Credit card expired for customer: " + customer.name);
		}

		private static void check_that_only_preferred_customer_can_have_a_negative_balance(Customer customer)
		{
			if (customer.is_preferred || customer.balance >= 0)
			{
				return;
			}

			_warnings.Add("Negative balance for non preferred customer: " + customer.name);
		}
	}
}