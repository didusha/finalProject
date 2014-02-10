<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="companyLogin.aspx.cs" Inherits="publicPages_companyLogin" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

         <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
         <script src="http://code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <script src="../js/companyLogin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
         user name  <asp:TextBox ID="txtcompanyUserName" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator
             ID="RequirednonProfitUserName" runat="server" ControlToValidate="txtcompanyUserName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
          password  <asp:TextBox ID="txtcompanyPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
             ID="RequirednonProfitPassword" runat="server" ControlToValidate="txtcompanyPassword" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
         <br />
          <br />
        <asp:Button ID="LoginCompanyBTN" runat="server" Text="Login" OnClick="LoginCompanyBTN_Click"  />

        <%--<input id="LoginCompanyBTN" type="button" value="Login" runat="server" />--%>

        
         <br /> 
         <asp:Label ID="lblLoginCompany" runat="server" Text=""></asp:Label>
         <br /> <br />

        <input id="RegisterCompanyBTN" type="button" value="Register" />


    </div>
    </form>
</body>
</html>
