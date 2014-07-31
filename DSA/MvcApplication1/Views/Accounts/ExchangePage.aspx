<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ExchangeRateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ExchangePage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ExchangePage</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                Ammount
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.ammount) %>
                <%: Html.ValidationMessageFor(model => model.ammount) %>
            </td>
        </tr>
        <tr>
            <td>
                Source Currency
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.SourceCurrency,Model.SelectedSourceCurrency) %>
                <%: Html.ValidationMessageFor(model => model.SourceCurrency) %>
            </td>
        </tr>
        <tr>
            <td>
                Destination Currency
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.DestinationCurrency,Model.SelectedDestinationCurrency) %>
                <%: Html.ValidationMessageFor(model => model.DestinationCurrency) %>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input type="submit" value="Display Currency" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
