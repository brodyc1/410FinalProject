<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModifyVehicles.aspx.cs" Inherits="AutoRentals.AddModifyVehicles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add, Modify & Delete Vehicles</title>
    <style type="text/css">
        .auto-style1 {
            width: 237px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="True">
        <div>

            <h2>Add, Modify & Delete Vehicles</h2>
            <hr />

            <br />
            <br />
            <table border="1">
                <tr>
                    <td colspan="2" style="text-align:center;"><h3>Add Car</h3></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblVin" runat="server" Text="Vin Number"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblType" runat="server" Text="Type of Car"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblMake" runat="server" Text="Make"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMake" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSeatCapacity" runat="server" Text="Seat Capacity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSeatCapacity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCostPerDay" runat="server" Text="Cost Per Day"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCostPerDay" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUploadImage" runat="server" Text="Upload Image"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fileUploadImageFile" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAddCar" runat="server" Text="Add Car" OnClick="btnAddCar_Click" />
            <br />
            <asp:Label ID="lblStatus" runat="server" EnableViewState="False"></asp:Label>
            <br />
            <br />
        </div>
        <asp:GridView ID="gvCars" runat="server" DataSourceID="odsAutoVehicleFromDataSet" OnRowDeleted="gvCars_RowDeleted" OnRowUpdated="gvCars_RowUpdated" AutoGenerateColumns="False" Height="399px" Width="774px" style="margin-right: 314px" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="odsAutoVehicleFromDataSet" ConflictDetection="CompareAllValues" runat="server" DeleteMethod="deleteVehicle" InsertMethod="insertBook" OldValuesParameterFormatString="original_{0}" OnDeleted="odsAutoVehicleFromDataSet_Deleted" OnUpdated="odsAutoVehicleFromDataSet_Updated" SelectMethod="getVehicles" TypeName="AutoRentals.AutoRentalDataSet" UpdateMethod="updateVehicle">
            <DeleteParameters>
                <asp:Parameter Name="og_VIN" Type="String" />
                <asp:Parameter Name="ogVehicleType" Type="String" />
                <asp:Parameter Name="og_Make" Type="String" />
                <asp:Parameter Name="og_Model" Type="String" />
                <asp:Parameter Name="og_VYear" Type="Int32" />
                <asp:Parameter Name="og_SeatCapacity" Type="Int32" />
                <asp:Parameter Name="og_CostPerDay" Type="Decimal" />
                <asp:Parameter Name="og_ImageURL" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VIN" Type="String" />
                <asp:Parameter Name="vehicleType" Type="String" />
                <asp:Parameter Name="make" Type="String" />
                <asp:Parameter Name="model" Type="String" />
                <asp:Parameter Name="vyear" Type="Int32" />
                <asp:Parameter Name="seatCapacity" Type="Int32" />
                <asp:Parameter Name="costPerDay" Type="Decimal" />
                <asp:Parameter Name="imageURL" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="vehicleType" Type="String" />
                <asp:Parameter Name="make" Type="String" />
                <asp:Parameter Name="model" Type="String" />
                <asp:Parameter Name="vyear" Type="Int32" />
                <asp:Parameter Name="seatCapacity" Type="Int32" />
                <asp:Parameter Name="costPerDay" Type="Decimal" />
                <asp:Parameter Name="imageURL" Type="String" />
                <asp:Parameter Name="og_VIN" Type="String" />
                <asp:Parameter Name="og_Type" Type="String" />
                <asp:Parameter Name="og_Make" Type="String" />
                <asp:Parameter Name="og_Model" Type="String" />
                <asp:Parameter Name="og_VYear" Type="Int32" />
                <asp:Parameter Name="og_SeatCapacity" Type="Int32" />
                <asp:Parameter Name="og_CostPerDay" Type="Decimal" />
                <asp:Parameter Name="og_ImageURL" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        
        <asp:SqlDataSource ID="sdsAutoRental" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:AutoRentalConnectionString %>" DeleteCommand="DELETE FROM [Vehicle] WHERE [VIN] = @original_VIN AND (([VehicleType] = @original_VehicleType) OR ([VehicleType] IS NULL AND @original_VehicleType IS NULL)) AND (([Make] = @original_Make) OR ([Make] IS NULL AND @original_Make IS NULL)) AND (([Model] = @original_Model) OR ([Model] IS NULL AND @original_Model IS NULL)) AND (([VYear] = @original_VYear) OR ([VYear] IS NULL AND @original_VYear IS NULL)) AND (([SeatCapacity] = @original_SeatCapacity) OR ([SeatCapacity] IS NULL AND @original_SeatCapacity IS NULL)) AND (([CostPerDay] = @original_CostPerDay) OR ([CostPerDay] IS NULL AND @original_CostPerDay IS NULL)) AND (([ImageUrl] = @original_ImageUrl) OR ([ImageUrl] IS NULL AND @original_ImageUrl IS NULL))" InsertCommand="INSERT INTO [Vehicle] ([VIN], [VehicleType], [Make], [Model], [VYear], [SeatCapacity], [CostPerDay], [ImageUrl]) VALUES (@VIN, @VehicleType, @Make, @Model, @VYear, @SeatCapacity, @CostPerDay, @ImageUrl)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Vehicle]" UpdateCommand="UPDATE [Vehicle] SET [VehicleType] = @VehicleType, [Make] = @Make, [Model] = @Model, [VYear] = @VYear, [SeatCapacity] = @SeatCapacity, [CostPerDay] = @CostPerDay, [ImageUrl] = @ImageUrl WHERE [VIN] = @original_VIN AND (([VehicleType] = @original_VehicleType) OR ([VehicleType] IS NULL AND @original_VehicleType IS NULL)) AND (([Make] = @original_Make) OR ([Make] IS NULL AND @original_Make IS NULL)) AND (([Model] = @original_Model) OR ([Model] IS NULL AND @original_Model IS NULL)) AND (([VYear] = @original_VYear) OR ([VYear] IS NULL AND @original_VYear IS NULL)) AND (([SeatCapacity] = @original_SeatCapacity) OR ([SeatCapacity] IS NULL AND @original_SeatCapacity IS NULL)) AND (([CostPerDay] = @original_CostPerDay) OR ([CostPerDay] IS NULL AND @original_CostPerDay IS NULL)) AND (([ImageUrl] = @original_ImageUrl) OR ([ImageUrl] IS NULL AND @original_ImageUrl IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_VIN" Type="String" />
                <asp:Parameter Name="original_VehicleType" Type="String" />
                <asp:Parameter Name="original_Make" Type="String" />
                <asp:Parameter Name="original_Model" Type="String" />
                <asp:Parameter Name="original_VYear" Type="Int32" />
                <asp:Parameter Name="original_SeatCapacity" Type="Int32" />
                <asp:Parameter Name="original_CostPerDay" Type="Decimal" />
                <asp:Parameter Name="original_ImageUrl" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VIN" Type="String" />
                <asp:Parameter Name="VehicleType" Type="String" />
                <asp:Parameter Name="Make" Type="String" />
                <asp:Parameter Name="Model" Type="String" />
                <asp:Parameter Name="VYear" Type="Int32" />
                <asp:Parameter Name="SeatCapacity" Type="Int32" />
                <asp:Parameter Name="CostPerDay" Type="Decimal" />
                <asp:Parameter Name="ImageUrl" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VehicleType" Type="String" />
                <asp:Parameter Name="Make" Type="String" />
                <asp:Parameter Name="Model" Type="String" />
                <asp:Parameter Name="VYear" Type="Int32" />
                <asp:Parameter Name="SeatCapacity" Type="Int32" />
                <asp:Parameter Name="CostPerDay" Type="Decimal" />
                <asp:Parameter Name="ImageUrl" Type="String" />
                <asp:Parameter Name="original_VIN" Type="String" />
                <asp:Parameter Name="original_VehicleType" Type="String" />
                <asp:Parameter Name="original_Make" Type="String" />
                <asp:Parameter Name="original_Model" Type="String" />
                <asp:Parameter Name="original_VYear" Type="Int32" />
                <asp:Parameter Name="original_SeatCapacity" Type="Int32" />
                <asp:Parameter Name="original_CostPerDay" Type="Decimal" />
                <asp:Parameter Name="original_ImageUrl" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        
    </form>
</body>
</html>
