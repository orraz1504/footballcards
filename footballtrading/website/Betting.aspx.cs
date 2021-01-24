using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAL;
using DAL.apiClases;

public partial class Betting : System.Web.UI.Page
{
    public string fixtures;
    List<Root> fixs;
    List<Bet> lb;
    Dictionary<int, string> clubs;
    public string currgameId;
    public string error;
    protected void Page_Load(object sender, EventArgs e)
    {
        addFixtures();
        bets.Visible = false;
        gameid.Visible = false;
        //important to remove later!!!!!!!!!!!!!!!!!
        Session["username"] = "orez";
        if (ViewState["State"]!=null && ViewState["State"].ToString() == "2")
        {
            state2();
        }
    }
    public void addFixtures()
    {
        int x = 1;
        fixs = APICall.GetCall();
        List<Root> lr = APICall.sortbyNextGameWeek(fixs, APICall.getCurrentGameweek(0));
        clubs = FPLFunctions.getdicOfClubs();
        foreach (Root fixture in lr)
        {
            //fixtures += GlobalFunctions.CreateGame(fixture,clubs);
            CreateGame(fixture, clubs);
            Debug.WriteLine("added game: " + x.ToString());
            x += 1;
        }
    }
    public void CreateGame(Root game, Dictionary<int, string> clubs)
    {
        //creating vairables
        string homeT = clubs[game.team_h];
        string awayT = clubs[game.team_a];

        DateTime time = game.kickoff_time ?? DateTime.Now.AddYears(-19999999);

        int? homeS = 0;
        if (game.team_h_score != null)
            homeS = game.team_h_score;
        int? awayS = 0;
        if (game.team_a_score != null)
            awayS = game.team_a_score;

        //create fixture
        HtmlGenericControl gameWrap = new HtmlGenericControl("DIV");
        gameWrap.Attributes.Add("class", "row");
        mfix.Controls.Add(gameWrap);

        HtmlGenericControl homeTClass = new HtmlGenericControl("DIV");
        homeTClass.Attributes.Add("class", "col - sm");
        homeTClass.InnerHtml = "<img src='images/badges/" + homeT + ".png'>"; ;
        gameWrap.Controls.Add(homeTClass);


        HtmlGenericControl score = new HtmlGenericControl("DIV");
        score.Attributes.Add("class", "col - sm");
        gameWrap.Controls.Add(score);
        HtmlGenericControl scoreInRow = new HtmlGenericControl("DIV");
        scoreInRow.Attributes.Add("class", "row");
        score.Controls.Add(scoreInRow);
        HtmlGenericControl homeTName = new HtmlGenericControl("DIV");
        homeTName.Attributes.Add("class", "col - sm");
        homeTName.InnerHtml = "<p>" + homeT + "</p>";
        scoreInRow.Controls.Add(homeTName);
        HtmlGenericControl sOrT = new HtmlGenericControl("DIV");
        sOrT.Attributes.Add("class", "col - sm");
        if (game.started == true)
        {
            sOrT.InnerHtml = "<p> (" + homeS + " - " + awayS + ") </p>";
        }
        else
        {
            sOrT.InnerHtml = "<p> " + time.ToString("dddd, dd MMMM h:mm tt") + " </p>";
            Button b = new Button();
            b.Text = "bet";
            b.ID = game.id.ToString();
            b.Click += new EventHandler(bet_Click);
            b.CssClass = "btn btn-primary";
            sOrT.Controls.Add(b);
        }
        scoreInRow.Controls.Add(sOrT);
        HtmlGenericControl awayTName = new HtmlGenericControl("DIV");
        awayTName.Attributes.Add("class", "col - sm");
        awayTName.InnerHtml = "<p>" + awayT + "</p>";
        scoreInRow.Controls.Add(awayTName);

        HtmlGenericControl awayTClass = new HtmlGenericControl("DIV");
        awayTClass.Attributes.Add("class", "col - sm");
        awayTClass.InnerHtml = "<img src='images/badges/" + awayT + ".png'>"; ;
        gameWrap.Controls.Add(awayTClass);
    }
    public void addclub(string club)
    {
        foreach (string playerName in CardFunctions.getByClubNames(club))
        {
            playersdl.Items.Add(playerName);
        }
    }
    protected void bet_Click(object sender, EventArgs e)
    {

        if (BettingFunctions.didBet(Session["username"].ToString(), ((Button)sender).ID))
        {
            error = "already bet on this game";
        }
        else
        {
            bets.Visible = true;
            mfix.Visible = false;
            Root fixture = getgamebyId(((Button)sender).ID);
            hteamname.Text = clubs[fixture.team_h];
            ateamname.Text = clubs[fixture.team_a];
            gameid.Text = ((Button)sender).ID;

            addclub(clubs[fixture.team_h]);
            addclub(clubs[fixture.team_a]);
            Debug.WriteLine(((Button)sender).ID);
        }
    }

