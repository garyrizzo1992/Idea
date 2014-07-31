<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.AppointmentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AcceptAppointment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <table class="text" cellpadding="8">
        <tr>
            <td>
                Appointment has been accepted, Please confirm by clicking submit below
            </td>
        </tr>
        <tr>
            <td align="right">
                <input type="submit" value="Submit email" /></p>
            </td>
            
        </tr>
    </table>
    <p>
        .</p>
    <p>
        <% } %>
</asp:Content>
