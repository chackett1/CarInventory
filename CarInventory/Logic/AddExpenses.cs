using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarInventory.Models;

namespace CarInventory.Logic
{
    public class AddExpenses
    {
        private ProductContext _db = new ProductContext();

        public bool AddExpense(string expenseId, string expenseName, string price, string productName)
        {
            var expense = new CarExpense();
            expense.ExpenseId = Convert.ToInt32(expenseId);
            expense.ExpenseName = expenseName;
            expense.Price = Convert.ToDouble(price);
            expense.ProductName = productName;
            using (ProductContext _db = new ProductContext())
            {
                // Add expense to DB.
                _db.CarExpenses.Add(expense);
                _db.SaveChanges();
            }
            //Success.
            return true;
        }
    }
}