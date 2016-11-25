<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<%@ Register Assembly="WebValidates" Namespace="WebValidates" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" >
    <div>
    <h3>注册</h3>
        <p>用户Id:&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>姓名:&nbsp;&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入姓名" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        
        <p>密码:&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>重复密码:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="密码不能为空" ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码不一致" ControlToValidate="TextBox3" ControlToCompare="TextBox2" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>          
        </p>
        <p>地址:&nbsp;&nbsp;<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="请输入地址" ControlToValidate="TextBox6" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>电话:&nbsp;&nbsp;<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="请输入电话" ControlToValidate="TextBox7" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox7"
                            ErrorMessage="电话号码输入不正确" ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        </p>
        <p>电子邮箱:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入电子邮箱" ControlToValidate="TextBox4" ForeColor="Red" Display="Dynamic" ViewStateMode="Enabled"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="电子邮箱格式不正确" ControlToValidate="TextBox4" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
           
           
        </p>
        <p>
            <cc1:SerialNumber ID="SerialNumber1" runat="server"></cc1:SerialNumber>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
           
           
        </p>
        <p>
            <asp:Button ID="BtnRegister" runat="server" Text="确认" OnClick="BtnRegister_Click" />
        </p>
        <p>&nbsp;</p>

    </div>
    </form>
</body>
</html>

</asp:Content>

