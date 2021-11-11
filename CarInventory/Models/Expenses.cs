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
        [Key]
        public int Id { get; set; }

        public int ExpenseId { get; set; }

        public string ExpenseName { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }

    }
}