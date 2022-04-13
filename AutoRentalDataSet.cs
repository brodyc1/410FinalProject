﻿using System;
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
        public static DataSet GetVehicles()
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
        public static int UpdateVehicle(
            string vehicleType, string make, string model, int vyear, int seatCapacity, string costPerDay, string imageURL,
            string original_VIN, string original_VehicleType, string original_Make, string original_Model, 
            int original_VYear, int original_SeatCapacity, string original_CostPerDay,
            string original_ImageURL)
            //VehicleType, Make, Model, VYear, SeatCapacity, 
            //CostPerDay, ImageUrl, original_VIN, original_VehicleType, 
            //original_Make, original_Model, original_VYear, original_SeatCapacity, original_CostPerDay, original_ImageUrl, VIN.
        {
            SqlConnection conn;
            SqlCommand cmd;
            int numRowsAffected;
            
            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Vehicle"
                + " SET vehicleType = @vehicleType, Make = @Make, Model = @Model, VYear = @Year, SeatCapacity = @SeatCapacity, CostPerDay = @CostPerday, ImageURL = @ImageURL"
                + " WHERE VIN = @original_VIN"
                + "   AND VehicleType = @original_VehicleType"
                + "   AND Make = @original_Make"
                + "   AND Model = @original_Model"
                + "   AND VYear = @original_VYear"
                + "   AND SeatCapcity = @original_SeatCapacity"
                + "   AND CostPerDat = @original_CostPerDay"
                + "   AND ImageURL = @original_ImageURL";

            cmd.Parameters.AddWithValue("VehicleType", vehicleType);
            cmd.Parameters.AddWithValue("Make", make);
            cmd.Parameters.AddWithValue("Model", model);
            cmd.Parameters.AddWithValue("VYear", vyear);
            cmd.Parameters.AddWithValue("SeatCapacity", seatCapacity);
            cmd.Parameters.AddWithValue("CostPerDat", costPerDay);
            cmd.Parameters.AddWithValue("original_VIN", original_VIN);
            cmd.Parameters.AddWithValue("original_Type", original_VehicleType);
            cmd.Parameters.AddWithValue("original_Make", original_Make);
            cmd.Parameters.AddWithValue("original_Model", original_Model);
            cmd.Parameters.AddWithValue("original_VYear", original_VYear);
            cmd.Parameters.AddWithValue("original_SeatCapacity", original_SeatCapacity);
            cmd.Parameters.AddWithValue("original_CostPerDay", original_CostPerDay);
            cmd.Parameters.AddWithValue("original_ImageURL", original_ImageURL);
            conn.Open();
            numRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            return numRowsAffected;
        } // updateVehicle

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int deleteVehicle(string og_VIN, string ogVehicleType, string og_Make, string og_Model, 
            int og_VYear, int og_SeatCapacity, string og_CostPerDay,string og_ImageURL)
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
        public static int insertVehicle(string VIN, string vehicleType, string make, string model, int vyear, 
            int seatCapacity, string costPerDay, string imageURL)
        {
            SqlConnection conn;
            SqlCommand cmd;
            int numRowsAffected;

            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Vehicle VALUES ('"
                + VIN + "','" + vehicleType + "','" + make + "','" + model + "'," + vyear + "," + seatCapacity + ",'" +
                costPerDay + "','" + imageURL + "')";
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