using System.Collections.Generic;

namespace JTemplates.Models
{
	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public static IEnumerable<Person> GetMatches(string zipCode)
		{
			return new List<Person>
				{
					new Person
						{
							Name = "John",
							Age = 25
						},
					new Person
						{
							Name = "Jane",
							Age = 30
						},
					new Person
						{
							Name = "Mike",
							Age = 21
						}
				};
		}
	}
}