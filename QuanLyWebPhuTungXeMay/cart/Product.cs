using System;
using System.Collections.Generic;
using System.Text;


namespace QuanLyWebPhuTungXeMay
{
    class Product
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public int Amount { get; set; }

        public long TongTien => TinhTien();

        public long TinhTien()
        {
            return Amount * Price;
        }

        public override string ToString()
        {
            return $"{Name}\t\t{Amount}\t\t{string.Format("{0:0,0}" ,Price)}vnd\t{string.Format("{0:0,0}", TongTien)}vnd";
        }

        public static void ShowHang()
        {
            var result = Helpper<ProductList>.ReadFile("products.json");
            Console.WriteLine("Tên sản phẩm\tĐơn giá\t\t\tSố lượng");
            foreach (var hang in result.products)
            {
                Console.WriteLine($"{hang.Name}\t\t{string.Format("{0:0,0}", hang.Price)}vnd\t\t{hang.Amount}");
            }
        }

        public static void XemGioHang(List<Product> loaihangs)
        {
            Console.WriteLine("tên sản phẩm \t Số lượng\t Đơn giá \t Tổng tiền 1 sản phẩm");
            foreach(Product hang in loaihangs)
            {
                Console.WriteLine(hang.ToString());
            }
        }
    }
}
