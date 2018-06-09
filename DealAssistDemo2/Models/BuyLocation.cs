using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealAssistDemo2.Models
{
    public class BuyLocation
    {
        public List<string> gia = new List<string>();
        public List<string> noiban = new List<string>();
        public List<string> nhacungcap = new List<string>();
        public void getdata()
        {
            gia.Add("10.000.000đ");
            gia.Add("15.000.000đ");
            nhacungcap.Add("Fshop");
            nhacungcap.Add("A đây rồi");
            noiban.Add("https://www.lazada.vn/#");
            noiban.Add("https://www.lazada.vn/#");
        }
    }
}