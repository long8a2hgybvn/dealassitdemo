using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealAssistDemo2.Models
{
    public class CatalogueView
    {
        public List<string> tech = new List<string>()
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
            "Ngoại thất",
            "Nội thất",
            "Dụng cụ làm bếp"

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
            "Assets/Picture/household/8.jpg",
            "Assets/Picture/household/9.jpg"
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
            "Assets/Picture/fashion/1.jpg",
            "Assets/Picture/fashion/2.jpg",
            "Assets/Picture/fashion/3.jpg",
            "Assets/Picture/fashion/4.jpg",
            "Assets/Picture/fashion/5.png",
            "Assets/Picture/fashion/6.jpg",
            "Assets/Picture/fashion/7.jpg",
            "Assets/Picture/fashion/8.jpg",
            "Assets/Picture/fashion/9.jpg",
            "Assets/Picture/fashion/10.jpg"
        };
        public List<string> healthcare = new List<string>()
        {
            "Đồ dùng làm đẹp",
            "Thiết bị y tế",
            "Chăm sóc cá nhân"
        };
        public List<string> healthcareimg = new List<string>()
        {
            "Assets/Picture/healthcare/1.jpg",
            "Assets/Picture/healthcare/2.jpg",
            "Assets/Picture/healthcare/3.jpg"
        };
        public List<string> grocery = new List<string>()
        {
            "Đồ ăn trong ngày",
            "Thực phẩm khô, đóng hộp",
            "Đồ uống",
            "Đồ ăn vặt",
            "Văn phòng phẩm"
        };
        public List<string> groceryimg = new List<string>()
        {
            "Assets/Picture/grocery/1.jpg",
            "Assets/Picture/grocery/2.jpg",
            "Assets/Picture/grocery/3.jpg",
            "Assets/Picture/grocery/4.png",
            "Assets/Picture/grocery/5.jpg"
        };
        public List<string> trans = new List<string>()
        {
            "Ô tô",
            "Xe máy",
            "Dầu và phụ gia",
            "Đồ bảo hộ",
            "Phụ kiện ô tô xe máy"
        };
        public List<string> transportimg = new List<string>()
        {
            "Assets/Picture/trans/1.jpg",
            "Assets/Picture/trans/2.jpg",
            "Assets/Picture/trans/3.jpg",
            "Assets/Picture/trans/4.jpg",
            "Assets/Picture/trans/5.jpg"
        };
    }
}