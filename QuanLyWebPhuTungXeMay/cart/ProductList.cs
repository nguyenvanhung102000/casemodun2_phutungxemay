using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyWebPhuTungXeMay
{
    class ProductList
    {
        public List<Product> products { get; set; }
       
        public static void NhapHang(List<Product> loaihangs,Bill hoadon, out long sum)
        {
            var result1 = Helpper<ProductList>.ReadFile("products.json");
            string choice = " ";
            string name;
            do
            {
                bool check = false;
                bool check1 = false;
                Console.Write("Nhập tên sản phẩm: ");
                name = Console.ReadLine();
                foreach (Product item in result1.products)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        check = true;
                    }
                }
                if (check == true)
                {
                    foreach (Product product in loaihangs)
                    {
                        if (product.Name.ToLower() == name.ToLower())
                        {
                            check1 = true;
                        }
                    }
                    Console.Write("Nhập số lượng muốn mua: ");
                    int sl = int.Parse(Console.ReadLine());
                    foreach (var item in result1.products)
                    {
                        if (item.Name.ToLower() == name.ToLower())
                        {
                            if (item.Amount < sl)
                            {
                                Console.WriteLine("Số lượng hiện có không đủ! ");
                            }
                            else
                            {
                                if (check1)
                                {
                                    foreach (Product items in loaihangs)
                                    {
                                        if (items.Name.ToLower() == name.ToLower())
                                        {
                                            items.Amount += sl;
                                        }
                                    }
                                }
                                else
                                {
                                    loaihangs.Add(new Product()
                                    {
                                        Name = item.Name,
                                        Amount = sl,
                                        Price = item.Price
                                    });
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sản phảm không tồn tại! ");
                }
                Console.WriteLine("Bạn có muốn tiếp tục mua hàng? ");
                Console.WriteLine("Bấm c nếu tiếp tục mua hàng.");
                Console.WriteLine("Bấm k nêu không muốn tiếp tục mua hàng.");
                choice = Console.ReadLine();
            }
            while (choice != "k");
            sum = 0;
            foreach(Product sanpham in loaihangs)
            {
                sum += sanpham.TongTien;
            }
            hoadon.bill = loaihangs;
            hoadon.TotalAmount = sum;
        }
        public static void ChinhSuaGioHang(List<Product> loaihangs)
        {
            Product.XemGioHang(loaihangs);
            Console.Write("Nhập món hàng bạn muốn chỉnh sửa: ");
            string name = Console.ReadLine();
            bool check = false;
            foreach(Product hang in loaihangs)
            {
                if(hang.Name.ToLower() == name.ToLower())
                {
                    Console.Write("Nhập số lượng bạn muốn thay đổi: ");
                    int sl = int.Parse(Console.ReadLine());
                    check = true;
                    if(sl == 0)
                    {
                        loaihangs.Remove(hang);
                        Console.WriteLine("Sản phẩm đã được xóa khỏi giỏ hàng.");
                        break;
                    }
                    else
                    {
                        hang.Amount = sl;
                    }
                }
            }
            if(check == false)
            {
                Console.WriteLine("Sản phẩm không có trong giỏ hàng vui lòng kiểm tra lại! ");
            }
            Product.XemGioHang(loaihangs);
        }
    }
}
