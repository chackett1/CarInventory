using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarInventory.Models;

namespace CarInventory.Logic
{
    public class AddProducts
    {
        private ProductContext _db = new ProductContext();

        public bool AddProduct(string ProductName, string ProductDesc, string ProductPrice, string ProductPriceDealership, string ProductCategory, string ProductImagePath)
        {
            var myProduct = new Product();
            myProduct.ProductName = ProductName;
            myProduct.Description = ProductDesc;
            myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
            myProduct.UnitPriceDealership = Convert.ToDouble(ProductPriceDealership);
            myProduct.ImagePath = ProductImagePath;
            myProduct.CategoryID = Convert.ToInt32(ProductCategory);

            var myPurchase = new Purchase();
            myPurchase.CarName = ProductName;
            myPurchase.UnitPrice = Convert.ToDouble(ProductPriceDealership);

            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.Products.Add(myProduct);
                _db.Purchases.Add(myPurchase);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
        public List<Purchase> GetPurchases()
        {
            return _db.Purchases.ToList();
        }
        public List<Sale> GetSales()
        {
            return _db.Sales.ToList();
        }

        public List<CarExpense> GetExpenses()
        {
            return _db.CarExpenses.ToList();
        }
    }
}