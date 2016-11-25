<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
     <asp:TextBox ID="TextBox1" runat="server" Width="323px"></asp:TextBox>
                <cc1:AutoCompleteExtender
                     TargetControlID="TextBox1"
                    ServicePath="~/MyWebService/SearchMilk.asmx"
                    ServiceMethod="GetMilkHotSearchKeywords"
                    MinimumPrefixLength="1"
                    EnableCaching="true"
                    CompletionSetCount="2"
                     ID="AutoCompleteExtender1" runat="server"></cc1:AutoCompleteExtender> &nbsp;
                <asp:Button ID="BtnSel" runat="server" Text="搜索"  />
    </div>
</asp:Content>

