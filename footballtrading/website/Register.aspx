<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<head>
    <script src="scripts/register.js"></script>
    <link rel="stylesheet" href="style/login.css">
</head>
<body>
    <form class="form1" action="register.aspx" method="POST" runat="Server" onsubmit="return validate()">
        <div class="inp_username">
            <input type="text" id="username" placeholder="username" name="username" required/>
        </div>
        <div class="inp_pass">
            <input type="password" placeholder="password" name="pass" id="pass" required>
        </div>
        <div class="inp_repass">
            <input type="password" placeholder="re-enter password" name="repass" id="repass" required>
        </div>
        <div class="inp_sub">
            <input class="sub" type="submit" value="submit">
        </div>
        <div class="inp_error">
            <% =error%>
       </div>
       <div class="reg">
        <p>Already have an account?</p><a href="Login.aspx">Login</a>
   </div>

    </form>
</body>

