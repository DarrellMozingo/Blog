namespace StronglyTypedMvcClientSideUrls
{
	public class Any<T>
	{
		public static T Arg
		{
			get { return default(T); }
		}
	}
}