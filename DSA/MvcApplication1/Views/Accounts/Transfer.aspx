<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.TransferModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Transfer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Transfer</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.ammount) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.ammount) %>
                <%: Html.ValidationMessageFor(model => model.ammount) %>
            </td>
        </tr>
        <tr>
            <td>
                From Account
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedListFromAccount,Model.FromAccount) %>
                <%: Html.ValidationMessageFor(model => model.selectedListFromAccount) %>
            </td>
        </tr>
        <tr>
            <td>
                To Account
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedListToAccount,Model.ToAccount) %>
                <%: Html.ValidationMessageFor(model => model.selectedListToAccount) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.token) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.token) %>
                <%: Html.ValidationMessageFor(model => model.token) %>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input type="submit" value="Transfer" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
