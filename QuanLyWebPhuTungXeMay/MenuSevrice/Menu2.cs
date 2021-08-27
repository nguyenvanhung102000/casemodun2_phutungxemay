using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyWebPhuTungXeMay
{
    class Menu2
    {       
        const int min = 1, max = 5;
        const int Thoat = 5;
        public static void Buildmenu2(out int option)
        {
            do
            {

                Console.WriteLine("-----------Menu-----------");
                Console.WriteLine("1. Thêm hàng vào giỏ");
                Console.WriteLine("2. Xem giỏ hàng");
                Console.WriteLine("3. Chỉnh sửa giỏ hàng");
                Console.WriteLine("4. Đặt hàng");               
                Console.WriteLine("5. Thoát");
                Console.Write($"Please choice a number ({min},{max}):");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    option = 0;
                }
            }
            while (option < min || option > max);
        }
        public static void Process2()
        {
            List<Product> sanpham = new List<Product>();
            Bill hoadon = new Bill();
            var productList = Helpper<ProductList>.ReadFile("products.json");
            var selected = 0;
            long total = 0;
            do
            {
                Buildmenu2(out selected);
                Console.Clear();
                switch (selected)
                {
                    case 1:
                        {
                            Product.ShowHang();
                            ProductList.NhapHang(sanpham, hoadon, out long sum);
                            total = sum;
                            break;
                        }
                    case 2:
                        {
                            Product.XemGioHang(sanpham);
                            break;
                        }
                    case 3:
                        {
                            ProductList.ChinhSuaGioHang(sanpham);
                            break;
                        }
                    case 4:
                        {
                            Helpper<Bill>.WriteFile("bill.json", hoadon);
                            Console.WriteLine("Đặt hàng thành công!");
                            break;
                        }                 
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            while (selected != Thoat);
        }
    }
}
