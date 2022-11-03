﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Skiil_CodeFirstEntity.Models.Siniflar;

namespace Skiil_CodeFirstEntity.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            Context context = new Context();
            var degerler = context.Yeteneklers.ToList();
            return View(degerler);
        }
    }
}