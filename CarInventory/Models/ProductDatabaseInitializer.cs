using System.Collections.Generic;
using System.Data.Entity;

namespace CarInventory.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
            GetAppointments().ForEach(z => context.Appointments.Add(z));
            GetPurchases().ForEach(p => context.Purchases.Add(p));
            GetSales().ForEach(s => context.Sales.Add(s));
            GetExpenses().ForEach(e => context.ExpenseItems.Add(e));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Sedan"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Coupe"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "SUV"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Minivan"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Convertible"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "2021 Honda Civic",
                    Description = "Honda Civic's are one of the most reliable cars.",
                    ImagePath="2021-honda-civic.jpg",
                    UnitPrice = 22265.00,
                    CategoryID = 1
               },
                new Product
                {
                    ProductID = 2,
                    ProductName = "2021 Kia Rio",
                    Description = "Kia Rio's are very popular cars.",
                    ImagePath="2021-kia-rio.jpg",
                    UnitPrice = 17045.00,
                    CategoryID = 1
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "2021 Mazda 3",
                    Description = "Mazada 3's are very popular cars.",
                    ImagePath="2021-mazda-3.jpg",
                    UnitPrice = 21645.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "2021 Volkswagen Jetta",
                    Description = "Volkswagen Jetta's are very popular cars.",
                    ImagePath="2021-volkswagen-jetta.jpg",
                    UnitPrice = 31990.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "2022 Hyundai Accent",
                    Description = "Hyundai Accent's are very popular cars.",
                    ImagePath="2022-hyundai-accent.jpg",
                    UnitPrice = 17670.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "2022 Hyundai Elantra",
                    Description = "Hyundai Elantra's are very popular cars.",
                    ImagePath="2022-hyundai-elantra.jpg",
                    UnitPrice = 20875.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "2022 BMW 230",
                    Description = "BMW 230's are very fast cars.",
                    ImagePath="2022-BMW-230.jpg",
                    UnitPrice = 36350.00,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "2021 Toyota RAV4",
                    Description = "Toyota RAV4's are very big cars.",
                    ImagePath="2021-Toyota-RAV4.jpg",
                    UnitPrice = 22182.00,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "2021 Honda Odyssey",
                    Description = "Honda Odyssey's are very big cars.",
                    ImagePath="2021-Honda-Odyssey.jpg",
                    UnitPrice = 20875.00,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "2021 Chevrolet Corvette",
                    Description = "Chevrolet Corvette's are very fast cars.",
                    ImagePath="2021-Chevrolet-Corvette.jpg",
                    UnitPrice = 41845.00,
                    CategoryID = 5
                }
            };

            return products;
        }

        private static List<Expenses> GetExpenses()
        {
            var expenseList = new List<Expenses> {
                new Expenses
                {
                    ExpenseId = 1,
                    ExpenseName = "Vehicle registration fees"
                },
                new Expenses
                {
                     ExpenseId = 2,
                    ExpenseName = "Licenses"
                },
                new Expenses
                {
                    ExpenseId = 3,
                    ExpenseName = "Gas"
                },
                new Expenses
                {
                     ExpenseId = 4,
                    ExpenseName = "Insurance"
                },
                new Expenses
                {
                    ExpenseId = 5,
                    ExpenseName = "Repairs"
                },
                new Expenses
                {
                    ExpenseId = 6,
                    ExpenseName = "Tires"
                },
                new Expenses
                {
                    ExpenseId = 7,
                    ExpenseName = "Oil"
                },
                new Expenses
                {
                    ExpenseId = 8,
                    ExpenseName = "Garage rent"
                },
                new Expenses
                {
                    ExpenseId = 9,
                    ExpenseName = "Vehicle title"
                }
            };

            return expenseList;
        }

        private static List<Appointment> GetAppointments()
        {
            var appointments = new List<Appointment> {
                new Appointment
                {
                    AppointmentID = 1,
                    CustomerName = "John Smith",
                    CustomerEmail = "johnsmith@gmail.com",
                    DesiredVehicle = "Ford Mustang 2021",
                    CustomerMessage = "Please contact me, I'd love to book an appointment to view this car sometime next week."
                },
                
            };

            return appointments;
        }

        private static List<Purchase> GetPurchases()
        {
            var purchases = new List<Purchase> {
                new Purchase
                {
                    purchaseID = 1,
                    CarName = "2021 Honda Civic",
                    UnitPrice = 22265.00
                },
                new Purchase
                {
                    purchaseID = 2,
                    CarName = "2021 Kia Rio",
                    UnitPrice = 17045.00
                },
                new Purchase
                {
                    purchaseID = 3,
                    CarName = "2021 Mazda 3",
                    UnitPrice = 21645.00
                },
                new Purchase
                {
                    purchaseID = 4,
                    CarName = "2021 Volkswagen Jetta",
                    UnitPrice = 31990.00
                },
                new Purchase
                {
                    purchaseID = 5,
                    CarName = "2022 Hyundai Accent",
                    UnitPrice = 17670.00
                },
                new Purchase
                {
                    purchaseID = 6,
                    CarName = "2022 Hyundai Elantra",
                    UnitPrice = 20875.00
                },
                new Purchase
                {
                    purchaseID = 7,
                    CarName = "2022 BMW 230",
                    UnitPrice = 36350.00
                },
                new Purchase
                {
                    purchaseID = 8,
                    CarName = "2021 Toyota RAV4",
                    UnitPrice = 22182.00
                },
                new Purchase
                {
                    purchaseID = 9,
                    CarName = "2021 Honda Odyssey",
                    UnitPrice = 20875.00
                },
                new Purchase
                {
                    purchaseID = 10,
                    CarName = "2021 Chevrolet Corvette",
                    UnitPrice = 41845.00
                }
            };
            return purchases;
        }

        private static List<Sale> GetSales()
        {
            var sales = new List<Sale> {/*
                new Sale
                {
                    purchaseID = 1,
                    SaleID = 1,
                    CarName = "Test Car Name",
                    UnitPrice = 100
                },
            */};
            return sales;
        }
    }
}
