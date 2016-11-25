using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MyBankWebService.MyBankWS service = new MyBankWebService.MyBankWS();
        MyBankWebService.PayResults result = service.Pay(TextBox1.Text.Trim(), TextBox2.Text.Trim(), Convert.ToInt16(TextBox3.Text.Trim()));
        switch (result)
        {
            case MyBankWebService.PayResults.Success:
                Response.Write("<script>alert('支付成功！');</script>");
                  string c=Request.Params["id"];
                Response.Redirect("~/Rating.aspx?Id="+c);
                break;
            case MyBankWebService.PayResults.InvalidAccount:
                Response.Write("<script>alert('账户不合法');</script>");
                break;
            case MyBankWebService.PayResults.NotEnoughMoney:
                Response.Write("<script>alert('余额不足！');</script>");
                break;
            case MyBankWebService.PayResults.UnknownError:
                Response.Write("<script>alert('未知错误！');</script>");
                break;
        }
    }
}