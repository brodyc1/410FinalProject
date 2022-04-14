<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserve.aspx.cs" Inherits="AutoRentals.Reserve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reserve</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Reserve A Vehicle</h1>
            <table>
                <tr>
                    <td><asp:label id="lblRentalID" runat="server" text="RentalID"></asp:label></td>
                    <%-- I think we'll have to create rental id somehow (maybe pageload creates one?) --%>
                    <td><asp:label id="lblRentalIDValue" runat="server" text=""></asp:label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblVIN" runat="server" Text="VIN"></asp:Label></td>
                     <%-- Get Value from previous page (assume they're coming from the catalog page) --%>
                    <td><asp:Label ID="lblVINValue" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <%--<td><asp:Label ID="lblRentalStartDate" runat="server" Text="Start Date"></asp:Label></td>--%>
                    <td colspan="2"><asp:Calendar ID="calStartDate" runat="server" Caption="Choose Start Date"></asp:Calendar></td>
                   <%-- <td><asp:TextBox ID="txtRentalStartDate" runat="server"></asp:TextBox></td>--%>
                </tr>
                <tr>
                    <%--<td><asp:Label ID="lblRentalEndDate" runat="server" Text="End Date"></asp:Label></td>--%>
                    <td colspan="2"><asp:Calendar ID="calEndDate" runat="server" Caption="Choose End Date"></asp:Calendar></td>
                    <%--<td><asp:TextBox ID="txtRentalEndDate" runat="server"></asp:TextBox></td>--%>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnReserveVehicle" runat="server" Text="Reserve Vehicle" OnClick="btnReserveVehicle_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
