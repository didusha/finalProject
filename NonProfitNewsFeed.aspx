<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNotPublic.master" AutoEventWireup="true" CodeFile="NonProfitNewsFeed.aspx.cs" Inherits="NonProfitNewsFeed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>News Feed NonProfit</h1>
    <asp:HyperLink ID="profileLink" runat="server">to profile</asp:HyperLink><br />
    <asp:PlaceHolder ID="checkNews" runat="server"></asp:PlaceHolder>

</asp:Content>

