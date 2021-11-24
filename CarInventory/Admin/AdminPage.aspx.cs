using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarInventory.Models;
using CarInventory.Logic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;

namespace CarInventory.Admin
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Product added!";
            }
        }
        protected void VinLookup_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(vinInput.Value);
            
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string html = string.Empty;
            string url = @"https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/" + vinInput.Value + "? format=xml&modelyear=" + modelYearInput.Value;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            System.Diagnostics.Debug.WriteLine(html);
            
            html = html.Substring(html.IndexOf("Manufacturer Name</Variable><ValueId>"));
            html = html.Substring(html.IndexOf("</ValueId><Value>") + "</ValueId><Value>".Length);
            string manufacturerName = html.Substring(0, html.IndexOf(" "));
            html = html.Substring(html.IndexOf("</ValueId><Value>") + "</ValueId><Value>".Length);
            string makeName = html.Substring(0, html.IndexOf("</Value>"));
            html = html.Substring(html.IndexOf("<ValueId /><Value>") + "<ValueId /><Value>".Length);
            string modelYear = html.Substring(0, html.IndexOf("</Value>"));
            html = html.Substring(html.IndexOf("Series</Variable><ValueId /><Value>") + "Series</Variable><ValueId /><Value>".Length);
            string carSeries = html.Substring(0, html.IndexOf("</Value>"));
            html = html.Substring(html.IndexOf("Body Class</Variable><ValueId>"));
            html = html.Substring(html.IndexOf("</ValueId><Value>") + "</ValueId><Value>".Length);
            string carType = html.Substring(0, html.IndexOf("</Value>"));
            
            System.Diagnostics.Debug.WriteLine(manufacturerName);
            System.Diagnostics.Debug.WriteLine(makeName);
            System.Diagnostics.Debug.WriteLine(modelYear);
            System.Diagnostics.Debug.WriteLine(carType);
            System.Diagnostics.Debug.WriteLine(carSeries);

            AddProductName.Text = modelYear + " " + manufacturerName + " " + makeName;
            AddProductDescription.Text = "Car Series: " + carSeries;
            if (carType.Equals("Coupe"))
            {
                DropDownAddCategory.SelectedValue = "2";
            }
            else if (carType.Contains("SUV"))
            {
                DropDownAddCategory.SelectedValue = "3";
            }
            else
            {
                DropDownAddCategory.SelectedValue = "1";
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {

            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    ProductImage.PostedFile.SaveAs(path + ProductImage.FileName);
                    // Save to Images/Thumbs folder.
                    ProductImage.PostedFile.SaveAs(path + "Thumbs/" + ProductImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                // Add product data to DB.
                AddProducts products = new AddProducts();
                bool addSuccess = products.AddProduct(AddProductName.Text, AddProductDescription.Text,
                    AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Unable to accept file type.";
            }
        }

        public IQueryable GetCategories()
        {
            var _db = new CarInventory.Models.ProductContext();
            IQueryable query = _db.Categories;
            return query;
        }

        public IQueryable GetProducts()
        {
            var _db = new CarInventory.Models.ProductContext();
            IQueryable query = _db.Products;
            return query;
        }
        
    }
}