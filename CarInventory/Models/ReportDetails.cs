using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInventory.Models
{
    public class ReportDetails
    {
        [Key]
        public int Id { get; set; }

        public double? totalSales { get; set; }

        public double totalExpenses { get; set; }

        public double? totalPurchase { get; set; }

        public double? totalProfit { get; set; }
    }
}