<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nonProfitReg.aspx.cs" Inherits="nonProfitReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        nonprofit reg
    </div>
    number <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredtxtNumber" ControlToValidate="txtNumber" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
    name <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtName" ControlToValidate="txtName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />

       user name <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtUserName" ControlToValidate="txtUserName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />

    password <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtPassword" ControlToValidate="txtPassword" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />

    repassword <asp:TextBox ID="txtRePassword" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="ComparetxtPassword" ControlToCompare="txtPassword" ControlToValidate="txtRePassword" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredtxtRePassword" ControlToValidate="txtRePassword" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />

    email <asp:TextBox ID="txteMail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxteMail" ControlToValidate="txteMail" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
<%--
    nonprofit name <asp:TextBox ID="textNonprofitName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtextNonprofitName" ControlToValidate="textNonprofitName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
    <br />

    contactname<asp:TextBox ID="txtContactFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtContactFirstName" ControlToValidate="txtContactFirstName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />

        contactname<asp:TextBox ID="txtContactLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtContactLastName" ControlToValidate="txtContactLastName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
    contact mail<asp:TextBox ID="txtContactMail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtContactMail" ControlToValidate="txtContactMail" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:Button ID="submitReg" runat="server" Text="submit" 
        onclick="submitReg_Click" />
    <asp:Label ID="lblApproval" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
