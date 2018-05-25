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
        // GET: HomePage
        public ActionResult Index()
        {
            var data = model.sanpham;
            ViewBag.urlimgsanpham = model.urlimage;
            ViewBag.sanpham = data;
            return View();
        }
    }
}