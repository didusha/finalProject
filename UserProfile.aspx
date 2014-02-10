<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNotPublic.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        welcome User</p>
        hello: 
    <asp:Label ID="lblHello" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="imgProfile" CssClass="imgProfile" runat="server" />
  
    <asp:Panel ID="pnlcellphone" runat="server">
    </asp:Panel>
    <asp:Panel ID="pnlphone" runat="server">
    </asp:Panel>
       <asp:Panel ID="pnlgender" runat="server">
    </asp:Panel>
    <asp:Panel ID="pnlbirthdate" runat="server">
    </asp:Panel>
    <asp:HyperLink ID="editProfile" runat="server" Visible="false">edit profile</asp:HyperLink><br />
  
</asp:Content>

