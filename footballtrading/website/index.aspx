<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%=username %>
    <a href="Packs.aspx"> openpacks</a>
    <a href="cardDeck.aspx"> card deck</a>
    <a href="Betting.aspx"> Betting</a>
    <form runat="server">
        <asp:Button ID="logOut" runat="server" Text="Log out" OnClick="logOut_Click"/>
    </form>
</asp:Content>

