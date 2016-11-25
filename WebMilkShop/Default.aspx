<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
