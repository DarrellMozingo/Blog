namespace MyExtensions
{
	public static class SimpleExtension
	{
		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}
	}
}