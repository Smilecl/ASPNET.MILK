<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div>    
        账户：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        密码：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        数量：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pay" />
    
    </div>
</asp:Content>

