<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.AccountRenewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RenewAccount
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        RenewAccount</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.selectedDuration) %>
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedDuration,Model.Duration) %>
                <%: Html.ValidationMessageFor(model => model.selectedDuration) %>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input type="submit" value="Submit" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
