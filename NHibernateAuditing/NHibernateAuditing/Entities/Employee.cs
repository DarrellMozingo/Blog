namespace NHibernateAuditing.Entities
{
	public class Employee
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Age { get; set; }
	}
}