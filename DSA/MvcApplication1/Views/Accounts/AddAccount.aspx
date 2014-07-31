<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.AccountsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddAccount
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#hide").hide();
            $("#AccType").change(function () {
                var val = $("#AccType option:selected").text();
                if (val == "Fixed") {
                    $("#hide").show();
                }
                else {
                    $("#hide").hide();
                }
            });

        });
    </script>
    <h2>
        Account Creation</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                Account Name
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.AccountName) %>
                <%: Html.ValidationMessageFor(model => model.AccountName) %>
            </td>
        </tr>
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
                Source Account
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedListAccount,Model.FromAccount) %>
                <%: Html.ValidationMessageFor(model => model.selectedListAccount) %>
            </td>
        </tr>
        <tr>
            <td>
                Currency
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedListCurrency,Model.Currency) %>
                <%: Html.ValidationMessageFor(model => model.selectedListCurrency) %>
            </td>
        </tr>
        <tr>
            <td>
                Account Type
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedListType, Model.AccountType, new { @id = "AccType" })%>
                <%: Html.ValidationMessageFor(model => model.selectedListType) %>
            </td>
        </tr>
        <tr>
            <td>
                Duration
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.selectedListDuration,Model.Duration) %>
                <%: Html.ValidationMessageFor(model => model.selectedListDuration) %>
            </td>
        </tr>
        <tr>
            <td>
                Token:
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.token) %>
                <%: Html.ValidationMessageFor(model => model.token) %>
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
