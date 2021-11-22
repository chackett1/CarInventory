using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarInventory.Models;
using CarInventory.Logic;


namespace CarInventory
{
    public partial class AppointmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productName = Request.QueryString["productName"];
            Vehicle.Text = productName;

            string appointmentAction = Request.QueryString["AppointmentAction"];
            if (appointmentAction == "success")
            {
                LabelSubmitStatus.Text = "Form Successfully Submited";
            }

            if (appointmentAction == "faiure")
            {
                LabelSubmitStatus.Text = "Error Submitting Form";
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            // Add Customer Appointmnet/Message to Database
            AppointmentActions appointments = new AppointmentActions();
            bool addSuccess = appointments.AddAppointment(Name.Text, Email.Text,
                Vehicle.Text, Message.Text);

            if (addSuccess)
            {
                // Reload the page with Success Message
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?AppointmentAction=success");
            }
            else
            {
                // Show Error Submitting Form Message
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?AppointmentAction=failure");
            }
        }

    }
}