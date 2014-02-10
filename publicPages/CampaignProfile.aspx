<%@ Page Title="" Language="C#" MasterPageFile="~/publicPages/MasterPage.master" AutoEventWireup="true" CodeFile="CampaignProfile.aspx.cs" Inherits="publicPages_CampaignProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Campaign Profile</h1>
    Logo<asp:Image ID="imgLogo" runat="server" />
    <br />
    Campaign name <h1 id="campaignHeader" runat="server"></h1>
    <br />
    Campaign picture 
    <asp:Image ID="imgCampaign" runat="server" />
    <br />
    Campaign money Goal 
    <p id="campaignGoal" runat="server"></p>
    days left - 
    <asp:Label ID="lblDaysLeft" runat="server"></asp:Label>
</asp:Content>

