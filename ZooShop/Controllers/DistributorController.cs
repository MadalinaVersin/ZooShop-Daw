using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models;

namespace ZooShop.Controllers
{
    public class DistributorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Distributor
        [HttpGet]
        public ActionResult Index()
        {
            List<Distributor> distributors = db.Distributors.ToList();
            ViewBag.Distributors = distributors;
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Distributor distributor = db.Distributors.Find(id);
                if (distributor != null)
                {
                    return View(distributor);
                }
                return HttpNotFound("Couldn't find the distributor with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing distributor id parameter!");

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult New()
        {
            DistributorContactInfoViewModel dc = new DistributorContactInfoViewModel();
            return View(dc);
        }
        [HttpPost]
        public ActionResult New(DistributorContactInfoViewModel dcRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactInfo contact = new ContactInfo
                    {
                        PhoneNumber = dcRequest.PhoneNumber,
                        Email = dcRequest.Email
                    };
                    //vom adauga in baza de date ambele obiecte
                    db.ContactInfos.Add(contact);
                    Distributor distributor = new Distributor
                    {
                        DistributorName = dcRequest.DistributorName,
                        ContactInfo = contact
                    };
                    db.Distributors.Add(distributor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(dcRequest);
            }
            catch (Exception e)
            {
                return View(dcRequest);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Distributor distributor = db.Distributors.Find(id);

                if (distributor == null)
                {
                    return HttpNotFound("Couldn't find the distributor with id " + id.ToString());
                }
                return View(distributor);
            }
            return HttpNotFound("Missing distributor id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Distributor distributorRequest)
        {
            //Distributor distributor =db.Distributors.Include("ContactInfo").SingleOrDefault(p => p.DistributorId == id);

            try
            {
                if (ModelState.IsValid)
                {
                    Distributor distributor = db.Distributors.Include("ContactInfo").SingleOrDefault(p => p.DistributorId == id);
                    ContactInfo contactInfo = db.ContactInfos.SingleOrDefault(c => c.ContactInfoId == distributor.ContactInfo.ContactInfoId);

                    if (TryUpdateModel(distributor))
                    {
                        contactInfo.PhoneNumber = distributorRequest.ContactInfo.PhoneNumber;
                        contactInfo.Email = distributorRequest.ContactInfo.Email;
                        distributor.DistributorName = distributorRequest.DistributorName;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(distributorRequest);
            }
            catch (Exception e)
            {

                return View(distributorRequest);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Distributor distributor = db.Distributors.Find(id);
            ContactInfo contact = db.ContactInfos.Find(distributor.ContactInfo.ContactInfoId);
            if (distributor != null)
            {
                db.Distributors.Remove(distributor);
                db.ContactInfos.Remove(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the distributor with id " + id.ToString());
        }
    }
}