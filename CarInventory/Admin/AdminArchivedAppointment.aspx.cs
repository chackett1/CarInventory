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
    public partial class AdminArchivedAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<ArchivedAppointment> GetAllArchivedAppointments()
        {
            ArchivedAppointmentActions actions = new ArchivedAppointmentActions();
            return actions.GetAppointments();
        }
    }
}