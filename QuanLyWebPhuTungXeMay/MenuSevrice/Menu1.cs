using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyWebPhuTungXeMay
{
    class Menu1
    {
        const int min = 1;
        const int max = 3;
        const int dangky = 1;
        const int dangnhap = 2;
        const int thoat = 3;
        public static void BiuldMenu(out int option)
        {         
            do
            {
                Console.WriteLine("----------MENU----------");
                Console.WriteLine("1: Đăng ký");
                Console.WriteLine("2: Đăng nhập");
                Console.WriteLine("3: Thoát");
                Console.Write($"Please choice a number ({min},{max}): ");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    option = 0;
                }
            } while (option < min || option > max);
        }
        public static void Process()
        {
            var user = Helpper<List<User>>.ReadFile("user.json");
            var selected = 0;
            do
            {
                BiuldMenu(out selected);
                Console.Clear();
                switch (selected)
                {
                    case dangnhap:
                        {
                            bool check = User.DangNhap(user);
                            if (check)
                            {
                                Menu2.Process2();
                                break;
                            }
                            break;
                        }
                    case dangky:
                        {
                            User.DangKy(user);
                            Menu2.Process2();
                            break;
                        }
                    case thoat:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            } while (selected != thoat);
        }
    }
}