    protected void subbtn_Click(object sender, EventArgs e)
    {
        bets.Visible = false;
        mfix.Visible = true;

        string score = hteamscore.Text + " - " + ateamscore.Text;
        string winner = "";
        if (Convert.ToInt32(hteamscore.Text) > Convert.ToInt32(ateamscore.Text))
        {
            winner = hteamname.Text;
        }
        else if (Convert.ToInt32(hteamscore.Text) < Convert.ToInt32(ateamscore.Text))
        {
            winner = ateamname.Text;
        }
        else
        {
            winner = "draw";
        }
        BettingFunctions.AddBet(Session["username"].ToString(), gameid.Text, winner, score, playersdl.SelectedValue.ToString());

        playersdl.Items.Clear();
        hteamscore.Text = 0.ToString();
        ateamscore.Text = 0.ToString();
    }
    public Root getgamebyId(string id)
    {
        foreach (Root fixture in fixs)
        {
            if (fixture.id.ToString() == id)
            {
                return fixture;
            }
        }
        return new Root();
    }
    public void CreateBet(Bet lb, Root game)
    {
        //creating vairables
        string homeT = clubs[game.team_h];
        string awayT = clubs[game.team_a];

        DateTime time = game.kickoff_time ?? DateTime.Now.AddYears(-19999999);

        int? homeS = 0;
        if (game.team_h_score != null)
            homeS = game.team_h_score;
        int? awayS = 0;
        if (game.team_a_score != null)
            awayS = game.team_a_score;


        //create fixture
        HtmlGenericControl gameWrap = new HtmlGenericControl("DIV");
        gameWrap.Attributes.Add("class", "row");
        bfix.Controls.Add(gameWrap);

        HtmlGenericControl homeTClass = new HtmlGenericControl("DIV");
        homeTClass.Attributes.Add("class", "col - sm");
        homeTClass.InnerHtml = "<img src='images/badges/" + homeT + ".png'>";
        gameWrap.Controls.Add(homeTClass);


        HtmlGenericControl score = new HtmlGenericControl("DIV");
        score.Attributes.Add("class", "col - sm");
        gameWrap.Controls.Add(score);
        HtmlGenericControl scoreInRow = new HtmlGenericControl("DIV");
        scoreInRow.Attributes.Add("class", "row");
        score.Controls.Add(scoreInRow);
        HtmlGenericControl homeTName = new HtmlGenericControl("DIV");
        homeTName.Attributes.Add("class", "col - sm");
        homeTName.InnerHtml = "<p>" + homeT + "</p>";
        scoreInRow.Controls.Add(homeTName);
        HtmlGenericControl sOrT = new HtmlGenericControl("DIV");
        sOrT.Attributes.Add("class", "col - sm");
        if (game.finished)
        {
            sOrT.InnerHtml = "<p> Full Time </p>";

            bool isrlscore = false;
            string rlscore = homeS + " - " + awayS;
            if (rlscore == lb.score)
            {
                sOrT.InnerHtml += "<p style='color: green;'>Fulltime score: [" + rlscore + "] </p>";
                isrlscore = true;
            }
            else
                sOrT.InnerHtml += "<p style='color: red;'>Fulltime score: [" + rlscore + "] </p>";


            bool iswteam = false;
            string winningTeam = "";
            if (game.team_h_score > game.team_a_score)
                winningTeam = clubs[game.team_h];
            else if (game.team_a_score > game.team_h_score)
                winningTeam = clubs[game.team_a];
            else
                winningTeam = "draw";
            if (winningTeam == lb.winner)
            {
                sOrT.InnerHtml += "<p style='color: green;'>Winning team: [" + lb.winner + "] </p>";
                iswteam = true;
            }
            else
                sOrT.InnerHtml += "<p style='color: red;'>Winning team: [" + lb.winner + "] </p>";


            bool isscorer = false;
            foreach (Stat stt in game.stats)
            {
                if (stt.identifier == "goals_scored")
                {
                    string c1 = "";
                    string c2 = "";
                    try { c1 = CardFunctions.getByCardId(stt.a[0].element).name;}catch { }
                    try { c2 = CardFunctions.getByCardId(stt.h[0].element).name; } catch { }

                    if (c1 == lb.scorer || c2 ==lb.scorer)
                    {
                        sOrT.InnerHtml += "<p style='color: green;'>First scorer: [" + lb.scorer + "] </p>";
                        isscorer = true;
                    }
                    else
                        sOrT.InnerHtml += "<p style='color: red;'>First scorer: [" + lb.scorer + "] </p>";
                    break;
                }
            }

            Button b = new Button();
            b.Text = "Claim Rewards";
            b.Attributes.Add("myid", game.id.ToString());
            b.Attributes.Add("gold", "0");
            b.Attributes.Add("diamond", "0");
            b.Attributes.Add("silver", "0");
            b.CssClass = "btn btn-primary";
            sOrT.Controls.Add(b);
            b.Click += new EventHandler(Claim_Click);
            if (lb.didClaim)
                b.Enabled = false;
            if (isrlscore)
                b.Attributes["gold"] ="1";
            if (isscorer)
                b.Attributes["diamond"] = "1";
            if(iswteam)
                b.Attributes["silver"] = "1";


        }
        else
        {
            sOrT.InnerHtml = "<p> Your bet </p>";
            sOrT.InnerHtml += "<p>Fulltime score: [" + lb.score + "] </p>";
            sOrT.InnerHtml += "<p>Winning team: [" + lb.winner + "] </p>";
            sOrT.InnerHtml += "<p>First scorer: [" + lb.scorer + "] </p>";

        }
        scoreInRow.Controls.Add(sOrT);
        HtmlGenericControl awayTName = new HtmlGenericControl("DIV");
        awayTName.Attributes.Add("class", "col - sm");
        awayTName.InnerHtml = "<p>" + awayT + "</p>";
        scoreInRow.Controls.Add(awayTName);

        HtmlGenericControl awayTClass = new HtmlGenericControl("DIV");
        awayTClass.Attributes.Add("class", "col - sm");
        awayTClass.InnerHtml = "<img src='images/badges/" + awayT + ".png'>"; ;
        gameWrap.Controls.Add(awayTClass);
    }
    protected void Claim_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("in");
        Button b = (Button)sender;
        if (b.Attributes["gold"] == "1")
            PackFunctions.addPack(Session["username"].ToString() ,"1");
        if (b.Attributes["diamond"] == "1")
            PackFunctions.addPack(Session["username"].ToString(), "2");
        if (b.Attributes["silver"] == "1")
            PackFunctions.addPack(Session["username"].ToString(), "3");
        BettingFunctions.claimed(Session["username"].ToString(), ((Button)sender).Attributes["myid"]);
        ((Button)sender).Enabled = false;
        //Response.Redirect(Request.RawUrl,false);
    }

    public Root GameByGameID(string gameID)
    {
        foreach (Root e in fixs)
        {
            if ((e.id).ToString() == gameID)
            {
                return e;
            }
        }
        return new Root();
    }
    protected void myBets_Click(object sender, EventArgs e)
    {
        ViewState["State"] = "2";
        state2();
    }

    void state2()
    {
        mfix.Visible = false;
        bfix.Visible = true;

        lb = BettingFunctions.getAllBets(Session["username"].ToString());
        foreach (Bet b in lb)
        {
            CreateBet(b, GameByGameID(b.gameId));
        }
    }
}