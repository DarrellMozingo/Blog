namespace ocp_in_action
{
	public class Expired_credit_card_check : ICustomer_check
	{
		public string buildWarningFor(Customer customer)
		{
			return "Credit card expired for customer: " + customer.name;
		}

		public bool failsFor(Customer customer)
		{
			return (customer.credit_card.is_valid == false);
		}
	}
}