using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using gf = DAL.GlobalFunctions;

public partial class cardDeck : System.Web.UI.Page
{
    public string carddeck;
    protected void Page_Load(object sender, EventArgs e)
    {
        showDeck();
        frns.Visible = false;
        nationS.Visible = false;
    }
    
    //creates deck of all cards
    public void showDeck()
    {
        string[] ids = cardInv.getAllcardId(Session["username"].ToString());
        foreach (string id in ids)
        {
            carddeck+= gf.createCard(CardFunctions.getByCardId(Convert.ToInt32(id)));
        }
    }
    //on change for select
    protected void sortselec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sortselec.SelectedValue == "nation")
        {
            frns.Visible = true;
            nationS.Visible = true;
        }
        carddeck += "<p> dsds</p>";
    }
}