using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarInventory.Models;
using CarInventory.Logic;
using System.Web.ModelBinding;

namespace CarInventory.Admin
{
    public partial class AppointmentDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ArchiveButton_Click(object sender, EventArgs e)
        {
            AppointmentActions actions = new AppointmentActions();
            ArchivedAppointmentActions archive_actions = new ArchivedAppointmentActions();

            int ID = Int32.Parse(Request.QueryString["AppointmentID"]);

            var _db = new CarInventory.Models.ProductContext();
            Appointment toArchive = _db.Appointments.Where(p => p.AppointmentID == ID).FirstOrDefault();

            archive_actions.ArchivedAddAppointment(toArchive.CustomerName, toArchive.CustomerEmail,
                toArchive.DesiredVehicle, toArchive.CustomerMessage);

            actions.RemoveAppointment(ID);
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