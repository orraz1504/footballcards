<%@ Page Language="C#" AutoEventWireup="true" CodeFile="initPage.aspx.cs" Inherits="initPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" href="style/intpage.css"/>
   <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
   <script src="https://kit.fontawesome.com/a99aaa219f.js" crossorigin="anonymous"></script>
   
</head>
<body>
    <div class="all">
    <section style="overflow: hidden;margin:0; background-image:url(images/initpage/cover.jpg); background-attachment: fixed; background-repeat:no-repeat; background-size:cover;" >
        <h1 class="ftitle">The Unoffical Premier league betting game</h1>
        <!--<img id="logo" src="images/initpage/logo.png" /> -->
        <div class="cover" style="background-color:#3d195b;">
        </div>
        <div class="stcont">
            <a id="arrd" href="#arrd2"><i class="fas fa-arrow-down"></i></a>
        </div>
    </section>
    <section class="sticky">
        <blockquote class="slq">Bet on real Premier League games <span class="spn"></span> </blockquote>
        <div class="imgcont" style="overflow:hidden;">
            <img id="img1" src="images/initpage/bet.png" alt=""/>
            <img id="img2" src="images/initpage/bet.jpg" alt=""/>    
        </div>
        <div class="stcont">
            <a id="arrd2" href="#arrd3"><i class="fas fa-arrow-down"></i></a>
        </div>
    </section>
    <section class="sticky3">
        <blockquote class="slq3">Open packs to get Virtual Cards<span class="spn3"></span> </blockquote>
        <div class="imgcont3">
            <img id="img10" src="images/initpage/pack.png" alt=""/>    
        </div>
        <div class="stcont">
            <a id="arrd3" href="#arrd4"><i class="fas fa-arrow-down"></i></a>
        </div>
    </section>
    <section class="sticky2">
        <blockquote class="slq2">Collect Virtual Cards<span class="spn2"></span> </blockquote>
        <div class="imgcont2">
            <div class="row">
                <img id="img3" src="images/initpage/card1.png" alt=""/>
                <img id="img4" src="images/initpage/card2.png" alt=""/>
                <img id="img5" src="images/initpage/card3.png" alt=""/>
                <img id="img6" src="images/initpage/card4.png" alt=""/>
                <img id="img7" src="images/initpage/card5.png" alt=""/>
                <img id="img8" src="images/initpage/card6.png" alt=""/>  
            </div> 
        </div>
        <div class="stcont" style="top: 92%;">
            <a id="arrd4" href="#last"><i class="fas fa-arrow-down"></i></a>
        </div>
    </section>
    <section style="background-color:#3d195b;">
        <div id="last" class="bcontainer">
            <form runat="server">
                <a href="Register.aspx">Start Now</a>
            </form>
        </div>
    </section>
    </div>

    <footer class="footer">
        <div class="container">
            <p class="text-center">Copyright @2021 | Designed by <a href="https://www.youtube.com/watch?v=dQw4w9WgXcQ">Orez</a></p>
        </div>

</footer>


<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>




    <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.5.1/gsap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/ScrollMagic/2.0.8/ScrollMagic.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/ScrollMagic/2.0.3/ScrollMagic.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/ScrollMagic/2.0.7/plugins/animation.gsap.min.js"></script>
    <script src="scripts/intpage.js"></script>
</body>
</html>
