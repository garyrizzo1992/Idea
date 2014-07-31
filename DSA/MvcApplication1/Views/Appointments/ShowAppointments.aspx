<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.AppointmentModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ShowAppointments
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ShowAppointments</h2>

    <table class="text" cellpadding="8">
        <tr>
            <th></th>
            <th>
                AppointmentID
            </th>
            <th>
                Date
            </th>
            <th>
                time
            </th>
            <th>
                Description
            </th>
            <th>
                userid
            </th>
            <th>
                AppointmentStatusID
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            
            <td>
                <%: item.AppointmentID %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Date) %>
            </td>
            <td>
                <%: item.time %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.userid %>
            </td>
            <td>
                <%: item.AppointmentStatusID %>
            </td>
            <td>
                    <%: Html.ActionLink("Reject", "RejectAppointment", new{ appid = item.AppointmentID,statusid = item.AppointmentStatusID,justification = item.Description} )%>
            </td>
            <td>
            <%: Html.ActionLink("Accept", "AcceptAppointment", new { appid = item.AppointmentID })%>
            </td>
        </tr>

    <% } %>

    </table>


    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

