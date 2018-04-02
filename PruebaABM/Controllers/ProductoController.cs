using PruebaABM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaABM.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            test_abmContext db = new test_abmContext();
           // List<producto> lista = db.producto.ToList();

            return View(db.producto.ToList());
        }
    }
}