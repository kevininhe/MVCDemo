using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class StudentsController : Controller
    {
        private UnvDBContext db = new UnvDBContext();

        // GET: Students
        public ActionResult Index()
        {
            var Students = db.Students.Select(s => s).OrderBy(s => s.FirstName);
            return View(Students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            var model = new Student();
            model.ListOfUniversities = db.Universities.ToList();
            return View(model);
        }
        


        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                student.ListOfUniversities = db.Universities.ToList();
                return View(student);
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CheckSons(int sons)
        {
            if(sons == 0)
            {
                return Json("I'm sure you have more sons!", JsonRequestBehavior.AllowGet);
            }
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public List<University> GetUniversities()
        {
            return db.Universities.ToList();
        }
    }
}
