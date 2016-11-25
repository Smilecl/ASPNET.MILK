using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyMilkBLL;
using MyMilkModels;
using AjaxControlToolkit;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MIlkSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayHotBooks();
    }
    private void DisplayHotBooks()
    {
        IList<MyMilkModels.Categories> list = CategoryManager.GetAllCategories();
        foreach (MyMilkModels.Categories item in list)
        {
            AccordionPane ap = new AccordionPane();
            Label lbCategoryMenu = new Label();
            lbCategoryMenu.Text = item.Name;
            ap.HeaderContainer.Controls.Add(lbCategoryMenu);
            IList<MyMilkModels.Milk> milklist = MilkManager.GetMilkByCategoryId(item.Id);
            foreach (MyMilkModels.Milk bitem in milklist)
            {
                HyperLink hl = new HyperLink();
                hl.Text = bitem.Name + "</br>";
                hl.NavigateUrl = "~/MilkDetail.aspx?id=" + bitem.Id;
                ap.ContentContainer.Controls.Add(hl);
            }
            Accordion1.Panes.Add(ap);

        }
    }
    protected void imgbtnDirection_Click(object sender, ImageClickEventArgs e)
    {
        DisplayHotBooks();
    }
}
  