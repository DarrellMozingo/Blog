namespace ocp_in_action
{
	public class Negative_balance_check : ICustomer_check
	{
		public string buildWarningFor(Customer customer)
		{
			return "Negative balance for non preferred customer: " + customer.name;
		}

		public bool failsFor(Customer customer)
		{
			return (!customer.is_preferred && customer.balance < 0);
		}
	}
}