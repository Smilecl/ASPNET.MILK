using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyMilkBLL;
using MyMilkModels;

public partial class LoginUpdateProgress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        div1.Style.Add("display", "none");
        System.Threading.Thread.Sleep(2000);
        Users user;
        if (UserManager.AdminLogin(this.TextBox1.Text, this.TextBox2.Text, out user))
        {

            Session["AdminUser"] = user;
            div2.Style.Add("display", "block");
        }
        else
        {
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ListAllMilk.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/register.aspx");
    }
}
