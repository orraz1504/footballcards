<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="style/stad.css" />
    <link rel="stylesheet" href="style/cards.css"/>
    <style>
        body{
            background-image:url('../images/stadiums/Elland.jpg');
        }
        .games img{
            height:50px;
            width:50px;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form runat="server">
        <div class="wcent">
            <div class="wrapperr">
                <div class="containor">
                     <div class="row">
                         <div class="col-3">
                             <div class="row">
                                <h2><%=newsHead %></h2>
                                 <p><%=newsCont %></p>
                             </div>
                             <div class="row games">
                                 <h2>Latest Game</h2>
                                 <asp:PlaceHolder ID="mfix" runat="server"></asp:PlaceHolder>
                                 <hr>
                             </div>
                         </div>
                         <div class="col" style="float:right;">
                             <h1>featured card</h1>
                             <%= featured %>
                         </div>
                     </div>
                </div>
            </div>
         </div>
    </form>
      <script src="scripts/pack.js"></script>
</asp:Content>

