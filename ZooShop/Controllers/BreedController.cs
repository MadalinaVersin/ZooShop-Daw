using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models;

namespace ZooShop.Controllers
{
    public class BreedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Breed
        public ActionResult Index()
        {
            ViewBag.Breeds = db.Breeds.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            Breed breed = new Breed();
            return View(breed);
        }

        [HttpPost]
        public ActionResult New(Breed breedRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Breeds.Add(breedRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(breedRequest);
            }
            catch (Exception e)
            {
                return View(breedRequest);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Breed breed = db.Breeds.Find(id);
                if (breed == null)
                {
                    return HttpNotFound("Couldn't find the breed with id " + id.ToString() + "!");
                }
                return View(breed);
            }
            return HttpNotFound("Couldn't find the breed with id " + id.ToString() + "!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Breed breedRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Breed breed = db.Breeds.Find(id);
                    if (TryUpdateModel(breed))
                    {
                        breed.BreedName = breedRequest.BreedName;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(breedRequest);
            }
            catch (Exception e)
            {
                return View(breedRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Breed breed = db.Breeds.Find(id);
                if (breed != null)
                {
                    db.Breeds.Remove(breed);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the breed with id " + id.ToString() + "!");
            }
            return HttpNotFound("Breed id parameter is missing!");
        }
    }
}
