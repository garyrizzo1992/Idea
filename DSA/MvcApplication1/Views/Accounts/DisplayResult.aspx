<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ClientMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ExchangeRateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DisplayResult
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Currency Result: <%: Model.total %></h2>

</asp:Content>
