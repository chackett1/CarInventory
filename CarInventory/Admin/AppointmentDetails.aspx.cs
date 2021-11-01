using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarInventory.Models;
using System.Web.ModelBinding;

namespace CarInventory.Admin
{
    public partial class AppointmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Appointment> GetAppointment([QueryString("AppointmentID")] int? appointmentId)
        {
            var _db = new CarInventory.Models.ProductContext();
            IQueryable<Appointment> query = _db.Appointments;
            if (appointmentId.HasValue && appointmentId > 0)
            {
                query = query.Where(p => p.AppointmentID == appointmentId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}