<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="UsersDisplay.aspx.cs" Inherits="UsersDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <asp:GridView ID="gvMilkInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4"  Height="218px" Width="535px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="LoginId" HeaderText="用户Id" SortExpression="LoginId" />
            <asp:BoundField DataField="LoginPwd" HeaderText="密码" SortExpression="LoginPwd" />
            <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
            <asp:BoundField DataField="Phone" HeaderText="电话" SortExpression="Phone" />
            <asp:BoundField DataField="Mail" HeaderText="电子邮箱" SortExpression="Mail" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

