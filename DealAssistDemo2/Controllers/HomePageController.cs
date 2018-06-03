using DealAssistDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealAssistDemo2.Controllers
{
    public class HomePageController : Controller
    {
        public ListHome model = new ListHome();
        public int numberofdata = 5;
        /* get number of packages from SQL */
        // GET: HomePage
        public ActionResult Index()
        {
            var data = model.sanpham;
            model.getdata();
            ViewBag.urlimgage = model.urlimage;
            ViewBag.sanpham = data;
            ViewBag.style = "~/Styles/styles.css";
            return View();
        }
        public ActionResult CatalogueView()
        {
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View();
        }
    }
}