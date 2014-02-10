<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNotPublic.master" AutoEventWireup="true" CodeFile="UserEditProfile.aspx.cs" Inherits="UserEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .imgProfile
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
        welcome User</p>
        hello: 

        <%--יש להכניס את כל שדות עריכת המתמ--%>
        <%--יש לעדכן מאמתים--%>
    <asp:Label ID="lblHello" runat="server" Text=""></asp:Label>
    <br />

    <br />
    <asp:Image ID="imgProfile" CssClass="imgProfile" runat="server" 
        ImageUrl="~/systemImages/avidan_tal.jpg" Width="116px" />
    
    <asp:FileUpload ID="uploadProfile" runat="server"/>
     <br />
      <br />
    phone <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
     <br />
    cell phone<asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
     <br />
    <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
        <asp:ListItem Value="m" > male </asp:ListItem>
    <asp:ListItem Value="f"> female </asp:ListItem>
    </asp:RadioButtonList>
    <br />
  <%--  לשנות פורמט יום הולדת אם צריך--%>
   birth Date <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="saveBtn" runat="server" Text="save changes" 
        onclick="saveBtn_Click" />
     <br />
    <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
    <br />
    <asp:HyperLink ID="viewProfile" runat="server">to profile</asp:HyperLink>
</asp:Content>

