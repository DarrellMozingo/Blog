namespace ocp_in_action
{
	public interface ICustomer_check
	{
		string buildWarningFor(Customer customer);
		bool failsFor(Customer customer);
	}
}