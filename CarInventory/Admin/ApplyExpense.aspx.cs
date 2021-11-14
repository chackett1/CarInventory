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
    public partial class ApplyExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelExpenseStatus.Text = "";
        }
        public IQueryable GetExpenses()
        {
            var _db = new CarInventory.Models.ProductContext();
            IQueryable query = _db.ExpenseItems;
            return query;
        }

        public IQueryable GetProducts()
        {
            var _db = new CarInventory.Models.ProductContext();
            IQueryable query = _db.Products;
            return query;
        }

        protected void SubmitExpenseButton_Click(object sender, EventArgs e)
        {
            LabelExpenseStatus.Text = "";
            AddExpenses addExp = new AddExpenses();
            bool addSuccess = addExp.AddExpense(DropDownAddExpenses.SelectedValue, DropDownAddExpenses.SelectedItem.Text, AddProductPrice.Text, DropDownSelectProduct.SelectedItem.Text);
            if(addSuccess)
            {
                LabelExpenseStatus.Text = "Expense Added Successfully.";
            }
        }
    }
}