<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MvcContribFluentHtml.Views.FluentViewPage<CustomerViewModel>" %>
<%@ Import Namespace="MvcContribFluentHtml.Controllers" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Customer Edit
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer Edit</h2>
    
    <% using(Html.BeginForm<CustomerController>(x => x.Update(null))) { %>
		<%= this.Hidden(x => x.Id) %>

		<table>
			<tr>
				<td><b><%= this.Label(x => x.Name) %>:</b></td>
				<td><%= this.TextBox(x => x.Name) %></td>
			</tr>
			<tr>
				<td><b><%= this.Label(x => x.Type).Value("Customer Type") %>:</b></td>
				<td><%= this.Select(x => x.Type).Options<CustomerType>().Selected(Model.Type) %></td>
			</tr>
			<tr>
				<td><b>Address:</b></td>
				<td>
					<table>
						<tr>
							<td>Street:</td>
							<td><%= this.TextBox(x => x.Address.Street) %></td>
						</tr>
						<tr>
							<td>City:</td>
							<td><%= this.TextBox(x => x.Address.City) %></td>
						</tr>
						<tr>
							<td>State:</td>
							<td><%= this.TextBox(x => x.Address.State).Styles(width => "30px") %></td>
						</tr>
						<tr>
							<td>Zip:</td>
							<td><%= this.TextBox(x => x.Address.Zip) %></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td><b>Orders:</b></td>
				<% for(int i = 0; i < Model.Orders.Count; i++) { %>
					<td>
						<%= this.Hidden(x => x.Orders[i].Id) %>
						<table>
							<tr>
								<td>Quantity:</td>
								<td><%= this.TextBox(x => x.Orders[i].Quantity) %></td>
							</tr>
							<tr>
								<td><%= this.Label(x => x.Orders[i].ApplyDiscount).Value("Apply Discount") %>:</td>
								<td><%= this.CheckBox(x => x.Orders[i].ApplyDiscount)%></td>
							</tr>
						</table>
					</td>
				<% } %>
			</tr>
			<tr>
				<td colspan="2" align="center">
					<%= this.SubmitButton("Update Customer") %>
				</td>
			</tr>
		</table>
	<% } %>
	
	<% if(TempData["Id"] != null) { %>
		Some entered values:
		<br /><br />
		Name = <%= TempData["Name"] %>
		<br />
		Type = <%= TempData["Type"] %>
		<br />
		Street = <%= TempData["Street"] %>
		<br />
		Order 1 Quantity = <%= TempData["Order1Quantity"] %>
		<br />
		Order 2 Apply Discount = <%= TempData["Order2ApplyDiscount"] %>
	<% } %>
</asp:Content>