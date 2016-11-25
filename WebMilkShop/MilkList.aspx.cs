using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyMilkBLL;

public partial class MilkList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
             
        if (!IsPostBack)
        {
            ViewState["Page"] = 0;
            ViewState["Order"] = "";
            try
            {
                ViewState["CategoryId"] = Convert.ToInt32(Request.QueryString["CategoryId"]);
            }
            catch
            {
                ViewState["CategoryId"] = -1;
            }
            Databind();
        }  
    }
    public string GetUrl(string id)
    {
        return StringHandler.CoverUrl(id);
    }
    public string GetCut(string content, int num)
    {
        return StringHandler.CutString(content, num);
    }

    private void Databind()
    {
        PagedDataSource objPds = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值        
        objPds.DataSource = MilkManager.GetOrderedSmallBookByCategoryId(Convert.ToInt32(ViewState["CategoryId"]), (string)ViewState["Order"]);
        objPds.AllowPaging = true;
        objPds.PageSize = 4;

        objPds.CurrentPageIndex = Pager;
        lblCurrentPage.Text = "第 " + (objPds.CurrentPageIndex + 1).ToString() + " 页 共 " + objPds.PageCount.ToString() + " 页";
        SetEnable(objPds);

        //把PagedDataSource 对象赋给DataList控件 
        DataList1.DataSource = objPds;
        DataList1.DataBind();
    }

    #region  排序
    protected void btnDate_Click(object sender, EventArgs e)
    {
        ViewState["Order"] = "CountryOfOrigin";
        Pager = 0;
        btnDate.Enabled = false;
        btnPrice.Enabled = true;
        Databind();
    }
    protected void btnPrice_Click(object sender, EventArgs e)
    {
        ViewState["Order"] = "UnitPrice";
        Pager = 0;
        btnPrice.Enabled = false;
        btnDate.Enabled = true;
        Databind();
    }
    #endregion
    #region  翻页
    private void SetEnable(PagedDataSource objPds)
    {
        btnPrev.Enabled = true;
        btnNext.Enabled = true;
        if (objPds.IsFirstPage)
            btnPrev.Enabled = false;

        if (objPds.IsLastPage)
            btnNext.Enabled = false;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Pager++;
        Databind();
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Pager--;
        Databind();
    }
    private int Pager
    {
        get
        {
            return (int)ViewState["Page"];
        }
        set
        {
            ViewState["Page"] = value;
        }
    }
    #endregion
}
