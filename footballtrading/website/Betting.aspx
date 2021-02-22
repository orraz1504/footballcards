<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Betting.aspx.cs" Inherits="Betting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="testWhtml/pred.css">
    <style>
        body{
            text-align:center;
        }
        img{
            height:50px;
            width:50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form Runat="server" >
        
    <div class="games">
        <%=error %>
            <asp:PlaceHolder ID="mfix" runat="server"><asp:Button ID="myBetsbtn" runat="server" Text="My Bets" class="btn btn-primary" OnClick="myBets_Click" /></asp:PlaceHolder>
            <asp:PlaceHolder ID="bfix" runat="server"></asp:PlaceHolder>
    </div>

    <div class="bets">
        <asp:PlaceHolder ID="bets" runat="server">
            <asp:Label ID="gameid" runat="server" Text="Label"></asp:Label>
            <div class="row justify-content-md-center" >
                <div class="col-1">
                     <div class="form-group row">
                        <asp:label runat="server" for="example-number-input" id="hteamname" class="form-label">Number</asp:label>
                         <asp:TextBox ID="hteamscore" runat="server" type="number" value="0" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-1">
                     <div class="form-group row">
                        <asp:label runat="server" for="example-number-input" id="ateamname" class="form-label">Number</asp:label>
                        <asp:TextBox ID="ateamscore" runat="server" type="number" value="0" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row justify-content-md-center">
                <div class="col-1">
                    <asp:DropDownList ID="playersdl" runat="server" class="form-control"></asp:DropDownList>
                </div>
              </div>
            <div class="row justify-content-md-center">
                <asp:Button ID="subbtn" runat="server" Text="Submit" OnClick="subbtn_Click" />
            </div>
        </asp:PlaceHolder>
    </div>
  </form>
</asp:Content>

