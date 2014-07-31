<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.LogsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    FilterLogs
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        FilterLogs</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.StartDate) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.StartDate) %>
                <%: Html.ValidationMessageFor(model => model.StartDate) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.EndDate) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.EndDate) %>
                <%: Html.ValidationMessageFor(model => model.EndDate) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.AccountID) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.AccountID) %>
                <%: Html.ValidationMessageFor(model => model.AccountID) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.UserID) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.UserID) %>
                <%: Html.ValidationMessageFor(model => model.UserID) %>
            </td>
        </tr>
        <tr>
            <td>
                Sort By Date?
                <%: Html.CheckBoxFor(model => Model.isDateSorted)%>
            </td>
            <td>
                <input type="submit" value="FilterLogs" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <% 
           if (Model.FilteredLogs != null)
           {
               if (Model.FilteredLogs.Count() != 0)
               {%>
    <table>
        <tr>
            <th>
                ID
            </th>
            <th>
                Date
            </th>
            <th>
                Description
            </th>
            <th>
                Account ID
            </th>
            <th>
                UserID
            </th>
        </tr>
        <%
                   foreach (var item in Model.FilteredLogs)
                   {
        %>
        <tr>
            <td>
                <%: item.LogID%>
            </td>
            <td>
                <%: item.Date%>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.AccountID %>
            </td>
            <%: item.UserID %>
        </tr>
        <%}
        %>
    </table>
    <%
               }

           }

       } %>
</asp:Content>
