using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DealAssistDemo2.Models;
using System.Text;
using System.Web.Mvc;

namespace DealAssistDemo2.Models
{
    public class fav
    {
        public List<string> catalist = new List<string>()
        {
            "Đồ công nghệ & phụ kiện",
            "Thiết bị gia dụng & đồ bếp",
            "Thời trang",
            "Sức khỏe & làm đẹp",
            "Hàng tạp hóa",
            "Phương tiện & Thiết bị định vị"
        };
        public List<string> nonfavlist { get; set; }
        public List<string> cataimg = new List<string>()
        {
            "Assets/Picture/techstuff/main.jpg",
            "Assets/Picture/household/main.jpg",
            "Assets/Picture/fashion/main.jpg",
            "Assets/Picture/healthcare/main.jpg",
            "Assets/Picture/grocery/main.jpg",
            "Assets/Picture/trans/main.jpg"
        };
    }
}