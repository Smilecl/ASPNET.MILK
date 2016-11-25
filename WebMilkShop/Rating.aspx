<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Rating.aspx.cs" Inherits="Rating" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">

<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    .ratingStar{width:28px;height:28px;cursor:pointer;
                        background-repeat:no-repeat;}
    .filledRatingStar{background-image:url(images/filled.gif)}
    .emptyRatingStar{background-image:url(images/empty.gif)}
    .waitingRatingStar{background-image:url(images/waiting.jpg)}
</style>

</head>
<body>
     <form id="form1" >
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>          
    <div>
        牛奶名称：<asp:Label ID="lblTitle" runat="server"></asp:Label>
        <br />   
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <p>现有评论：</p>
        <br />
        <asp:Label ID="lblRating" runat="server"></asp:Label>
        <br />
        <br />
            <cc1:Rating ID="rtBook" runat="server"  AutoPostBack="true" Height="22px"  CurrentRating="3" MaxRating="5" StarCssClass="ratingStar" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" WaitingStarCssClass="waitingRatingStar" OnChanged="rtBook_Changed"></cc1:Rating>
    <br/>
        <asp:Label ID="lblWarning" runat="server" /><br/>
        您的评论：<asp:TextBox ID="txbComment" runat="server" TextMode="MultiLine" />
        <asp:Button ID="btnAddComment" runat="server" Text="发表评级" OnClick="btnAddComment_Click" /><br /><br />

        </ContentTemplate>

    </asp:UpdatePanel>
  
    </form>
</body>
</html>
</asp:Content>

