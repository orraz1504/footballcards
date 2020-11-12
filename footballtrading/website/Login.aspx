<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <form class="form1" action="Login.aspx" method="POST" runat="Server" onsubmit="return logvalidate()">
         <label for="username">Username:</label> <br/>
            <input type="text" id="username" name="username" required/> <br/>
            
            <label for="pass">Password:</label> <br/>
            <input type="password" name="pass" id="pass" required>
            <br />
            <input class="sub" type="submit" value="submit">
            <% =error%>
     </form>
</asp:Content>

