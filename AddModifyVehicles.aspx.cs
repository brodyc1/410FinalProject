using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoRentals
{
    public partial class AddModifyVehicles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsAutoVehicleFromDataSet_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            e.AffectedRows = Convert.ToInt32(e.ReturnValue);
        } // ods DataSet Updated
        protected void gvCars_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblStatus.Text = "Unable to save changes. " + e.Exception.Message;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
            {
                lblStatus.Text = "Update failed. Someone else changed or deleted this student.";
            }
            else
            {
                lblStatus.Text = "Car was updated.";
            }
        } //gv row updated

        protected void odsAutoVehicleFromDataSet_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            e.AffectedRows = Convert.ToInt32(e.ReturnValue);
        } //ods row deleted 

        protected void gvCars_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblStatus.Text = "Unable to delete. " + e.Exception.Message;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
            {
                lblStatus.Text = "Delete failed. Someone else changed or deleted this Vehicle.";
            }
            else
            {
                lblStatus.Text = "Car was deleted.";
            }
        } //end row deleted

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            string vin, type, make, model, year, seatCapacity, costPerDay, imageURL;
            int isThisAnInteger;
            double isThisADecimal;
            // DateTime isThissADate;
            vin = txtVin.Text;
            type = txtType.Text;
            make = txtMake.Text;
            model = txtModel.Text;
            year = txtYear.Text;
            seatCapacity = txtSeatCapacity.Text;
            costPerDay = txtCostPerDay.Text;
            imageURL = ""; //temporary until I figure out how to do that
            // NOTE: We use a try catch FormatException doing Convert.ToInt32
            //       of both the BookID and the Year from those two textboxes.
            //       We do NOT use the ints produced, but do display an error
            //       if they are not integers.
            //       Only if both conversions work do we
            //       use another try catch to do the insert stuff.
            try
            {
                isThisAnInteger = Convert.ToInt32(seatCapacity);
                isThisAnInteger = Convert.ToInt32(year);
               // isThisADecimal = Convert.ToDouble(costPerDay); -- cost per day now a varchar ?
               // isThisADate = Convert.ToDateTime(year);
                try
                {
                    odsAutoVehicleFromDataSet.InsertParameters["VIN"].DefaultValue = vin;
                    odsAutoVehicleFromDataSet.InsertParameters["VehicleType"].DefaultValue = type;
                    odsAutoVehicleFromDataSet.InsertParameters["Make"].DefaultValue = make;
                    odsAutoVehicleFromDataSet.InsertParameters["VYear"].DefaultValue = year;
                    odsAutoVehicleFromDataSet.InsertParameters["SeatCapacity"].DefaultValue = seatCapacity;
                    odsAutoVehicleFromDataSet.InsertParameters["CostPerDay"].DefaultValue = costPerDay;
                    odsAutoVehicleFromDataSet.InsertParameters["ImageURL"].DefaultValue = imageURL;

                    odsAutoVehicleFromDataSet.Insert();
                    lblStatus.Text = "Vehicle added Successfully";
                } // Inserted OK
                catch (Exception insertException)
                {
                    // NOTE: We have to get the InnerException hiding inside of the Exception
                    //       Otherwise, the message will just say an error occurred,
                    //       and not tell us anything about what kind of an error it was.
                    Exception innerException = insertException.InnerException;
                    lblStatus.Text = "Insert failed: " + innerException.Message;

                } // Insert failed
            } // Yes, they are integer numbers
            
            catch (FormatException formatException)
            {
                lblStatus.Text = "You must enter integer values for Year and SeatCapacity and a deimal for CostPerDay.";
            } // No, they are not integer numbers
        } // Add this Vehicle
    }//end class
} //end namespace