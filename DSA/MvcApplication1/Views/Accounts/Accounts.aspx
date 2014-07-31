<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.LoginModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Accounts</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.Username) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.Username) %>
                <%: Html.ValidationMessageFor(model => model.Username) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.Token) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.Token) %>
                <%: Html.ValidationMessageFor(model => model.Token) %>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <input type="submit" value="Create" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
