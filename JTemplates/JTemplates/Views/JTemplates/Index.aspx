<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<html>
	<head>
		<title>JTemplates Person Lookup</title>
		
		<script type="text/javascript" src="/Scripts/jquery-1.3.2.js"></script>
		<script type="text/javascript" src="/Scripts/jtemplates.js"></script>
		<script type="text/javascript">
			$(document).ready(function() {
				$("#search").click(function() {
					var url = 'http://localhost:35125/JTemplates/LookupPeopleByZip/' + $("#zipCode").val();

					$.getJSON(url,
						function(allMatches) {
							$('#searchResults').setTemplateURL('/Content/ResultTemplate.html');
							$('#searchResults').processTemplate(allMatches);
						});
				});
			});
		</script>
	</head>

	<body>
		Lookup people by zip code: <input type="text" id="zipCode" /> <input type="button" id="search" value="Search" />

		<div id="searchResults" style="padding-top: 15px"></div>
	</body>
</html>