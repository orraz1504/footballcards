<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cardDeck.aspx.cs" Inherits="cardDeck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="style/cards.css"/>
        <link rel="stylesheet" href="style/prog.css" />
        <link rel="stylesheet" href="style/stad.css" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style>
        body{
            background-image:url('../images/stadiums/anfield.jpg');
        }
        .wrapperr{
                background: #660303c4;
                box-shadow: 0 0 10px #660303c4, 0 0 40px #660303c4, 0 0 80px #660303c4;
        }
        .nav-item{
            background: #660303;
            box-shadow: 0 0 10px #660303, 0 0 40px #660303ce, 0 0 80px #660303ce;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wcent">
        <div class="wrapperr">
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
            </div>
        </div>
    <script src="scripts/pack.js"></script>
</asp:Content>

