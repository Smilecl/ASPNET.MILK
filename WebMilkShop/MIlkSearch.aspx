<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="MIlkSearch.aspx.cs" Inherits="MIlkSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
      <style type="text/css">
        .divBg {
            width: 160px;
            height: 30px;
            color: #000000;
            font-weight: bold;
            line-height: 30px;
        }

        .contentBg {
            width: 160px;
            height: 30px;
            color: #3e0971;
            font-weight: bold;
            line-height: 30px;
        }

        .ratingStar {
            width: 28px;
            height: 28px;
            cursor: pointer;
            background-repeat: no-repeat;
        }

        .filledRatingStar {
            background-image: url(images/filled.gif);
        }

        .emptyRatingStar {
            background-image: url(images/empty.gif);
        }

        .waitingRatingStar {
            background-image: url(images/waiting.jpg);
        }

        .auto-style3 {
            width: 487px;
        }

        .auto-style4 {
            width: 74px;
            height: 36px;
            text-align: center;
        }

        .auto-style5 {
            width: 487px;
            height: 36px;
        }

        .auto-style6 {
            width: 74px;
            text-align: center;
        }
    </style>
    </head>
<body>
     <form id="form1" action="" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="div1" style="float: left">
                    <asp:Panel ID="pnlHidden" runat="server">
                        热门牛奶列表<br />
                        <br />
                        <cc1:Accordion ID="Accordion1" runat="server"                          
                            HeaderCssClass="divBg"
                            ContentCssClass="contentBg"
                            AutoSize="None"></cc1:Accordion>
                    </asp:Panel>
                </div>
                <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                    TargetControlID="pnlHidden"
                    ExpandControlID="imgbtnDirection"
                    CollapseControlID="imgbtnDirection"
                    CollapsedText="显示..."
                    ExpandedText="隐藏"
                    ImageControlID="imgbtnDirection"
                    ExpandedImage="~/images/toleft.gif"
                    CollapsedImage="~/images/toright.gif">
                </cc1:CollapsiblePanelExtender>
                <div id="div2" style="float: left; width: 20px; height: 37%; padding-top: 110px; text-align: center">
                    <asp:ImageButton ID="imgbtnDirection" ImageUrl="~/images/toleft.gif" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
           <div>    
    <asp:TextBox ID="TextBox1" runat="server" Width="276px" Height="16px" ></asp:TextBox>
                <cc1:AutoCompleteExtender
                     TargetControlID="TextBox1"
                    ServicePath="~/MyWebService/SearchMilk.asmx"
                    ServiceMethod="GetMilkHotSearchKeywords"
                    MinimumPrefixLength="1"
                    EnableCaching="true"
                    CompletionSetCount="2"
                     ID="AutoCompleteExtender1" runat="server"></cc1:AutoCompleteExtender> &nbsp;
    </div>
        <asp:Panel ID="pnlShow" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>                     
   
               </ContentTemplate>
                </asp:UpdatePanel>
        </asp:Panel>
         </form>
    </body>
</html>
    </asp:Content>