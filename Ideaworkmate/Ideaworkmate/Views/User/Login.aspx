<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<Ideaworkmate.Models.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Login</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>UserModel</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Surname) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Surname) %>
            <%: Html.ValidationMessageFor(model => model.Surname) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.DOB) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.DOB) %>
            <%: Html.ValidationMessageFor(model => model.DOB) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Address) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Address) %>
            <%: Html.ValidationMessageFor(model => model.Address) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Locality) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Locality) %>
            <%: Html.ValidationMessageFor(model => model.Locality) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.JoinDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.JoinDate) %>
            <%: Html.ValidationMessageFor(model => model.JoinDate) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

</asp:Content>
