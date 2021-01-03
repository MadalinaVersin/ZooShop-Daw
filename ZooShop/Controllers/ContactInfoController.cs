using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models;

namespace ZooShop.Controllers
{
    public class ContactInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ContactInfo

        [HttpGet]
        public ActionResult Index(int? id)
        {
            ContactInfo contactInfo = db.ContactInfos.Find(id);
            return View(contactInfo);
        }

        [HttpGet]
        public ActionResult New()
        {
            ContactInfo contact = new ContactInfo();
            return View(contact);

        }
        [HttpPost]
        public ActionResult New(ContactInfo contactRequest)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.ContactInfos.Add(contactRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Distributor");
                }
                return View(contactRequest);
            }
            catch (Exception e)
            {
                return View(contactRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                ContactInfo contactInfo = db.Distributors.Find(id).ContactInfo;
                
                if (contactInfo == null)
                {
                    return HttpNotFound("Couldn't find the contact with id " + id.ToString() + "!");
                }
                return View(contactInfo);
            }
            return HttpNotFound("Couldn't find the contact with id " + id.ToString() + "!"); 
        }

        
        

    }
}