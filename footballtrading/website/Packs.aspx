<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Packs.aspx.cs" Inherits="cardDeck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="style/other.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form Runat="server">
        <asp:PlaceHolder runat="server" ID="PackPlaceHolder"></asp:PlaceHolder>
        <div class="deck">
           <%=carddeck %>
        </div>
        <asp:Button ID="saveB" runat="server" Text="Save Pack" OnClick="saveB_Click" />
    </form>
</asp:Content>