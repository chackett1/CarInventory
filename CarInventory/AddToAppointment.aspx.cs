using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using CarInventory.Logic;

namespace CarInventory
{
    public partial class AddToAppointment: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersAppointment = new ShoppingCartActions())
                {
                    usersAppointment.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToAppointemnt.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToAppointment.aspx without setting a ProductId.");
            }
            Response.Redirect("Appointment.aspx");
        }
    }
}