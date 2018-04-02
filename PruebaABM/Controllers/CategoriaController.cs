using PruebaABM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaABM.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            test_abmContext db = new test_abmContext();

            return View(db.categoria.ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(categoria c)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (test_abmContext db = new test_abmContext())
                {
                    db.categoria.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al crear Categoria.", ex);
                return View();
            }
            
        }

        public ActionResult Edit(int id)
        {
            using (var db = new test_abmContext())
            {
                //categoria cat = db.categoria.Where(c => c.IdCategoria == id).FirstOrDefault();
                categoria cat = db.categoria.Find(id);
                return View(cat);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(categoria c)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new test_abmContext())
                {
                    categoria cat = db.categoria.Find(c.IdCategoria);
                    cat.Nombre = c.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al editar Categoria.", ex);
                return View();
            }
        }


        public ActionResult View(int id)
        {
            using (var db = new test_abmContext())
            {
                categoria cat = db.categoria.Find(id);
                return View(cat);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (var db = new test_abmContext())
            {
                categoria cat = db.categoria.Find(id);
                db.categoria.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}