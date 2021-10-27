using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarInventory.Models;

namespace CarInventory.Logic
{
    public class AppointmentActions
    {
        public bool AddAppointment(string CustomerName, string CustomerEmail, string Vehicles, string Message)
        {

            var myAppointment = new Appointment();
            myAppointment.CustomerName = CustomerName;
            myAppointment.CustomerEmail = CustomerEmail;
            myAppointment.DesiredVehicle = Vehicles;
            myAppointment.CustomerMessage = Message;

            using (ProductContext _db = new ProductContext())
            {
                // Add appointment to DB.
                _db.Appointments.Add(myAppointment);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}