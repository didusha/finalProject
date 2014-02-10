<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNotPublic.master" AutoEventWireup="true" CodeFile="NonProfitProfile.aspx.cs" Inherits="NonProfitProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/nonProfitProfile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        welcome nonProfit</p>
        hello: 
    <asp:Label ID="lblHello" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="imgLogo" CssClass="imgLogo" runat="server"/>
   
    <asp:Image ID="imgProfile" CssClass="imgProfile" runat="server" />
  
    <asp:Panel ID="pnlAbout" runat="server">
    </asp:Panel>
    <asp:Panel ID="pnlGoals" runat="server">
    </asp:Panel>
    <asp:HyperLink ID="editProfile" runat="server" Visible="false">edit profile</asp:HyperLink><br />
    <asp:HyperLink ID="uploadCampaign" runat="server" Visible="false">uplaod campaign</asp:HyperLink>
</asp:Content>

