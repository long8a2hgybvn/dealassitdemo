using DealAssistDemo2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DealAssistDemo2.Controllers
{
    public class HomePageController : Controller
    {
        public ListHome model = new ListHome();
        public int numberofdata = 5;
        // Trusted Login
        //
        //
        public ActionResult TrustedIndex()
        {
            ViewBag.style = "~/Styles/styles.css";
            return View("Index");
        }
        // End Trusted Login
        public ActionResult Index()
        {
            var data = model.sanpham;
            ViewBag.urlimgage = model.urlimage;
            ViewBag.sanpham = data;
            ViewBag.style = "~/Styles/styles.css";
            return View();
        }
        public ActionResult Favorite()
        {
            return View();
        }
        [HttpPost]
        public ActionResult userlogin(loginhandle model)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            string checkusercmd = "SELECT Pass FROM BangNgDung WHERE ID ='" + model.user + "'";
            SqlCommand checkuser = new SqlCommand(checkusercmd, conn);
            var checkuserread = checkuser.ExecuteScalar();
            if(model.pass == null || model.user == null)
            {
                TempData["loginfailed"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return View("Login");
            }
            if(model.pass == checkuserread.ToString())
            {
                ViewBag.style = "~/Styles/styles.css";
                return View("Index");
            }
            else
            {
                TempData["loginfailed"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return View("Login");
            }
            
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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signupsubmit(signup model)
        {
            ViewBag.error = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            if (model.checkpass == null || model.email ==null || model.gender == null || model.id == null|| model.name ==null || model.pass == null )
            {
                TempData["alertMessage"] = "Vui lòng điền đầy đủ các trường";
                return View("Signup");
            }
            if(model.checkpass != model.pass)
            {
                TempData["alertMessage"] = "Nhập lại mật khẩu không khớp";
                return View("Signup");
            }
            if(model.pass.Length < 4 || model.pass.Length > 20)
            {
                TempData["alertMessage"] = "Password yêu cầu có độ dài lớn hơn 4 và nhỏ hơn 20";
                return View("Signup");
            }
            string checkusercmd = "SELECT * FROM BangNgDung WHERE 'ID' ='" + model.id + "'";
            SqlCommand checkuser = new SqlCommand(checkusercmd,conn);
            var checkuserread = checkuser.ExecuteScalar();
            if (checkuserread != null)
            {
                TempData["alertMessage"] = "Tên đăng nhập đã tồn tại";
            }
            SqlCommand adduser = new SqlCommand("INSERT INTO BangNgDung Values ('" + model.id + "','" + model.pass + "',N'" + model.name + "','" + model.email + "',N'" + model.gender + "')", conn);
            // ID -> Pass -> Fullname -> Email -> Gender
            adduser.ExecuteNonQuery();
            return View("Signup");
        }
    }
}