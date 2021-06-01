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

public partial class index : System.Web.UI.Page
{
    public string username;
    public string featured;
    public string newsHead;
    public string newsCont;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("~/initPage.aspx");
        }
        username = Session["username"].ToString();

        getFeatured();
        getNews();
        getlatestGame();
    }
    public void getlatestGame()
    {
        List<Root> fixs = APICall.GetCall();
        List<Root> lr = APICall.sortbyNextGameWeek(fixs, APICall.getCurrentGameweek(0));
        Dictionary<int, string> clubs = FPLFunctions.getdicOfClubs();
        lr = lr.OrderByDescending(a => a.id).ToList();
        foreach (Root fixture in lr)
        {
            if (fixture.finished == true)
            {
                CreateGame(fixture, clubs);
                break;
            }
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
        sOrT.InnerHtml = "<p> (" + homeS + " - " + awayS + ") </p>";
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
    public void getNews()
    {
        string[] ret = newsFunctions.GetLatestNews();
        newsHead = ret[0];
        newsCont = ret[1];
    }
    public void getFeatured()
    {
        List<Card> allCards = new List<Card>();

        Debug.WriteLine("starting DB");
        string ids = cardInv.getAllcardId(Session["username"].ToString());
        Debug.WriteLine("done DB");
        Debug.WriteLine("starting DB2");
        allCards = CardFunctions.getALLByCardId("(" + ids + ")");
        allCards = allCards.OrderByDescending(o => Convert.ToInt32(o.rating)).ToList();

        Dictionary<string, Element> els;
        List<string> ls = ids.Split(',').ToList();
        els = APICall.getListOfStats(ls);
        if (els.Count == 0)
        {
            els.Add(ls[0], new Element());
        }

            Dictionary<string, clubColour> clbclr = CardFunctions.getcolours();

        Element d = els[allCards[0].id.ToString()];

        featured = GlobalFunctions.createCard(allCards[0], clbclr[allCards[0].club], els[allCards[0].id.ToString()]);
    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("~/Login.aspx");
    }
}