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
        public ActionResult cataTech()
        {
            ViewBag.PreCata = "techstuff";
            ViewBag.PreCataText = "Đồ công nghệ và phụ kiện";
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View("CatalogueView");
        }
        public ActionResult cataTV()
        {
            ViewBag.PreCata = "household";
            ViewBag.PreCataText = "Thiết bị gia dụng & đồ bếp";
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View("CatalogueView");
        }
        public ActionResult cataFashion()
        {
            ViewBag.PreCata = "fashion";
            ViewBag.PreCataText = "Thời trang";
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View("CatalogueView");
        }
        public ActionResult cataHealth()
        {
            ViewBag.PreCata = "healthcare";
            ViewBag.PreCataText = "Sức khỏe & làm đẹp";
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View("CatalogueView");
        }
        public ActionResult cataGro()
        {
            ViewBag.PreCata = "grocery";
            ViewBag.PreCataText = "Hàng tạp hóa";
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View("CatalogueView");
        }
        public ActionResult cataTrans()
        {
            ViewBag.PreCata = "cataTrans";
            ViewBag.PreCataText = "Phương tiện & Thiết bị định vị";
            ViewBag.style = "~/Styles/stylescatalogueview.css";
            return View("CatalogueView");
        }
    }
}