using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyWebPhuTungXeMay
{
    class User
    {
        private string username;
        private string matKhau;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public static bool Checkusername(string name)
        {
            return Regex.IsMatch(name, "^[a-zA-Z0-9_]{6,16}$");
        }
        public static bool CheckPassword(string mk)
        {
            return Regex.IsMatch(mk, @"((?=.*\d)(?=.*[a-z]).*[A-Z])(?=.*[!@#$%^&]).{6,20}");
        }
        public static void DangKy(List<User> user)
        {
            Console.WriteLine("Hãy điền thông tin đăng ký!");
            Console.Write("Tên đăng nhập: ");
            string name = Console.ReadLine();
            while (Checkusername(name) == false)
            {
                Console.WriteLine("Tên đăng nhập không hợp lệ. vui lòng nhập tên khác! ");
                Console.WriteLine("Tên đăng nhập không được dùng ký tự đặc biệt và khoảng trắng! ");
                Console.Write("Tên đăng nhập: ");
                name = Console.ReadLine();
            }
            while (IsNameExist(user, name))
            {
                Console.WriteLine("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác! ");
                Console.Write("Tên đăng nhập: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Hãy nhập mật khẩu trên 6 ký tự.Bao gồm chữ hoa, thường, số và ký tự đặc biệt");
            Console.Write("Mat khau: ");
            string matkhau = Console.ReadLine();
            while (CheckPassword(matkhau) == false)
            {
                Console.WriteLine("Mật khẩu chưa hợp lệ. Vui lòng nhập lại mật khẩu");
                Console.WriteLine("Hãy nhập mật khẩu trên 6 ký tự.Bao gồm chữ hoa, thường, số và ký tự đặc biệt");
                Console.Write("Mật khẩu: ");
                matkhau = Console.ReadLine();
            }
            Console.Write("Nhập lại mật khẩu: ");
            string reMatkhau = Console.ReadLine();
            while (matkhau != reMatkhau)
            {
                Console.WriteLine("Mật khẩu không trùng khớp!");
                Console.Write("Vui lòng nhập lại mật khẩu: ");
                reMatkhau = Console.ReadLine();
            }
            User user1 = new User();
            user1.MatKhau = matkhau;
            user1.UserName = name;
            user.Add(user1);
            Helpper<User>.WriteFile("user.json", user);
        }
        public static bool IsNameExist(List<User> user, string name)
        {
            foreach (var item in user)
            {
                if (item.username.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsMkExist(List<User> user, string matkhau)
        {
            foreach (var item in user)
            {
                if (item.matKhau.Contains(matkhau))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsExistvalue(List<User> user)
        {
            foreach (var item in user)
            {
                if (item != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool DangNhap(List<User> user)
        {
            bool IsDangnhap = false;
            bool check = false;
            if (IsExistvalue(user))
            {
                do
                {
                    Console.Write("Nhập tên đăng nhập:");
                    string name = Console.ReadLine();
                    Console.Write("Nhập mật khẩu:");
                    string mk = Console.ReadLine();
                    bool isNameExist = IsNameExist(user, name);
                    bool isMkExist = IsMkExist(user, mk);
                    if (isNameExist)
                    {
                        if (isMkExist)
                        {
                            Console.WriteLine("Đăng nhập thành công");
                            IsDangnhap = true;
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Sai mật khẩu!! Vui lòng đăng nhập lại:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tên đăng nhập không tồn tại!! Vui lòng đăng nhập lại");
                    }
                }
                while (check == false);
            }
            else
            {
                Console.WriteLine("Chua co thanh vien!!!");
            }
            return IsDangnhap;
        }
    }
}
