<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.AccountRenewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Expired Accounts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Expired Accounts</h2>

    <table class="text" cellpadding="8">
        <tr>
        <th></th>
            <th>
                AccountID
            </th>
            <th>
                Account Name
            </th>
            <th>
                Balance
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Transfer", "TransferInterest", new { id=item.AccountID  }) %> |
                <%: Html.ActionLink("Renew", "RenewAccount", new {   id=item.AccountID })%> |   
             </td>
            <td>
                <%: item.AccountID %>
            </td>
            <td>
                <%: item.AccountFriendlyName %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Balance) %>
            </td>
          
        </tr>
    
    <% } %>

    </table>

</asp:Content>

