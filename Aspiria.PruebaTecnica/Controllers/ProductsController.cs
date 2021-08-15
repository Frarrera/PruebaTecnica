using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspiria.PruebaTecnica.Controllers
{
    //Solo servira para rutear las vistas
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Form");
        }

        public ActionResult Edit(int id)
        {
            return View("Form");
        }
    }
}
