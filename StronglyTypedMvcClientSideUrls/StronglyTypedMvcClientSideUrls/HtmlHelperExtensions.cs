using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace StronglyTypedMvcClientSideUrls
{
	public static class HtmlHelperExtensions
	{
		public static string UrlTemplate<CONTROLLER>(this HtmlHelper htmlHelper, Expression<Action<CONTROLLER>> action) where CONTROLLER : Controller
		{
			return UrlBuilder.UrlTemplateFor(action);
		}
	}
}