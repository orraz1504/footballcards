<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Packs.aspx.cs" Inherits="cardDeck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="style/cards.css">
    <link rel="stylesheet" href="style/stad.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="scripts/packanimate.js"></script>
    <style>
        body{
            background-image:url('../images/stadiums/Tottenhamhotspurstadium.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wcent">
        <div class="wrapperr">
                <form Runat="server">
                    <asp:Button ID="testbtn" runat="server" Text="Button" OnClick="testbtn_Click" />
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="PackPlaceHolder"></asp:PlaceHolder>
                        <div class="deck" style="position: relative;">
                           <%=carddeck %>
                        </div>
                    </div>
                    <asp:Button ID="saveB" runat="server" Text="Save Pack" OnClick="saveB_Click" />
                </form>
            </div>
        </div>
    <script src="scripts/pack.js"></script>
</asp:Content>