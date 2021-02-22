<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cardDeck.aspx.cs" Inherits="cardDeck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="style/cards.css"/>
        <link rel="stylesheet" href="style/prog.css" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <div class="containor">
            <div class="row">
                <asp:PlaceHolder ID="bfix" runat="server"></asp:PlaceHolder>
            </div>
        </div>
     <asp:PlaceHolder ID="afix" runat="server">
         <asp:Button CssClass="btn btn-primary" ID="back" runat="server" Text="back" OnClick="back_Click" />
        <div class="deck">
            <%= carddeck %>
        </div>
     </asp:PlaceHolder>
    </form>
    <script src="scripts/pack.js"></script>
</asp:Content>

