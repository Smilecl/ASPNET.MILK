using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MilkDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        FileUpload fulMilk = this.DetailsView1.FindControl("fulMilk") as FileUpload;
        Image imgMilk = this.DetailsView1.FindControl("imgMilk") as Image;
        string FileName = fulMilk.FileName;
        if (FileName.Trim().Length != 0)
        {
            string strpath = Server.MapPath(imgMilk.ImageUrl);
            fulMilk.PostedFile.SaveAs(strpath);//把图片保存在此路径中
           string c=Request.Params["id"];
            Response.Redirect("~/MilkDetail.aspx?id="+c);
        }
    }
    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
        {
            DropDownList DropDownList1 = this.DetailsView1.FindControl("DropDownList1") as DropDownList;
            HiddenField hfcategory = this.DetailsView1.FindControl("hfcategory") as HiddenField;
            DropDownList1.SelectedValue = hfcategory.Value;
        }
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        DropDownList DropDownList1 = this.DetailsView1.FindControl("DropDownList1") as DropDownList;
        this.odsDetail.UpdateParameters.Add("CategoryId", DropDownList1.SelectedValue);
    }
    protected void BtnPay_Click(object sender, EventArgs e)
    {
        string c=Request.Params["id"];
        Response.Redirect("~/Pay.aspx?id="+c);
    }
}