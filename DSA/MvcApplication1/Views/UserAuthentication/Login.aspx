<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.LoginModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>&nbsp;&nbsp;Login</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
            
            <table cellpadding="8" class="text">
                <tr>
                    <td>Username</td>
                    <td>
                        <%: Html.TextBoxFor(model => model.Username) %>
                        <%: Html.ValidationMessageFor(model => model.Username) %>
                    </td>
                </tr>
                <tr>
                    <td>Token</td>
                    <td>                    
                        <%: Html.TextBoxFor(model => model.Token) %>
                        <%: Html.ValidationMessageFor(model => model.Token) %>
                    </td>
                </tr>

                <tr>
                    <td colspan="2"align="right">
                        <input type="submit" value="Login" />
                    </td>
                </tr>
            </table>
                    

    <% } %>

</asp:Content>

