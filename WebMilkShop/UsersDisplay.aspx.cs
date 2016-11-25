using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UsersDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DisplayMilkInfo();
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DisplayMilkInfo();
    }
    protected void DisplayMilkInfo()
    {
        SqlConnection conn = new SqlConnection("Data Source=SMILE_C;Initial Catalog=MyMilk;Integrated Security=True");
        conn.Open();
        string sql = "select LoginId,LoginPwd,Name,Address,Phone,Mail from Users order by Id asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        gvMilkInfo.DataSource = ds;
        gvMilkInfo.DataBind();
    }
}