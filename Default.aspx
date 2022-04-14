<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutoRental.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Auto Rental Service</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Auto Rental Service</h2>
            <h3>Welcome!</h3>
            <h2>
                <a href="LogInPage.aspx"><asp:Button ID="btnLogIn" runat="server" Text="Log In" Width="172px" /></a>
            </h2>
            <h2>
                <a href="LogInPage.aspx"><asp:Button ID="btnSignUp" runat="server" Text="Sign Up" Width="172px" /></a>
            </h2>
            <h2>
                <a href="LogInPage.aspx"><asp:Button ID="btnCarCatalog" runat="server" Text="Car Catalog" Width="172px" /></a>
            </h2>
        </div>
    </form>
</body>
</html>