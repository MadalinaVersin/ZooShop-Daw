using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models;

namespace ZooShop.Controllers
{
    public class VaccineController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Vaccine
        public ActionResult Index()
        {
            List<Vaccine> vaccines = db.Vaccines.ToList();
            ViewBag.Vaccines = vaccines;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult New()
        {
            Vaccine vaccine = new Vaccine();
            vaccine.Animals = new List<Animal>();
            return View(vaccine);
        }

        [HttpPost]
        public ActionResult New(Vaccine vaccineRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Vaccines.Add(vaccineRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(vaccineRequest);
            }
            catch (Exception e)
            {
                return View(vaccineRequest);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Vaccine vaccine = db.Vaccines.Find(id);
                if (vaccine == null)
                {
                    return HttpNotFound("Couldn't find the vaccine with id " + id.ToString());
                }
                return View(vaccine);
            }
            return HttpNotFound("Missing vaccine id parameter!");
        }
        [HttpPut]
        public ActionResult Edit(int id, Vaccine vaccineRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Vaccine vaccine = db.Vaccines.Find(id);

                    if (TryUpdateModel(vaccine))
                    {
                        vaccine.Name = vaccineRequest.Name;
                        vaccine.Price = vaccineRequest.Price;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(vaccineRequest);
            }
            catch (Exception e)
            {
                return View(vaccineRequest);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine != null)
            {
                db.Vaccines.Remove(vaccine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the vaccine with id " + id.ToString());
        }
    }
}