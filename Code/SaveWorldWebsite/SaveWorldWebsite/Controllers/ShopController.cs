using SaveWorldWebsite.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveWorldWebsite.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {

            ProductServiceReference.ProductServiceClient obj = new ProductServiceReference.ProductServiceClient(); 
            
            return View(obj.GetAllProduct());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ViewBag.user = new DisasterServiceReference.DisasterServiceClient();
            var productName = collection["name"];
            var productDescription = collection["description"];
            var size = collection["size number"];
            var stock = collection["number of products"];
            var productPrice = collection["price"];
            var valid = true;

            #region validation
            var productNameMinLength = 2;
            var productNameMaxLength = 50;

            var productDescriptionMinLength = 2;
            var productDescriptionMaxLength = 255;

            if (string.IsNullOrWhiteSpace(productName))
            {
                @ViewBag.nameError = "Product name is a required field";
                valid = false;
            }
            else if (productName.Length < productNameMinLength)
            {
                ViewBag.nameError = $"Product name must contain at least {productNameMinLength} characters";
                valid = false;
            }
            else if (productName.Length > productNameMaxLength)
            {
                ViewBag.nameError = $"Product name can not contain more than {productNameMaxLength} characters";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(productDescription))
            {
                @ViewBag.descriptionError = "Product description is a required field";
                valid = false;
            }
            else if (productDescription.Length < productDescriptionMinLength)
            {
                ViewBag.descriptionError = $"Product description must contain at least {productDescriptionMinLength} characters";
                valid = false;
            }
            else if (productDescription.Length > productDescriptionMaxLength)
            {
                ViewBag.descriptionError = $"Product description can not contain more than {productDescriptionMaxLength} characters";
                valid = false;
            }


            if (string.IsNullOrWhiteSpace(size))
            {
                ViewBag.startDateError = "size is a required field";
                valid = false;
            }
            else if ((DateTime.Now - DateTime.Parse(size)).Days == 0)
            {
                size = DateTime.Now.ToString();
            }
            else if (DateTime.Now > DateTime.Parse(size))
            {
                ViewBag.startDateError = "Start date has to be either at the current moment or in future one";
                valid = false;
            }
            else if (DateTime.Parse(size) > DateTime.Parse(size))
            {
                ViewBag.startDateError = "The end date cannot have earlier date than the current moment";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(size))
            {
                ViewBag.endDateError = "Start date date is a required field";
                valid = false;
            }
            else if (DateTime.Now > DateTime.Parse(stock))
            {
                ViewBag.endDateError = "The end date cannot have earlier date than the current moment";
                valid = false;
            }
            else if (DateTime.Parse(stock) > DateTime.Parse(stock))
            {
                ViewBag.endDateError = "The end date cannot have earlier date than the current moment";
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(productPrice))
            {
                ViewBag.priceError = "Price is required field";
                valid = false;
            }
            else if (int.Parse(productPrice) <= 0)
            {
                ViewBag.priceError = "Price cannot be negative";
                valid = false;
            }
            #endregion

            if (valid)
            {
                var product = new ProductServiceReference.ProductB
                {
                    ProductName = productName,
                    ProductDescription = productDescription,
                    Size = size,
                    Stock = int.Parse(stock),
                    Price = int.Parse(productPrice),
                };


            }
            ViewBag.description = productDescription;
            ViewBag.price = productPrice;
            ViewBag.name = productName;
            ViewBag.startDate = size;
            ViewBag.endDate = stock;
            return View("Create");
        }
    }

}