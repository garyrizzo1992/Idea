<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.displayAccountModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ShowAccounts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table class="text center">
            <tr>
                <th>
                    Account Friendly Name
                </th>
                <th>
                    Balance
                </th>
                <th>
                    Currency
                </th>
                <th>
                    Account Type
                </th>
            </tr>
            <%foreach (var item in Model.accountlist)
              { %>
            <tr>
                <td>
                    <%:item.AccountFriendlyName %>
                </td>
                <td>
                    <%:item.Balance %>
                </td>
                <td>
                    <% if (item.CurrencyID == 1)
                       {
                    %>
                    EUR
                    <%
                   }
                       else if (item.CurrencyID == 2)
                       {
                    %>
                    GBP
                    <%
                   }
                       else
                       { %>
                    USD
                    <% } %>
                </td>
                <td>
                    <%if (item.AccountTypeID == 1)
                      {
                    %>
                    Fixed
                    <%
                  }
                      else
                      {
                    %>
                    Not Fixed
                    <%
                  }%>
                </td>
                <td>
                    <div style="float: right; padding-right: 15px;">
                        <%: Html.ActionLink("View transactions", "showTransections", new { accid = item.AccountID })%></div>
                </td>
                <td>
                    <div style="float: right; padding-right: 15px;">
                        <%: Html.ActionLink("Filter transactions", "FilterTransections", new { accid = item.AccountID })%></div>
                </td>
            </tr>
            <%} %>
        </table>
</asp:Content>
