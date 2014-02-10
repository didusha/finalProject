<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <script src="../js/userLogin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
      user name  <asp:TextBox ID="txtUserUserName" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator
             ID="RequiredtxtUserUserName" runat="server" ControlToValidate="txtUserUserName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
          password  <asp:TextBox ID="txtUserPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
             ID="RequiredtxtUserPassword" runat="server" ControlToValidate="txtUserPassword" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
         <br />
          <br />
        <asp:Button ID="LoginUserBTN" runat="server" Text="Login" onclick="LoginUserBTN_Click" />

         <br /> 
         <asp:Label ID="lblLoginUser" runat="server" Text=""></asp:Label>
         <br /> <br />

        <input id="RegisterUserBTN" type="button" value="Register" />

    </form>
</body>
</html>
