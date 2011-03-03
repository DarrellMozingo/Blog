using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace StronglyTypedMvcClientSideUrls
{
	public class UrlBuilder
	{
		private static bool onlyTakesInSingleViewModel(string[] routeValues)
		{
			return (routeValues.Length == 3 && routeValues[2].ToLower().EndsWith("viewmodel"));
		}

		public static string UrlTemplateFor<CONTROLLER>(Expression<Action<CONTROLLER>> action) where CONTROLLER : Controller
		{
			var routeValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action);
			var actionPath = string.Format("/{0}/{1}", routeValues["Controller"], routeValues["Action"]);

			if (routeValues.Count > 2)
			{
				var routeValuesKeysArray = routeValues.Keys.ToArray();

				if (onlyTakesInSingleViewModel(routeValuesKeysArray))
				{
					return actionPath;
				}

				if (routeValuesKeysArray[2] == "id")
				{
					actionPath += "/{0}";
				}
				else
				{
					actionPath += "?" + routeValuesKeysArray[2] + "={0}&";
				}

				var placeHolderCounter = 1;

				if (routeValues.Count > 3)
				{
					if (actionPath.Contains("?") == false)
					{
						actionPath += "?";
					}

					for (var i = 3; i < routeValues.Count; i++)
					{
						actionPath += routeValuesKeysArray[i] + "={" + placeHolderCounter++ + "}&";
					}
				}

				actionPath = actionPath.TrimEnd('&');
			}

			return actionPath;
		}
	}
}