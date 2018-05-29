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
            for(int i = 0; i < numberofdata; i++)
            {
                string sanpham = "Laptop no" + (i + 1).ToString();
                data.Add(sanpham);
            }
            ViewBag.urlimgsanpham = model.urlimage;
            ViewBag.sanpham = data;
            return View();
        }
    }
}