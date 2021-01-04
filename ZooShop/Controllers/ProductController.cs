using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models;

namespace ZooShop.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            ViewBag.Products = products;
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product product = db.Products.Find(id);
                if (product != null)
                {
                    return View(product);
                }
                return HttpNotFound("Couldn't find the product with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing product id parameter!");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult New()
        {
            Product product = new Product();
            product.DistributorList = GetAllDistributors();
            return View(product);
        }

        [HttpPost]
        public ActionResult New(Product productRequest)
        {
            productRequest.DistributorList = GetAllDistributors();
            try
            {
                if (ModelState.IsValid)
                {
                    //Salvam imaginea cu produsul
                    string fileName = Path.GetFileNameWithoutExtension(productRequest.ImageFile.FileName);
                    string extension = Path.GetExtension(productRequest.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    productRequest.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    productRequest.ImageFile.SaveAs(fileName);

                    db.Products.Add(productRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(productRequest);
            }
            catch (Exception e)
            {
                return View(productRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Product product = db.Products.Find(id);
                product.DistributorList = GetAllDistributors();
                if (product == null)
                {
                    return HttpNotFound("Couldn't find the product with id " + id.ToString() + "!");
                }
                return View(product);
            }
            return HttpNotFound("Missing product id parameter!");

        }

        [HttpPut]
        public ActionResult Edit(int id, Product productRequest)
        {
            productRequest.DistributorList = GetAllDistributors();
            Product product = db.Products
                        .Include("Distributor")
                        .SingleOrDefault(p => p.ProductId.Equals(id));
            try
            {
                if (ModelState.IsValid)
                {
                  
                    if (TryUpdateModel(product))
                    {
                        product.Name = productRequest.Name;
                        product.Price = productRequest.Price;
                        product.Details = productRequest.Details;
                        product.DistributorId = productRequest.DistributorId;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(productRequest);
            }
            catch (Exception e)
            {
                return View(productRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the product with id " + id.ToString());
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllDistributors()
        {
            var selectList = new List<SelectListItem>();

            foreach (var distributor in db.Distributors.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = distributor.DistributorId.ToString(),
                    Text = distributor.DistributorName
                });
            }
            return selectList;
        }
    }
}
