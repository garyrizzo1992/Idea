<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.FilterTransactionModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
</head>
<body>
    <div>
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
                </td>
                <td>
                </td>
            </tr>
        </table>
        <% }%>
    </div>
</body>
</html>
