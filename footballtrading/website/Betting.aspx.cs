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
    protected void Page_Load(object sender, EventArgs e)
    {
        addFixtures();
    }
    public void addFixtures()
    {
        int x = 1;
        List<Root> fixs = APICall.GetCall();
        fixs = APICall.sortbyNextGameWeek(fixs, APICall.getCurrentGameweek());
        Dictionary<int, string> clubs = FPLFunctions.getdicOfClubs();
        foreach (Root fixture in fixs)
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
        homeTClass.InnerHtml= "<img src='testWhtml/images/badges/" + homeT + ".png'>"; ;
        gameWrap.Controls.Add(homeTClass);


        HtmlGenericControl score = new HtmlGenericControl("DIV");
        score.Attributes.Add("class", "col - sm");
        gameWrap.Controls.Add(score);
        HtmlGenericControl scoreInRow = new HtmlGenericControl("DIV");
        scoreInRow.Attributes.Add("class", "row");
        score.Controls.Add(scoreInRow);
        HtmlGenericControl homeTName = new HtmlGenericControl("DIV");
        homeTName.Attributes.Add("class", "col - sm");
        homeTName.InnerHtml= "<p>" + homeT + "</p>";
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
            b.ID= game.id.ToString();
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
        awayTClass.InnerHtml = "<img src='testWhtml/images/badges/" + awayT + ".png'>"; ;
        gameWrap.Controls.Add(awayTClass);
    }
    protected void bet_Click(object sender, EventArgs e)
    {
        Debug.WriteLine(((Button)sender).ID);
    }
}