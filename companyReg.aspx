<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyReg.aspx.cs" Inherits="companyReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        company reg
    </div>
    company number <asp:TextBox ID="txtCompanyNumber" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredtxtCompanyNumber" ControlToValidate="txtCompanyNumber" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
    company name <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtCompanyName" ControlToValidate="txtCompanyName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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

    company e-mail <asp:TextBox ID="txteMail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxteMail" ControlToValidate="txteMail" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />


    contact first name<asp:TextBox ID="txtContactFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtContactFirstName" ControlToValidate="txtContactFirstName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />

        contact last name<asp:TextBox ID="txtContactLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtContactLastName" ControlToValidate="txtContactLastName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
    contact e-mail<asp:TextBox ID="txtContactMail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtContactMail" ControlToValidate="txtContactMail" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:Button ID="submitReg" runat="server" Text="submit" 
        onclick="submitCompanyReg_Click" />
    <asp:Label ID="lblApproval" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>