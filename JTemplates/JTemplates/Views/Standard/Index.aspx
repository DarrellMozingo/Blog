<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<html>
	<head>
		<title>Standard Person Lookup</title>
		
		<script type="text/javascript" src="/Scripts/jquery-1.3.2.js"></script>
		<script type="text/javascript">
			$(document).ready(function() {
				$("#search").click(function() {
					var url = 'http://localhost:35125/Standard/LookupPeopleByZip/' + $("#zipCode").val();

					$.getJSON(url,
						function(allMatches) {
							var matchCount = 0;

							var tableHtml = '<table>' +
												'<tr>' +
													'<th>Name</th>' +
													'<th>Age</th>' +
												'</tr>';

							for (var i in allMatches) {
								matchCount++;
								
								tableHtml += '<tr>' +
												'<td>' + allMatches[i].Name + '</td>' +
												'<td>' + allMatches[i].Age + '</td>' +
											 '</tr>';
							}

							tableHtml += '</table>';

							var headerHtml = '<h3>Matches: ' + matchCount + '</h3>';

							$("#searchResults").html(headerHtml + tableHtml);
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