﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiciosWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Permiso permiso1 = new Permiso();


            ViewBag.Title = "Home Page";
            return View();
        }
    }
}