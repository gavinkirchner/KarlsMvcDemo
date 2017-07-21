using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarlsMvcDemo.Models;
using KarlsMvcDemo.Services;

namespace KarlsMvcDemo.Controllers
{
    public class MainController : Controller
    {
        private MainModelService _service = new MainModelService();
        private MainModel _default = new MainModel()
        {
            Id = 1,
            Name = "Gavin",
            Description = "this is the default"
        };

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var model = _service.Get(1);

            return View(model == null ? _default : model);
        }

        public ActionResult Save(MainModel model)
        {
            _service.Save(model);

            return RedirectToAction("Details");
        }

        public ActionResult Details()
        {
            var model = _service.Get(1);

            return View(model == null ? _default : model);
        }
    }
}