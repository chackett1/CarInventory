using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarInventory.Models;

namespace CarInventory.Logic
{
    public class AppointmentActions
    {
        private ProductContext _db = new ProductContext();

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

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public List<Appointment> GetAppointments()
        {
            return _db.Appointments.ToList();
        }

        public void RemoveAppointment(int removeAppointmentID)
        {
            using (var _db = new CarInventory.Models.ProductContext())
            {
                try
                {
                    var myAppointment = (from c in _db.Appointments where c.AppointmentID == removeAppointmentID select c).FirstOrDefault();
                    if (myAppointment != null)
                    {
                        // Remove Item.
                        _db.Appointments.Remove(myAppointment);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Appointment - " + exp.Message.ToString(), exp);
                }
            }
        }
    }
}