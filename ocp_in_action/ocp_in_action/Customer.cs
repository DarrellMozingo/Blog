namespace ocp_in_action
{
	public class Customer
	{
		public Credit_card credit_card { get; set; }
		public decimal balance { get; set; }
		public bool is_preferred { get; set; }
		public string name { get; set; }
	}
}