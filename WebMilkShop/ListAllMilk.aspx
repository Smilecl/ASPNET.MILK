<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ListAllMilk.aspx.cs" Inherits="ListAllMilk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <script language="javascript">
        function GetAllCheckBox(parentItem) {
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                if (parentItem.checked) {
                    if (items[i].type == "checkbox") {
                        items[i].checked = true;
                    }
                }
                else {
                    if (items[i].type == "checkbox") {
                        items[i].checked = false;
                    }
                }
            }
        }

</script>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="obsMilk" Height="16px" Width="1143px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" style="margin-top: 0px" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="全选">
                <HeaderTemplate>
                   <input id="cbAll" type="checkbox" onclick="GetAllCheckBox(this)" />全选
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chb_Select" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    <asp:HiddenField  ID="hfId" runat="server" Value='<%# Eval("Id") %>' ></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CountryOfOrigin" HeaderText="原产地" SortExpression="CountryOfOrigin" />
            <asp:BoundField DataField="Brand" HeaderText="品牌" SortExpression="Brand" />
            <asp:BoundField DataField="UnitPrice" HeaderText="单价" SortExpression="UnitPrice" DataFormatString="{0:c}" />
            <asp:BoundField DataField="ContentDescription" HeaderText="产品描述" SortExpression="ContentDescription" />
            <asp:BoundField DataField="DateOfManufacture" HeaderText="生产日期" SortExpression="DateOfManufacture" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField>
                <ItemTemplate>
                     <asp:LinkButton ID="linb_Delete" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                  <asp:LinkButton ID="linb_View" runat="server" CommandName="View" Text="详细" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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

    <asp:ObjectDataSource ID="obsMilk" runat="server" SelectMethod="GetAllMilk" TypeName="MyMilkBLL.MilkManager" DeleteMethod="DeleteMilkById">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>

</asp:Content>

