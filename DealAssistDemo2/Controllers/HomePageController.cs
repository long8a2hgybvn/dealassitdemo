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
        public BuyLocation model1 = new BuyLocation();
        public List<string> nonfavlist = new List<string>();
        public List<string> nonfavlistimg = new List<string>();
        public List<string> showfavlist = new List<string>();
        public List<string> showfavlistimg = new List<string>();
        public void getfavlist()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            SqlCommand getfavlist = new SqlCommand("SELECT SoThich From dbo.BangNgDung Where ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            var favlist = getfavlist.ExecuteScalar();
            var fav = new fav();
            for (int i = 0; i < fav.catalist.Count; i++)
            {
                if (favlist == null||favlist.ToString().Contains(fav.catalist[i]) == false )
                {
                    nonfavlistimg.Add(fav.cataimg[i]);
                    nonfavlist.Add(fav.catalist[i]);
                }
                else
                {
                    showfavlistimg.Add(fav.cataimg[i]);
                    showfavlist.Add(fav.catalist[i]);
                }
            }
            conn.Close();
        }
        public ActionResult addFav(string choosen)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            SqlCommand getfavlist1 = new SqlCommand("SELECT SoThich From dbo.BangNgDung Where ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            var favlist = getfavlist1.ExecuteScalar();
            SqlCommand replace = new SqlCommand("UPDATE dbo.BangNgDung SET SoThich=N'" + favlist+ " " + choosen + "' WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            replace.ExecuteNonQuery();
            conn.Close();
            getfavlist();
            ViewBag.nonfavlist = nonfavlist;
            ViewBag.nonfavlistimg = nonfavlistimg;
            ViewBag.showfavlist = showfavlist;
            ViewBag.showfavlistimg = showfavlistimg;
            return View("Favorite");
        }
        public HttpCookie createusercookie(string value)
        {
            HttpCookie tendangnhap = new HttpCookie("tendangnhap");
            tendangnhap.Value = value;
            tendangnhap.Expires = DateTime.Now.AddYears(2);
            return tendangnhap;
        }

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
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            string getfavoriteproductscmd = "SELECT TenSP FROM SPTheoDoi";
            SqlCommand getfavoriteproducts = new SqlCommand(getfavoriteproductscmd, conn);
            SqlDataReader reader = getfavoriteproducts.ExecuteReader();
            List<String> data = new List<string>();
            while (reader.Read())
            {
                data.Add(reader.GetString(0));
            }
            List<String> product_name = data.Distinct().ToList();
            model.getdata();
            ViewBag.urlimgage = model.urlimage;
            ViewBag.sanpham = product_name;
            ViewBag.style = "~/Styles/styles.css";
            return View();
        }
        public ActionResult Favorite()
        {
            getfavlist();
            ViewBag.nonfavlist = nonfavlist;
            ViewBag.nonfavlistimg = nonfavlistimg;
            ViewBag.showfavlist = showfavlist;
            ViewBag.showfavlistimg = showfavlistimg;
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
            if (checkuserread == null)
            {
                TempData["loginfailed"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return View("Login");
            }
            if(model.pass == null || model.user == null)
            {
                TempData["loginfailed"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return View("Login");
            }
            if(model.pass == checkuserread.ToString())
            {
                Response.Cookies.Add(createusercookie(model.user));
                ViewBag.style = "~/Styles/styles.css";
                return RedirectToAction("Index", "HomePage");
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
            SqlCommand adduser = new SqlCommand("INSERT INTO BangNgDung(ID,Pass,Fullname,Email,Gender) Values ('" + model.id + "','" + model.pass + "',N'" + model.name + "','" + model.email + "',N'" + model.gender + "')", conn);
            // ID -> Pass -> Fullname -> Email -> Gender
            adduser.ExecuteNonQuery();
            createusercookie(model.id);
            getfavlist();
            ViewBag.nonfavlist = nonfavlist;
            ViewBag.nonfavlistimg = nonfavlistimg;
            ViewBag.showfavlist = showfavlist;
            ViewBag.showfavlistimg = showfavlistimg;
            return View("Favorite");
        }
        public ActionResult UserControl()
        {
            return View();
        }
        public ActionResult Product_Details()
        {
            var data = model.sanpham;
            model.getdata();
            ViewBag.urlimgage = model.urlimage;
            ViewBag.sanpham = data;
            ViewBag.style = "~/Styles/StyleProductDetails.css";
            return View();
        }

        public ActionResult Product_table(int index)
        {
            model.getdata();
            model1.getdata();
            ViewBag.anh = model.urlimage[index];
            ViewBag.ten = model.sanpham[index];
            ViewBag.gia = model1.gia;
            ViewBag.noiban = model1.noiban;
            ViewBag.nhacungcap = model1.nhacungcap;
            ViewBag.style = "~/Styles/StyleProductTable.css";
            return View();
        }
        public int techp = 0;
        public int fashp = 0;
        public int healp = 0;
        public int house = 0;
        public int grocp = 0;
        public int trans = 0;
        public void know()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            SqlCommand getthematch = new SqlCommand("SELECT tech FROM BangNgDung WHERE ID='"+ Request.Cookies["tendangnhap"].Value.ToString() + "'",conn);
            techp = Int32.Parse(getthematch.ExecuteScalar().ToString());

        }
    }
}