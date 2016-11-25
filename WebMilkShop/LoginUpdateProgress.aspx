<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="LoginUpdateProgress.aspx.cs" Inherits="LoginUpdateProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>登录</title>
     <link href="css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" >
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div style="width:249px; height:185px; text-align:center">
        <div id="div1" runat="server"><br/>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>正在加载数据,请稍候...</ProgressTemplate>
        </asp:UpdateProgress>  
            <h3>登录</h3>
            账号:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            密码:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
            &nbsp;
            <asp:Button ID="Button2" runat="server" Text="注册" OnClick="Button2_Click" />
        </div>
    <div id="div2" runat="server"  style="display:none" >
        <asp:Button ID="Button3" runat="server" Text="登录成功！点击访问主页" OnClick="Button3_Click" />
    </div> 
</div>
      </ContentTemplate>
      </asp:UpdatePanel>

    </form>
</body>
</html>

</asp:Content>

