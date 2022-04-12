using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel; // for [DataObject & DataObjectMethod
using System.Configuration;  // for ConfigurationManager
using System.Data;           // for CommandType of a SqlCOmmand
using System.Data.SqlClient; // for SqlConnection, SqlCommand, SqlDataReader

namespace AutoRentals
{
    [DataObject (true)]
    public static class AutoRentalDataSet
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet getVehicles()
        {
            SqlDataAdapter dAdapter;
            DataSet dSet;
            string selectText;

            selectText = "SELECT * FROM Vehicle";
            dAdapter = new SqlDataAdapter(selectText, getConnectionString());

            dSet = new DataSet();
            dAdapter.Fill(dSet);

            return dSet;
        } // getVehicles
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int updateVehicle(
            string vehicleType, string make, string model, int vyear, int seatCapacity, decimal costPerDay, string imageURL,
            string og_VIN, string og_Type, string og_Make, string og_Model, int og_VYear, int og_SeatCapacity, decimal og_CostPerDay,
            string og_ImageURL)
        {
            SqlConnection conn;
            SqlCommand cmd;
            int numRowsAffected;
            
            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Vehicle"
                + " SET vehicleType = @vehicleType, Make = @Make, Model = @Model, VYear = @Year, SeatCapacity = @SeatCapacity, CostPerDay = @CostPerday ImageURL = @ImageURL"
                + " WHERE VIN = @og_Vin"
                + "   AND VehicleType = @og_VehicleType"
                + "   AND Make = @og_Make"
                + "   AND Model = @og_Model"
                + "   AND VYear = @og_VYear"
                + "   AND SeatCapcity = @og_SeatCapacity"
                + "   AND CostPerDat = @og_CostPerDay"
                + "   AND ImageURL = @og_ImageURL";

            cmd.Parameters.AddWithValue("VehicleType", vehicleType);
            cmd.Parameters.AddWithValue("Make", make);
            cmd.Parameters.AddWithValue("Model", model);
            cmd.Parameters.AddWithValue("VYear", vyear);
            cmd.Parameters.AddWithValue("SeatCapacity", seatCapacity);
            cmd.Parameters.AddWithValue("CostPerDat", costPerDay);
            cmd.Parameters.AddWithValue("og_VIN", og_VIN);
            cmd.Parameters.AddWithValue("og_Type", og_Type);
            cmd.Parameters.AddWithValue("og_Make", og_Make);
            cmd.Parameters.AddWithValue("og_Model", og_Model);
            cmd.Parameters.AddWithValue("og_VYear", og_VYear);
            cmd.Parameters.AddWithValue("og_SeatCapacity", og_SeatCapacity);
            cmd.Parameters.AddWithValue("og_CostPerDay", og_CostPerDay);
            cmd.Parameters.AddWithValue("og_ImageURL", og_ImageURL);
            conn.Open();
            numRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            return numRowsAffected;
        } // updateVehicle

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int deleteVehicle(string og_VIN, string ogVehicleType, string og_Make, string og_Model, 
            int og_VYear, int og_SeatCapacity, decimal og_CostPerDay,string og_ImageURL)
        {
            SqlConnection conn;
            SqlCommand cmd;
            int numRowsAffected;

            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Vehicle"
                + " WHERE VIN = @og_Vin"
                + "   AND VehicleType = @og_VehicleType"
                + "   AND Make = @og_Make"
                + "   AND Model = @og_Model"
                + "   AND VYear = @og_VYear"
                + "   AND SeatCapcity = @og_SeatCapacity"
                + "   AND CostPerDat = @og_CostPerDay"
                + "   AND ImageURL = @og_ImageURL";
            cmd.Parameters.AddWithValue("og_VIN", og_VIN);
            cmd.Parameters.AddWithValue("og_Type", ogVehicleType);
            cmd.Parameters.AddWithValue("og_Make", og_Make);
            cmd.Parameters.AddWithValue("og_Model", og_Model);
            cmd.Parameters.AddWithValue("og_VYear", og_VYear);
            cmd.Parameters.AddWithValue("og_SeatCapacity", og_SeatCapacity);
            cmd.Parameters.AddWithValue("og_CostPerDay", og_CostPerDay);
            cmd.Parameters.AddWithValue("og_ImageURL", og_ImageURL);
            conn.Open();
            numRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return numRowsAffected;
        } // deleteVehicle
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int insertBook(string VIN, string vehicleType, string make, string model, int vyear, 
            int seatCapacity, decimal costPerDay, string imageURL)
        {
            SqlConnection conn;
            SqlCommand cmd;
            int numRowsAffected;

            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Vehicle VALUES ("
                + VIN + ",'" + vehicleType + "','" + make + "'," + "','" + model + "','" + vyear + "','" + seatCapacity + "','" +
                costPerDay + "','" + imageURL + ")";
            conn.Open();
            numRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return numRowsAffected;
        } // insertVehicle

        private static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["AutoRentalConnectionString"].ConnectionString;
        } // getConnectionString
    }
}