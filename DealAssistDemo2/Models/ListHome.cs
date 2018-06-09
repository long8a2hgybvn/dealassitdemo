using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace DealAssistDemo2.Models
{
    public class ListHome
    {
        public List<string> sanpham = new List<string>();
        public List<string> urlimage = new List<string>();
        public string error = "";
        public void getsql()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @" Data Source= 103.27.60.66; Initial Catalog= dealassi_dealassist; User ID = dealassist; Password = 12345";
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                error = e.ToString();
            }
        }
    }
}