<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="StronglyTypedMvcClientSideUrls.Controllers" %>
<%@ Import Namespace="StronglyTypedMvcClientSideUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

	<script type="text/javascript" language="javascript">
		String.prototype.replaceAll = function (patternToFind, replacementString) {
			return this.replace(new RegExp(patternToFind, "gi"), replacementString);
		}

		String.prototype.substitute = function () {
			var formatted = this;

			for(var i = 0; i < arguments.length; i++) {
				formatted = formatted.replaceAll("\\{" + i + "\\}", arguments[i]);
			}

			return formatted;
		}

		$(document).ready(function () {
			// get these values from form fields or something...
			var id = 3;
			var accountNumber = "123456";
			var amount = 325;

			//var ugly_url = "/Home/DoSomethingComplex/" + id + "?accountNumber=" + accountNumber + "&amount=" + amount;
			var beautiful_url = "<%= Html.UrlTemplate<HomeController>(x => x.DoSomethingComplex(Any<int>.Arg, Any<string>.Arg, Any<int>.Arg)) %>"
									.substitute(id, accountNumber, amount);

			$.get(beautiful_url, function (data) { $("#data-dump").html(data); });
		});
	</script>

    <p>Data from the server:</p>

	<div id="data-dump" style="border-style:solid; padding: 10px;"></div>
</asp:Content>