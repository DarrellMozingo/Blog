using MvcContrib.FluentHtml;
using MvcContribFluentHtml.Behaviors;

namespace MvcContribFluentHtml.Views
{
	public class FluentViewPage<T> : ModelViewPage<T> where T : class
	{
		public FluentViewPage()
			: base(new MaxLengthBehavior())
		{
		}
	}
}