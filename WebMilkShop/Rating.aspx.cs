using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyMilkModels;
using MyMilkBLL;


public partial class Rating : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                int bid = int.Parse(Request.QueryString["Id"].ToString());
                ViewState["MilkId"] = bid;
                DisplayMilkInfo(bid);
            }
        }
    }
    private void DisplayMilkInfo(int bid)
    {

        Milk milk = MilkManager.GetMilkById(bid);
        lblTitle.Text = milk.Name;
        IList<MilkRatings> ratings = MilkRatingManager.GetMilkRatingsInfo(bid);
        if (ratings.Count > 0)
        {
            foreach (MilkRatings r in ratings)
            {
                lblRating.Text += r.User.Name + "<br/>" + r.Rating + "星" + "<br/>" + r.Comment + "<br/>";
            }
        }
    }
    protected void rtBook_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        if (int.Parse(e.Value) < 2)
        {
            lblWarning.Text = "友情提示：您给予的级别太低，有可能影响此牛奶的销售量！";
        }
        else
        {
            lblWarning.Text = "";
        }
    }

    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        MilkRatings rating = new MilkRatings();
        int bid = int.Parse(ViewState["MilkId"].ToString());
        rating.MilkId = bid;
        rating.Rating = rtBook.CurrentRating;
        rating.Comment = txbComment.Text;
        if (Session["AdminUser"] != null)
        {
            Users currentUser = (Users)Session["AdminUser"];
            rating.User = currentUser;

        }
        else
        {
            Response.Redirect("~/LoginUpdateProgress.aspx");
        }
        MilkRatingManager.AddMilkRating(rating);
        lblRating.Text = "";
        txbComment.Text = "";
        DisplayMilkInfo(bid);
    }
}