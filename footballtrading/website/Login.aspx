<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<head>
     <link rel="stylesheet" href="style/login.css">
     <script src="scripts/register.js"></script>
     <script src="https://kit.fontawesome.com/a99aaa219f.js" crossorigin="anonymous"></script>
</head>
<body>
     <div class="inpg">
          <form class="form1" action="Login.aspx" method="POST" runat="Server" onsubmit="return logvalidate()">
               <div class="inp_username">
                    <i class="fas fa-user"></i>
                    <input type="text" id="username" placeholder="Username" name="username" required/> <br/>  
               </div>
               <div class="inp_pass">
                    <i class="fas fa-key"></i>
                    <input type="password" placeholder="password" name="pass" id="pass" required>
               </div>
               <div class="inp_sub" style="top: 60%;">
                    <input class="sub" type="submit" value="submit">
               </div>
               <div class="inp_error" style="top: 80%;">
                    <% =error%>
               </div>
               <div class="reg" style="top: 70%;">
                    <p>Dont have an account yet?</p><a href="Register.aspx">Register</a>
               </div>
           </form>
     </div>     
</body>


