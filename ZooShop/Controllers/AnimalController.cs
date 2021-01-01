using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models;

namespace ZooShop.Controllers
{
    public class AnimalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Animal
        public ActionResult Index()
        {
            List<Animal> animals = db.Animals.Include("Breed").ToList();
            ViewBag.Animals = animals;
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Animal animal = db.Animals.Find(id);
                if (animal != null)
                {
                    return View(animal);
                }
                return HttpNotFound("Couldn't find the animal with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing animal id parameter!");
        }

        [HttpGet]
        public ActionResult New()
        {
            Animal animal = new Animal();
            animal.BreedList = GetAllBreeds();
            animal.VaccineList = GetAllVaccines();
            animal.Vaccines = new List<Vaccine>();
            return View(animal);
        }
        [HttpPost]
        public ActionResult New(Animal animalRequest)
        {
            animalRequest.BreedList = GetAllBreeds();

            var selectedVaccines = animalRequest.VaccineList.Where(b => b.Checked).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    animalRequest.Vaccines = new List<Vaccine>();
                    for (int i = 0; i < selectedVaccines.Count(); i++)
                    {
                        Vaccine vaccine = db.Vaccines.Find(selectedVaccines[i].Id);
                        animalRequest.Vaccines.Add(vaccine);
                    }
                    db.Animals.Add(animalRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(animalRequest);
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return View(animalRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Animal animal = db.Animals.Find(id);
                animal.BreedList = GetAllBreeds();
                animal.VaccineList = GetAllVaccines();

                foreach (Vaccine checkedVaccine in animal.Vaccines)
                { 
                    animal.VaccineList.FirstOrDefault(v => v.Id == checkedVaccine.VaccineId).Checked = true;
                }
                if (animal == null)
                {
                    return HttpNotFound("Coludn't find the animal with id " + id.ToString() + "!");
                }
                return View(animal);
            }
            return HttpNotFound("Missing animal id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Animal animalRequest)
        {
            animalRequest.BreedList = GetAllBreeds();

            // preluam animalul pe care vrem sa il modificam din baza de date
            Animal animal = db.Animals.Include("Breed")
                        .SingleOrDefault(b => b.AnimalId.Equals(id));

            // memoram intr-o lista doar vaccinele care au fost selectate din formular
            var selectedVaccines = animalRequest.VaccineList.Where(b => b.Checked).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(animal))
                    {
                        animal.Name = animalRequest.Name;
                        animal.Price = animalRequest.Price;
                        animal.Details = animalRequest.Details;
                        animal.Gender = animalRequest.Gender;
               
                        animal.Vaccines.Clear();
                        animal.Vaccines = new List<Vaccine>();

                        for (int i = 0; i < selectedVaccines.Count(); i++)
                        {
                            // asiguram lista de vaccine animalului pe care vrem sa il editam 
                            Vaccine vaccine = db.Vaccines.Find(selectedVaccines[i].Id);
                            animal.Vaccines.Add(vaccine);
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(animalRequest);
            }
            catch (Exception)
            {
                return View(animalRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal != null)
            {
                db.Animals.Remove(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the animal with id " + id.ToString() + "!");
        }



        [NonAction]
        public List<CheckBoxViewModel> GetAllVaccines()
        {
            var checkboxList = new List<CheckBoxViewModel>();
            foreach (var vaccine in db.Vaccines.ToList())
            {
                checkboxList.Add(new CheckBoxViewModel
                {
                    Id = vaccine.VaccineId,
                    Name = vaccine.Name,
                    Checked = false
                });
            }
            return checkboxList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllBreeds()
        {
            var selectList = new List<SelectListItem>();

            foreach (var breed in db.Breeds.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = breed.BreedId.ToString(),
                    Text = breed.BreedName
                });
            }
            return selectList;
        }




    }
}