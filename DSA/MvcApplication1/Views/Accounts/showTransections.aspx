<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.TransactionModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    showTransections
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Transactions</h2>
    <table class="text">
        <tr>
            <th>
            </th>
            <th>
                TransactionID
            </th>
            <th>
                Ammount
            </th>
            <th>
                Currency
            </th>
            <th>
                FromAccountID
            </th>
            <th>
                ToAccountID
            </th>
            <th>
                Date
            </th>
            <th>
                TransactionType
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
            </td>
            <td>
                <%: item.TransactionID %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ammount) %>
            </td>
            <td>
                <%: item.Currency %>
            </td>
            <td>
                <%: item.FromAccountID %>
            </td>
            <td>
                <%: item.ToAccountID %>
            </td>
            <td>
                <%: item.Date %>
            </td>
            <td>
                <%: item.TransactionType %>
            </td>
            <td>
               
            </td>
        </tr>
        <% } %>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
