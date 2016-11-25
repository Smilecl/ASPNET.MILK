using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// StringHandler 的摘要说明
/// </summary>
public class StringHandler
{
	public StringHandler()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string CoverUrl(object id)
    {
        return "Handler.ashx?id=" + id.ToString();
    }
    public static string CutString(object content, int num)
    {
        if (content.ToString().Length > num - 2)
            return content.ToString().Substring(0, num - 2) + "...";
        else
            return content.ToString();
    }
}