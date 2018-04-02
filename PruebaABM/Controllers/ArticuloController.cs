using PruebaABM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaABM.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            test_abmContext db = new test_abmContext();

            return View(db.articulos.ToList());
        }
    }
}