using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarInventory.Logic;
using CarInventory.Models;

namespace CarInventory.Admin
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public ReportDetails GetAllReports()
        {

            AddProducts actions = new AddProducts();
            var purchaseLst = actions.GetPurchases();
            var salesLst = actions.GetSales();
            var expenseLst = actions.GetExpenses();

            ReportDetails reportDetails = new ReportDetails();
            reportDetails.totalExpenses = expenseLst.Sum(e => e.Price);
            reportDetails.totalPurchase = purchaseLst.Sum(p => p.UnitPrice);
            reportDetails.totalSales = salesLst.Sum(s => s.UnitPrice);
            reportDetails.totalProfit = reportDetails.totalSales - reportDetails.totalPurchase - reportDetails.totalExpenses;
            return reportDetails;
        }
    }
}