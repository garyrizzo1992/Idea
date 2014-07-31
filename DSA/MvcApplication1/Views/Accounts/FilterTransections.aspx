<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.FilterTransactionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    FilterTransections
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        $(function () {
            $('.myPrint').click(function () {
                var text = $('#StartDate').val();
                this.href = this.href.replace("zzz", text);

                var text2 = $('#EndDate').val();
                this.href = this.href.replace("zz", text2);
            });


        });

        

    </script>
    <h2>
        FilterTransections</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <%: Html.HiddenFor(model => model.accid) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.StartDate) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.StartDate)%>
                <%: Html.ValidationMessageFor(model => model.StartDate)%>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.EndDate) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.EndDate)%>
            </td>
        </tr>
        <tr>
            <td>
                <input type="submit" value="FilterTransections" />
            </td>
            <td>
                <%: Html.ActionLink("Report", "ShowAccountsWithReport", new { accid = Model.accid, start = "zzz", end = "zz"}, new { @Class = "myPrint" })%>
            </td>
        </tr>
    </table>
    <% }%>
</asp:Content>
