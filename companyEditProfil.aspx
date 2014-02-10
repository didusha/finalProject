<%@ Page Language="C#" MasterPageFile="~/MasterPageNotPublic.master" AutoEventWireup="true" CodeFile="companyEditProfil.aspx.cs" Inherits="companyEditProfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/nonProfitEditProfile.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<p>
        welcome company</p>
        hello: 

        <%--יש להכניס את כל שדות עריכת החברה--%>
        <%--יש לעדכן מאמתים--%>
    <asp:Label ID="lblHello" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="imgLogo" CssClass="imgLogo" runat="server" ImageUrl="~/systemImages/avidan_tal.jpg"/>
   

    <asp:FileUpload ID="uploadLogo" runat="server"/>
    <br />
    <asp:Image ID="imgProfile" CssClass="imgProfile" runat="server" ImageUrl="~/systemImages/avidan_tal.jpg" />
    
    <asp:FileUpload ID="uploadProfile" runat="server"/>
     <br />
    <asp:TextBox ID="txtAbout" runat="server" TextMode="MultiLine" Rows="10" Columns="50"></asp:TextBox>

    <asp:TextBox ID="txtGoals" runat="server" TextMode="MultiLine" Rows="10" Columns="50"></asp:TextBox>

    <br />
    <asp:Button ID="saveBtn" runat="server" Text="save changes" 
        onclick="saveBtn_Click" />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
    <br />
    <asp:HyperLink ID="viewProfile" runat="server">to profile</asp:HyperLink>
</asp:Content>

