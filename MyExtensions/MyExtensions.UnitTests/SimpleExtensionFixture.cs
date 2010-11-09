using MbUnit.Framework;

namespace MyExtensions.UnitTests
{
	[TestFixture]
	class SimpleExtensionFixture
	{
		[Test]
		public void Should_find_an_empty_string_as_empty()
		{
			string emptyString = string.Empty;

			Assert.IsTrue(emptyString.IsNullOrEmpty());
		}
	}
}