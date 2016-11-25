<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="MilkList.aspx.cs" Inherits="MilkList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <form id="form1" >
  <div class="STYLE4" >
  <div id="divOrder" >
    <div style="text-align:left;margin:20px 0 20px 0;">排序方式：
    <asp:Button ID="btnDate" runat="server" Text="生产日期" OnClick="btnDate_Click" CssClass="anniu"/>       
       | <asp:Button ID="btnPrice" runat="server" Text="价格" OnClick="btnPrice_Click" CssClass="anniu"/></div>
  </div>
        </div>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
            <table>
                <tr>
                  <td rowspan="2"><a 
                                    onclick="window.location='MilkDetail.aspx?id=<%# DataBinder.Eval(Container.DataItem,"Id")%>'"><img 
                                    id="ctl00_cphContent_dl_Books_ctl01_img_Book" 
                                    style="CURSOR: hand" height="121" alt="<%# DataBinder.Eval(Container.DataItem,"Name") %>" 
                                    src="<%# GetUrl(DataBinder.Eval(Container.DataItem,"Id").ToString()) %>" width="95" /></a> </td>
                  <td style="FONT-SIZE: small; COLOR: red" width="650"><span 
                                    id="span1"><a href="MilkDetail.aspx?id=<%# DataBinder.Eval(Container.DataItem,"Id")%>" name="link_prd_name" target="_blank" class="STYLE5" id="link_prd_name" onclick="return s('9317290','01.54.06.06','',this.href)"><%# DataBinder.Eval(Container.DataItem,"Name") %></a></span> </td>
                </tr>
                <tr>
                  <td style="FONT-SIZE: small" align="left"><span 
                                    id="span2"><%# DataBinder.Eval(Container.DataItem,"brand") %></span><br />
                    <br />
                    <span id="span13"><%# GetCut(DataBinder.Eval(Container.DataItem,"ContentDescription").ToString(),150) %></span> </td>
                </tr>
                <tr>
                  <td style="FONT-SIZE: small;" align="right" colspan="2"><span 
                                    id="span4"><%# DataBinder.Eval(Container.DataItem,"UnitPrice","{0:c}") %></span> </td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
        <hr />
        </SeparatorTemplate>
        </asp:DataList>
        <div class="STYLE4" style="text-align:left;margin:20px 0 20px 0;">
<asp:Label runat="server" ID="lblCurrentPage"></asp:Label>

<asp:Button ID="btnPrev" runat="server" Text="上一页" OnClick="btnPrev_Click" CssClass="anniu"/> 
<asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" CssClass="anniu"/> 

</div>
    </form>
</asp:Content>

