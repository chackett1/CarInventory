using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    public class Expenses
    {
        [Key]
        public int ExpenseId { get; set; }

        public string ExpenseName { get; set; }
    }

    public class CarExpense
    {
        public int ExpenseId { get; set; }

        public string ExpenseName { get; set; }

        public int ProductId { get; set; }

        public int price { get; set; }

    }
}