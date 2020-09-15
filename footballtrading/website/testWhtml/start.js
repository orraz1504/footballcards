const player1 =["Foden", "england", "Manchester City","def","99"]
const player =["Salah", "egypt", "liverpool","att","98"]

window.onload = (event) => {
    document.body.appendChild(createCard(player));
    document.body.appendChild(createCard(player1));
};

function createCard(player){
    //create card
    var card = document.createElement("div");
    card.className ="card";

    //create the top layer
    var top = document.createElement("div");
    top.className="top";
    top.style.backgroundImage= "url('images/card-top.png')"
    card.appendChild(top);

    //adds nation
    var nation = document.createElement("div");
    nation.className="nation";
    nation.style.backgroundImage= "url('flags/"+ player[1] +".png')";
    card.appendChild(nation);
    
    //adds stats and badge
    var pstat = document.createElement("div");
    pstat.className="pstat";
    var stat = document.createElement("p");
    stat.innerHTML =player[4];
    pstat.appendChild(stat);
    var pos = document.createElement("p");
    pos.innerHTML =player[3];
    pstat.appendChild(pos);
    var badge = document.createElement("img");
    badge.src ="images/badges/"+player[2]+".png";
    pstat.appendChild(badge);
    card.appendChild(pstat);
    
    //adds player name
    var pname = document.createElement("div");
    pname.className="pname";
    var name = document.createElement("p");
    name.innerHTML = player[0];
    pname.appendChild(name);
    card.appendChild(pname);

    //ads player img
    var playerimg = document.createElement("div");
    playerimg.className="player";
    playerimg.style.backgroundImage = "url('images/"+ player[0] +".png')";
    card.appendChild(playerimg);
    
    //returns created card
    return card;
}