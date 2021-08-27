using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyWebPhuTungXeMay
{
    class Bill
    {
        public List<Product> bill;
        public long TotalAmount { get; set; }       
        public Bill()
        { 
            bill = new List<Product>();
        }
    }
}
