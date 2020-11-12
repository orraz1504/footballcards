<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cardDeck.aspx.cs" Inherits="cardDeck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="testWhtml/dashboard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="deck">
       <%=carddeck %>
    </div>
    <form Runat="Server">
            <asp:Button ID="openPack" Text="basicPack" Runat="Server" OnClick="openPack_Click" />
    </form>
</asp:Content>

