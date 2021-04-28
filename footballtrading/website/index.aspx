<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="style/stad.css" />
    <link rel="stylesheet" href="style/cards.css"/>
    <style>
        body{
            background-image:url('../images/stadiums/Elland.jpg');
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
                         <div class="col-2">
                             <div class="row">
                                <h2>news</h2>
                                 <p>new cards available!</p>
                             </div>
                             <div class="row">
                                 <h2> Latest game</h2>
                                 <p>team1 vs team2</p>
                                 <p>10-0</p>
                                 <hr>
                             </div>
                             <div class="row">
                                 <h2>your last bet</h2>
                                 <p>no</p>
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

