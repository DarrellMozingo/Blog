using System.ComponentModel.DataAnnotations;
using MvcContrib.FluentHtml.Behaviors;
using MvcContrib.FluentHtml.Elements;
using MvcContrib.FluentHtml.Html;

namespace MvcContribFluentHtml.Behaviors
{
	public class MaxLengthBehavior : IMemberBehavior
	{
		public void Execute(IMemberElement element)
		{
			var attribute = new MemberBehaviorHelper<StringLengthAttribute>().GetAttribute(element);

			if(attribute != null && element is ISupportsMaxLength)
			{
				element.SetAttr(HtmlAttribute.MaxLength, attribute.MaximumLength);
			}
		}
	}
}