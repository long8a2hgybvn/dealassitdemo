using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealAssistDemo2.Models
{
    public class CatalogueView
    {
        public List<string> techstuff = new List<string>()
        {
            "Điện thoại di động",
            "Máy tính bảng",
            "Laptop",
            "Máy tính bàn",
            "Loa và Tai nghe",
            "Máy chơi game",
            "Camera",
            "Phụ kiện di động",
            "Phụ kiện máy tính",
            "Thiết bị mạng",
            "Thiết bị đeo",
            "Thiết bị lưu trữ"
        };
        public List<string> techstuffimg = new List<string>()
        {
            "Assets/Picture/techstuff/dt.jpg",
            "Assets/Picture/techstuff/ipad.jpg",
            "Assets/Picture/techstuff/laptop.jpg",
            "Assets/Picture/techstuff/case.jpg",
            "Assets/Picture/techstuff/tainghe.jpg",
            "Assets/Picture/techstuff/game.jpg",
            "Assets/Picture/techstuff/mayanh.jpg",
            "Assets/Picture/techstuff/acdt.jpg",
            "Assets/Picture/techstuff/aclaptop.jpg",
            "Assets/Picture/techstuff/wifi.jpg",
            "Assets/Picture/techstuff/watch.jpg",
            "Assets/Picture/techstuff/luutru.jpg"
        };
        public List<string> household = new List<string>()
        {
            "Thiết bị TV & Video",
            "Dàn âm thanh gia đình",
            "Điện gia dụng gia đình",
            "Điều hòa & lọc khí",
            "Máy hút bụi & vệ sinh sàn",
            "Thiết bị chắm sóc cá nhân",
            "Ngoại thất"
        };
        public List<string> householdimg = new List<string>()
        {
            "Assets/Picture/household/1.jpg",
            "Assets/Picture/household/2.jpg",
            "Assets/Picture/household/3.jpg",
            "Assets/Picture/household/4.jpg",
            "Assets/Picture/household/5.jpg",
            "Assets/Picture/household/6.jpg",
            "Assets/Picture/household/7.jpg",
        };
        public List<string> fashion = new List<string>()
        {
            "Trang phục nam",
            "Trang phục nữ",
            "Giày nam",
            "Giày nữ",
            "Đồ lót nam",
            "Đồ lót nữ",
            "Túi xách",
            "Đồng hồ",
            "Phụ kiện nữ",
            "Phụ kiện nam"
        };
        public List<string> fashionimg = new List<string>()
        {
            ""
        };
        public List<string> healthcare = new List<string>()
        {
            "Đồ dùng làm đẹp",
            "Thiết bị y tế"
        };

    }
}