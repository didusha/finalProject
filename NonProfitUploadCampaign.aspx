<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNotPublic.master" AutoEventWireup="true" CodeFile="NonProfitUploadCampaign.aspx.cs" Inherits="NonProfitUploadCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="//code.jquery.com/jquery-1.9.1.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="js/nonProfitUploadCampaign.js" type="text/javascript"></script>
    <link href="css/nonProfitUploadCampaign.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--להוסיף מאמתים לכל השדות--%><%--לסדר עיצוב של דברים--%>money goal <asp:TextBox ID="txtMoneyGoal" runat="server"></asp:TextBox><%--לודא שמוכנס מספר גדול מ-0--%>
    <br />
    people reach goal <asp:TextBox ID="txtPeopleGoal" runat="server"></asp:TextBox>
    <br />
    start date <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
    <asp:ImageButton ID="imgCalenderStartDate" runat="server" 
        ImageUrl="~/systemImages/calender.jpg" Height="20px" 
        onclick="imgCalender_Click" Width="30px" />
    <br />

    <asp:Calendar ID="Calendar1" runat="server"  CssClass="calender"
        onselectionchanged="Calendar1_SelectionChanged">
    </asp:Calendar>

    end date <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
    <asp:ImageButton ID="imgCalenderEndDate" runat="server" 
        ImageUrl="~/systemImages/calender.jpg" Height="20px" 
         Width="30px" onclick="imgCalenderEndDate_Click" />
    <br />

    <asp:Calendar ID="Calendar2" runat="server"  CssClass="calender" onselectionchanged="Calendar2_SelectionChanged" >
    </asp:Calendar>
    <br />
    Campaign content<asp:TextBox ID="txtCampaignContent" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox><br />
    Campaign name  <asp:TextBox ID="txtCampaignName" runat="server"></asp:TextBox><br />
    movie<asp:FileUpload ID="uploadMovie" runat="server" />
    <br />
    picture<asp:FileUpload ID="uploadPicture" runat="server" />
    <br />
    <asp:TextBox ID="txtSearchWord" runat="server"></asp:TextBox> 
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/systemImages/Forward Arrow.png" Width="30" Height="30" 
        onclick="ImageButton1_Click" />
    <asp:TextBox ID="txtSearchWordList" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
    <br />
    קטגוריות
    <asp:CheckBoxList ID="categoryList" runat="server">
    <asp:ListItem Text="רווחה"></asp:ListItem>
    <asp:ListItem Text="בריאות"></asp:ListItem>
    </asp:CheckBoxList>
    <br />
    קהל יעד
    <asp:CheckBoxList ID="crowdDestList" runat="server">
    <asp:ListItem Text="ילדים"></asp:ListItem>
    <asp:ListItem Text="מוזיקאים"></asp:ListItem>
    </asp:CheckBoxList>

    <br />
    הודעת תודה:<br />
    <asp:TextBox ID="txtThanx" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <br />

    <asp:Button ID="uploadBtn" runat="server" Text="upload Campaign" 
        onclick="uploadBtn_Click" />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> &nbsp 
    <asp:HyperLink ID="campaignProfile" runat="server" Visible="false">view campaign profile</asp:HyperLink>
</asp:Content>

