<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="scripts/register.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form class="form1" action="register.aspx" method="POST" runat="Server" onsubmit="return validate()">
            <label for="username">Username:</label> <br/>
            <input type="text" id="username" name="username" required/> <br/>
            
            <label for="pass">Password:</label> <br/>
            <input type="password" name="pass" id="pass" required> <br/>
            <label for="repass">Re-enter Password:</label> <br/>
            <input type="password" name="repass" id="repass" required><br/>

            <input class="sub" type="submit" value="submit">
    </form>
    <%=error %>
</asp:Content>

