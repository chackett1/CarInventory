using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarInventory.Models;
using CarInventory.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace CarInventory.Admin
{
    public partial class AdminAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Appointment> GetAllAppointments()
        {
            AppointmentActions actions = new AppointmentActions();
            return actions.GetAppointments();
        }
    }
}