using DealAssistDemo2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DealAssistDemo2.Controllers
{
    public class HomePageController : Controller
    {

        List<string> urlimg = new List<string>();
        List<string> tensanpham = new List<string>();
        public ActionResult showdataproduct(string input)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            SqlCommand getdata = new SqlCommand("SELECT TenSP From BangSP WHERE Muc =N'" + input + "'", conn);
            SqlDataReader reader = getdata.ExecuteReader();
            while (reader.Read())
            {
                tensanpham.Add(reader.GetString(0));
            }
            reader.Close();
            List<string> product = tensanpham.Distinct().ToList<string>();
            for (int i = 0; i < product.Count; i++)
            {
                string getfavoriteproductscmd1 = "SELECT HinhAnh FROM BangSP WHERE TenSP='" + product[i] + "'";
                SqlCommand getfavoriteproducts1 = new SqlCommand(getfavoriteproductscmd1, conn);
                urlimg.Add(getfavoriteproducts1.ExecuteScalar().ToString());
            }

            ViewBag.product = product;
            ViewBag.urlimage = urlimg;
            ViewBag.style = "~/Styles/viewProductStyle.css";
            return View("showCataProduct");
        }
        public ActionResult showCataProduct()
        {
            ViewBag.style = "~/Styles/viewProductStyle.css";
            return View();
        }
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
                if (favlist == null || favlist.ToString().Contains(fav.catalist[i]) == false)
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
            SqlCommand replace = new SqlCommand("UPDATE dbo.BangNgDung SET SoThich=N'" + favlist + " " + choosen + "' WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
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
            List<String> product_name = new List<string>();
            while (reader.Read())
            {
                product_name.Add(reader.GetString(0));
            }
            reader.Close();

            string getfavoriteproductscmd1 = "SELECT HinhAnh FROM SPTheoDoi";
            SqlCommand getfavoriteproducts1 = new SqlCommand(getfavoriteproductscmd1, conn);
            SqlDataReader reader1 = getfavoriteproducts1.ExecuteReader();
            List<String> urlimage = new List<string>();
            while (reader1.Read())
            {
                urlimage.Add(reader1.GetString(0));
            }
            reader1.Close();

            ViewBag.urlimage = urlimage;
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
            if (model.pass == null || model.user == null)
            {
                TempData["loginfailed"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return View("Login");
            }
            if (model.pass == checkuserread.ToString())
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
            ViewBag.PreCata = "tech";
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
            if (model.checkpass == null || model.email == null || model.gender == null || model.id == null || model.name == null || model.pass == null)
            {
                TempData["alertMessage"] = "Vui lòng điền đầy đủ các trường";
                return View("Signup");
            }
            if (model.checkpass != model.pass)
            {
                TempData["alertMessage"] = "Nhập lại mật khẩu không khớp";
                return View("Signup");
            }
            if (model.pass.Length < 4 || model.pass.Length > 20)
            {
                TempData["alertMessage"] = "Password yêu cầu có độ dài lớn hơn 4 và nhỏ hơn 20";
                return View("Signup");
            }
            string checkusercmd = "SELECT * FROM BangNgDung WHERE 'ID' ='" + model.id + "'";
            SqlCommand checkuser = new SqlCommand(checkusercmd, conn);
            var checkuserread = checkuser.ExecuteScalar();
            if (checkuserread != null)
            {
                TempData["alertMessage"] = "Tên đăng nhập đã tồn tại";
            }
            Response.Cookies.Add(createusercookie(model.id));
            SqlCommand adduser = new SqlCommand("INSERT INTO BangNgDung(ID,Pass,Fullname,Email,Gender) Values ('" + model.id + "','" + model.pass + "',N'" + model.name + "','" + model.email + "',N'" + model.gender + "')", conn);
            // ID -> Pass -> Fullname -> Email -> Gender
            adduser.ExecuteNonQuery();

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
        public ActionResult Product_table(string product_name)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            //Ten san pham
            string get_name_tocomparecmd = "SELECT TenSP FROM BangSP";
            SqlCommand get_name_tocompare = new SqlCommand(get_name_tocomparecmd, conn);
            SqlDataReader reader = get_name_tocompare.ExecuteReader();
            List<String> name = new List<string>();
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            reader.Close();
            //Ma san pham
            string get_id_tocomparecmd = "SELECT MaSP FROM BangSP";
            SqlCommand get_id_tocompare = new SqlCommand(get_id_tocomparecmd, conn);
            SqlDataReader reader1 = get_id_tocompare.ExecuteReader();
            List<String> id = new List<string>();
            while (reader1.Read())
            {
                id.Add(reader1.GetString(0));
            }
            reader1.Close();
            //Noi ban
            string get_source_tocomparecmd = "SELECT NoiBan FROM BangSP";
            SqlCommand get_source_tocompare = new SqlCommand(get_source_tocomparecmd, conn);
            SqlDataReader reader2 = get_source_tocompare.ExecuteReader();
            List<String> source = new List<string>();
            while (reader2.Read())
            {
                source.Add(reader2.GetString(0));
            }
            reader2.Close();
            //Ma nha cung cap
            string get_supplier_tocomparecmd = "SELECT MaNCC FROM BangSP";
            SqlCommand get_supplier_tocompare = new SqlCommand(get_supplier_tocomparecmd, conn);
            SqlDataReader reader3 = get_supplier_tocompare.ExecuteReader();
            List<String> supplier = new List<string>();
            while (reader3.Read())
            {
                supplier.Add(reader3.GetString(0));
            }
            reader3.Close();
            //Dia chi website
            string get_link_tocomparecmd = "SELECT DiaChiWebSite FROM BangSP";
            SqlCommand get_link_tocompare = new SqlCommand(get_link_tocomparecmd, conn);
            SqlDataReader reader4 = get_link_tocompare.ExecuteReader();
            List<String> link = new List<string>();
            while (reader4.Read())
            {
                link.Add(reader4.GetString(0));
            }
            reader4.Close();
            //Gia
            string get_price_tocomparecmd = "SELECT GiaHienThi FROM BangSP";
            SqlCommand get_price_tocompare = new SqlCommand(get_price_tocomparecmd, conn);
            SqlDataReader reader5 = get_price_tocompare.ExecuteReader();
            List<String> price = new List<String>();
            while (reader5.Read())
            {
                price.Add(reader5.GetString(0));
            }
            reader5.Close();
            //Hinh Anh
            string get_img_tocomparecmd = "SELECT HinhAnh FROM BangSP WHERE TenSp = '" + product_name + "'";
            SqlCommand get_img_tocompare = new SqlCommand(get_img_tocomparecmd, conn);
            string urlanh = get_img_tocompare.ExecuteScalar().ToString();

            List<String> MaSP = new List<String>();
            List<String> NoiBan = new List<String>();
            List<String> MaNCC = new List<String>();
            List<String> Website = new List<String>();
            List<String> Gia = new List<String>();

            for (int i = 0; i < name.Count; i++)
            {
                if (name[i] == product_name)
                {
                    MaSP.Add(id[i]);
                    NoiBan.Add(source[i]);
                    MaNCC.Add(supplier[i]);
                    Website.Add(link[i]);
                    Gia.Add(price[i]);
                }
            }
            model.getdata();
            model1.getdata();

            ViewBag.anh = urlanh;
            ViewBag.ten = product_name;

            ViewBag.gia = Gia;
            ViewBag.noiban = NoiBan;
            ViewBag.website = Website;
            ViewBag.mancc = MaNCC;
            ViewBag.style = "~/Styles/StyleProductTable.css";
            return View();
        }
        public ActionResult Product_Details(string urlanh)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            string getfavoriteproductscmd = "SELECT TenSP FROM BangSP WHERE Muc = N'Điện thoại di động'";
            SqlCommand getfavoriteproducts = new SqlCommand(getfavoriteproductscmd, conn);
            SqlDataReader reader = getfavoriteproducts.ExecuteReader();
            List<string> product_name = new List<string>();
            while (reader.Read())
            {
                product_name.Add(reader.GetString(0));
            }
            reader.Close();
            List<string> product = new List<string>();
            product = product_name.Distinct().ToList<string>();

            List<String> urlimage = new List<string>();
            for (int i = 0; i < product.Count; i++)
            {
                string getfavoriteproductscmd1 = "SELECT HinhAnh FROM BangSP WHERE TenSP = '" + product[i] + "'";
                SqlCommand getfavoriteproducts1 = new SqlCommand(getfavoriteproductscmd1, conn);
                urlimage.Add(getfavoriteproducts1.ExecuteScalar().ToString());
            }

            ViewBag.anh = urlanh;
            ViewBag.urlimgage = urlimage;
            ViewBag.sanpham = product;
            ViewBag.style = "~/Styles/StyleProductDetails.css";
            return View();
        }

        public int tech = 0;
        public int fashion = 0;
        public int healthcare = 0;
        public int household = 0;
        public int grocery = 0;
        public int trans = 0;
        public void know()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            SqlCommand gettechp = new SqlCommand("SELECT tech FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            tech = Int32.Parse(gettechp.ExecuteScalar().ToString());
            SqlCommand getfashp = new SqlCommand("SELECT fashion FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            fashion = Int32.Parse(getfashp.ExecuteScalar().ToString());
            SqlCommand gettrans = new SqlCommand("SELECT trans FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            trans = Int32.Parse(getfashp.ExecuteScalar().ToString());
            SqlCommand gethouse = new SqlCommand("SELECT household FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            household = Int32.Parse(getfashp.ExecuteScalar().ToString());
            SqlCommand getheal = new SqlCommand("SELECT healcare FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            healthcare = Int32.Parse(getfashp.ExecuteScalar().ToString());
            SqlCommand getgroc = new SqlCommand("SELECT grocery FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            grocery = Int32.Parse(getfashp.ExecuteScalar().ToString());
            List<int> bundle = new List<int>()
            {
                tech,fashion,healthcare,household,grocery,trans
            };
            int best = bundle.Max();
            int count = bundle.IndexOf(best);
            string bestcatalog = "";
            switch (count)
            {
                case 0:
                    bestcatalog = "tech";
                    break;
                case 1:
                    bestcatalog = "fashion";
                    break;
                case 2:
                    bestcatalog = "healthcare";
                    break;
                case 3:
                    bestcatalog = "household";
                    break;
                case 4:
                    bestcatalog = "grocery";
                    break;
                case 5:
                    bestcatalog = "trans";
                    break;
            }
            SqlCommand getlovetag = new SqlCommand("SELECT " + bestcatalog + " FROM BangNgDung WHERE ID='" + Request.Cookies["tendangnhap"].Value.ToString() + "'", conn);
            string alltag = getlovetag.ExecuteScalar().ToString();

        }
        List<string> result = new List<string>();
        public ActionResult ProductPage()
        {
            ViewBag.urlimage = urlimg;
            ViewBag.result = result;
            ViewBag.style = "~/Styles/viewProductStyle.css";
            return View();
        }
        [HttpPost]
        public ActionResult getProduct(FormCollection model)
        {
            if (ViewBag.input != null)
            {
                search laymodel = new search();
                laymodel.inputstring = ViewBag.input;
            }
            string input_string = model["inputstring"];
            string cataloge = model["danhmuc"];
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            conn.Open();
            string getfavoriteproductscmd = "SELECT TenSP FROM BangSP";
            SqlCommand getfavoriteproducts = new SqlCommand(getfavoriteproductscmd, conn);
            SqlDataReader reader = getfavoriteproducts.ExecuteReader();
            List<String> product_name = new List<string>();
            while (reader.Read())
            {
                product_name.Add(reader.GetString(0));
            }

            string getfavoriteproductscmd1 = "SELECT Muc FROM BangSP";
            SqlCommand getfavoriteproducts1 = new SqlCommand(getfavoriteproductscmd1, conn);
            SqlDataReader reader1 = getfavoriteproducts1.ExecuteReader();
            List<String> theloai = new List<string>();
            while (reader1.Read())
            {
                theloai.Add(reader1.GetString(0));
            }

            string getfavoriteproductscmd2 = "SELECT HinhAnh FROM BangSP";
            SqlCommand getfavoriteproducts2 = new SqlCommand(getfavoriteproductscmd2, conn);
            SqlDataReader reader2 = getfavoriteproducts2.ExecuteReader();

            while (reader2.Read())
            {
                urlimg.Add(reader2.GetString(0));
                for (int i = 0; i < product_name.Count; i++)
                {
                    if (product_name[i].ToLower().Contains(input_string.ToLower()) || theloai[i] == cataloge)
                    {
                        result.Add(product_name[i]);
                    }
                }
                conn.Close();
                ViewBag.product = result.Distinct().ToList<string>();
                ViewBag.style = "~/Styles/viewProductStyle.css";
            }
            return RedirectToAction("ProductPage", "HomePage");
        }
    }
}