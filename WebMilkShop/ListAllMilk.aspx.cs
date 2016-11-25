using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListAllMilk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = e.Row.FindControl("linb_Delete") as LinkButton;
            lb.Attributes.Add("onclick", "return confirm('确认删除吗？')");

            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hfId = GridView1.Rows[e.RowIndex].FindControl("hfId") as HiddenField;
        obsMilk.DeleteParameters.Add("Id", hfId.Value);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Response.Redirect("MilkDetail.aspx?Id=" + e.CommandArgument.ToString());
        }
    }
}