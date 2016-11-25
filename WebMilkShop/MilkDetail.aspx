<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="MilkDetail.aspx.cs" Inherits="MilkDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="odsDetail" Height="250px" Style="margin-right: 354px" Width="600px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnItemUpdated="DetailsView1_ItemUpdated" OnDataBound="DetailsView1_DataBound" OnItemUpdating="DetailsView1_ItemUpdating">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="true">
                <EditItemTemplate>
                    <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="图片展示">
                <ItemTemplate>
                    <asp:Image ID="imgMilk" runat="server" ImageUrl='<%# Eval("Id", "~/images/{0}.jpg") %>' />
                    
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Image ID="imgMilk" runat="server" ImageUrl='<%# Eval("Id", "~/images/{0}.jpg") %>' />
                    <asp:FileUpload ID="fulMilk" runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称" SortExpression="Name">
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="原产地" SortExpression="CountryOfOrigin">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CountryOfOrigin") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CountryOfOrigin") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CountryOfOrigin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="品牌" SortExpression="Brand">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Brand") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单价" SortExpression="UnitPrice">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("UnitPrice","{0:c}") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("UnitPrice","{0:c}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品描述" SortExpression="ContentDescription">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ContentDescription") %>' TextMode="MultiLine" Width="400px" Height="100"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ContentDescription") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ContentDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="生产日期" SortExpression="DateOfManufacture">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("DateOfManufacture", "{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
                  <EditItemTemplate>
                      <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
                    <asp:TextBox ID="txtReleaseDate" runat="server" Text='<%# Bind("DateOfManufacture", "{0:yyyy-MM-dd}") %>' CssClass="Wdate" onFocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true,'default')"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
                    <asp:TextBox ID="txtReleaseDate" runat="server" Text='<%# Bind("DateOfManufacture", "{0:yyyy-MM-dd}") %>' CssClass="Wdate" onFocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true,'default')"></asp:TextBox>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="类别">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsCategory" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                     <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="GetAllCategories" TypeName="MyMilkBLL.CategoryManager"></asp:ObjectDataSource>
                     <asp:HiddenField ID="hfcategory" runat="server" Value='<%# Eval("category.Id") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Category.Name", "{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="odsDetail" runat="server" SelectMethod="GetMilkById" TypeName="MyMilkBLL.MilkManager" UpdateMethod="ModifyMilk">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="CountryOfOrigin" Type="String" />
            <asp:Parameter Name="brand" Type="String" />
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
            <asp:Parameter Name="ContentDescription" Type="String" />
            <asp:Parameter Name="DateOfManufacture" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Button ID="BtnPay" runat="server" Text="购买此书" OnClick="BtnPay_Click" />
</asp:Content>

