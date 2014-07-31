<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.AppointmentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RequestAppointment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        RequestAppointment</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                <%: Html.LabelFor(model => model.Date) %>
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.Date,Model.SelectedDate) %>
                <%: Html.ValidationMessageFor(model => model.Date) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.Date) %>
            </td>
            <td>
                <%: Html.DropDownListFor(model => model.time,Model.SelectedTime) %>
                <%: Html.ValidationMessageFor(model => model.time) %>
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.LabelFor(model => model.Description) %>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input type="submit" value="Add Appointment" />
            </td>
        </tr>
    </table>
    <% } %>
</asp:Content>
