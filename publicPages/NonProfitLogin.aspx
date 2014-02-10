<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NonProfitLogin.aspx.cs" Inherits="NonProfitLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

         <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
         <script src="http://code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <script src="../js/nonProfitLogin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
         user name  <asp:TextBox ID="txtnonProfitUserName" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator
             ID="RequirednonProfitUserName" runat="server" ControlToValidate="txtnonProfitUserName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
          password  <asp:TextBox ID="txtnonProfitPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
             ID="RequirednonProfitPassword" runat="server" ControlToValidate="txtnonProfitPassword" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
         <br />
          <br />
        <asp:Button ID="LoginNonProfitBTN" runat="server" Text="Login" 
             onclick="LoginNonProfitBTN_Click" />

         <br /> 
         <asp:Label ID="lblLoginNonProfit" runat="server" Text=""></asp:Label>
         <br /> <br />

        <input id="RegisterNonProfitBTN" type="button" value="Register" />


    </div>
    </form>
</body>
</html>
