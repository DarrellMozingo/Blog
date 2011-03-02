using System.Web.Mvc;
using NUnit.Framework;

namespace StronglyTypedMvcClientSideUrls
{
	[TestFixture]
	public class UrlBuilderFixture
	{
		[Test]
		public void Should_build_a_template_URL_from_the_given_base_URL_and_specified_controller_action()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.BasicAction())
				.ShouldEqual("/Test/BasicAction");
		}

		[Test]
		public void Should_build_a_more_complex_template_URL_from_an_action_with_one_parameter_ignoring_provided_values()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.ActionWithOneParam(5))
				.ShouldEqual("/Test/ActionWithOneParam/{0}");
		}

		[Test]
		public void Should_build_a_more_complex_template_URL_with_the_paramter_name_in_the_URL_from_an_action_with_one_parameter_that_is_not_named_id_ignoring_provided_values()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.ActionWithOneNonIdParam(10))
				.ShouldEqual("/Test/ActionWithOneNonIdParam?notId={0}");
		}

		[Test]
		public void Should_build_a_template_URL_for_an_action_method_with_two_parameters_ignoring_provided_values()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.ActionWithTwoParams(15, "John"))
				.ShouldEqual("/Test/ActionWithTwoParams/{0}?name={1}");
		}

		[Test]
		public void Should_build_a_template_URL_for_an_action_method_with_two_parameters_where_the_first_is_not_named_id_ignoring_provided_values()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.ActionWithTwoParamsFirstNotId(20, "John"))
				.ShouldEqual("/Test/ActionWithTwoParamsFirstNotId?notId={0}&name={1}");
		}

		[Test]
		public void Should_build_a_template_URL_for_an_action_method_with_three_parameters_ignoring_provided_values()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.ActionWithThreeParams(28, "Jane", 36))
				.ShouldEqual("/Test/ActionWithThreeParams/{0}?name={1}&age={2}");
		}

		[Test]
		public void Should_build_a_template_URL_for_an_action_method_that_just_takes_a_view_model()
		{
			UrlBuilder.UrlTemplateFor<TestController>(x => x.ActionWithOnlyViewModel(null))
				.ShouldEqual("/Test/ActionWithOnlyViewModel");
		}

		private class TestController : Controller
		{
			public ActionResult BasicAction()
			{
				return null;
			}

			public ActionResult ActionWithOnlyViewModel(SomeViewModel viewModel)
			{
				return null;
			}

			public ActionResult ActionWithOneParam(int id)
			{
				return null;
			}

			public ActionResult ActionWithOneNonIdParam(int notId)
			{
				return null;
			}

			public ActionResult ActionWithTwoParamsFirstNotId(int notId, string name)
			{
				return null;
			}

			public ActionResult ActionWithTwoParams(int id, string name)
			{
				return null;
			}

			public ActionResult ActionWithThreeParams(int id, string name, int age)
			{
				return null;
			}
		}

		private class SomeViewModel
		{
		}
	}

	public static class TestingExtensions
	{
		public static void ShouldEqual<T>(this T expected, T actual)
		{
			Assert.AreEqual(expected, actual);
		}
	}
}