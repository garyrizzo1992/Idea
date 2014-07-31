<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.AppointmentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RejectAppointment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        RejectAppointment</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <table class="text" cellpadding="8">
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
                <input type="submit" value="Submit email" />
            </td>
        </tr>
    </table>
    <div class="editor-label">
    </div>
    <div class="editor-field">
    </div>
    <p>
    </p>
    <% } %>
</asp:Content>
