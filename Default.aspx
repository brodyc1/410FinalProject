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
                <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" Width="172px" />
            </h2>
            <h2>
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" Width="172px" />
            </h2>
            <h2>
                <asp:Button ID="btnCatalog" runat="server" Text="Browse Catalog" Width="172px" />
            </h2>
        </div>
    </form>
</body>
</html>