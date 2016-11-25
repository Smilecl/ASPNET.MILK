using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyMilkModels;
using MyMilkBLL;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SerialNumber1.Create();
        }
    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        if (!SerialNumber1.CheckSN(TextBox8.Text.Trim()))
        {
            Response.Write("<script>alert('验证码错误');</script>");
            SerialNumber1.Create();
            return;
        }
        if (Page.IsValid)
        {

            if (UserManager.LoginIdExists(TextBox1.Text.Trim()))
            {
                UserManager.AddUser(TextBox1.Text.Trim(), TextBox2.Text.Trim(), TextBox5.Text.Trim(), TextBox6.Text.Trim(), TextBox7.Text.Trim(), TextBox4.Text.Trim());
                Response.Redirect("~/LoginUpdateProgress.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败，用户已存在！');</script>");
            }
        }
    }
}