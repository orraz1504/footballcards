<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cardDeck.aspx.cs" Inherits="cardDeck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link rel="stylesheet" href="testWhtml/dashboard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <label for="sortselec">sort by: </label>
    <form runat="server">
        <div class="form-group">
            <asp:DropDownList runat="server" class="form-control" AutoPostBack="True" id="sortselec" OnSelectedIndexChanged="sortselec_SelectedIndexChanged">
                <asp:ListItem Value="rating">rating</asp:ListItem>
                <asp:ListItem Value="nation">nation</asp:ListItem>
                <asp:ListItem Value="club">club</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group" id="popup">
            <label runat="server" id="frns" for="nationS">what nation?</label>
            <asp:TextBox runat="server" type="text" class="form-control" id="nationS" placeholder="England"></asp:TextBox>
            <asp:Button ID="nationSub" runat="server" Text="Button" OnClick="nationSub_Click" />
        </div>

    </form>
    <%= carddeck %>
</asp:Content>

