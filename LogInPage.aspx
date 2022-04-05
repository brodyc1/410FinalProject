<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="AutoRental.LogInPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Log In</h2>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            </p>
            
        </div>
    </form>
</body>
</html>
