<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ErrorModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ErrorPage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ErrorPage</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.message) %>
            </td>
            <td>
                <%: Html.LabelFor(model => model.message) %>
                <%: Html.ValidationMessageFor(model => model.message) %>
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
