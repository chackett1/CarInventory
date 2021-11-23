using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarInventory.Models;

namespace CarInventory.Logic
{
    public class ArchivedAppointmentActions
    {
        private ProductContext _db = new ProductContext();

        public bool ArchivedAddAppointment(string CustomerName, string CustomerEmail, string Vehicles, string Message)
        {

            var myAppointment = new ArchivedAppointment();
            myAppointment.ArchivedCustomerName = CustomerName;
            myAppointment.ArchivedCustomerEmail = CustomerEmail;
            myAppointment.ArchivedDesiredVehicle = Vehicles;
            myAppointment.ArchivedCustomerMessage = Message;

            using (ProductContext _db = new ProductContext())
            {
                // Add appointment to DB.
                _db.ArchivedAppointments.Add(myAppointment);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
        public List<ArchivedAppointment> GetAppointments()
        {
            return _db.ArchivedAppointments.ToList();
        }

        public void RemoveArchivedAppointment(int removeAppointmentID)
        {
            using (var _db = new CarInventory.Models.ProductContext())
            {
                try
                {
                    var myAppointment = (from c in _db.ArchivedAppointments where c.ArchivedAppointmentID == removeAppointmentID select c).FirstOrDefault();
                    if (myAppointment != null)
                    {
                        // Remove Item.
                        _db.ArchivedAppointments.Remove(myAppointment);
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