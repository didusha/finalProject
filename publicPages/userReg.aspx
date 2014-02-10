<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserReg.aspx.cs" Inherits="userReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    
</head>
<body>
    <form id="form1" runat="server">
     <div>
         User reg
    </div>
    first name <asp:TextBox ID="txtUserFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtUserFirstName" ControlToValidate="txtUserFirstName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
          last name<asp:TextBox ID="txtUserLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredtxtUserLastName" ControlToValidate="txtUserLastName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <asp:Button ID="submitUserReg" runat="server" Text="submit" onclick="submitUserReg_Click" />

    <asp:Label ID="lblApproval" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
