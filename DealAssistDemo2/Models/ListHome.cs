using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealAssistDemo2.Models
{
    public class ListHome
    {
        public List<string> sanpham = new List<string>();
        public List<string> urlimage = new List<string>();
        public void getdata()
        {
            sanpham.Add("Laptop1");
            sanpham.Add("Laptop2");
            sanpham.Add("Laptop3");
            sanpham.Add("Laptop4");
            sanpham.Add("Laptop5");
            urlimage.Add("Assets/Picture/bee.jpg");
            urlimage.Add("Assets/Picture/bee.jpg");
            urlimage.Add("Assets/Picture/bee.jpg");
            urlimage.Add("Assets/Picture/bee.jpg");
            urlimage.Add("Assets/Picture/bee.jpg");
        }
    }
}