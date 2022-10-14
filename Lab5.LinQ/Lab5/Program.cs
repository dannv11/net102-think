using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var svc = new Services();
            while (true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("My App");
                Console.WriteLine("1. Hiển thị danh sách công ty");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Hiển thị danh sách cung ứng");
                Console.WriteLine("4. Thêm công ty");
                Console.WriteLine("5. Thêm Sản Phẩm");
                Console.WriteLine("6. Thêm Cung Ứng");
                Console.WriteLine("7. Lấy danh sách thông tin liên hệ");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Vui lòng chọn chức năng");
                Console.WriteLine("");
                var key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                    {
                        foreach (var x in svc.GetCongTy())
                        {
                            x.InRaManHinh();
                        }
                        break;
                    }
                    case "2":
                    {
                        foreach (var x in svc.GetSanPham())
                        {
                            x.InRaManHinh();
                        }
                        break;
                    }
                    case "3":
                    {
                        var tenCongTy = GetInPut("Nhập tên công ty: ");
                        var ngayCungUngStr = GetInPut("Nhập ngày cung cấp: ");
                        var ngayCungUng = DateTime.ParseExact(ngayCungUngStr,
                            "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        svc.GetCungUng(tenCongTy, ngayCungUng);
                        break;
                    }
                    case "4":
                    {
                        var slStr = GetInPut("Nhập số lượng cần thêm: ");
                        int sl = int.Parse(slStr);
                        for (int i = 0; i < sl; i++)
                        {
                            var ma = GetInPut("Mã công ty: ");
                            var ten = GetInPut("Tên công ty: ");
                            var diaChi = GetInPut("Địa chỉ công ty: ");
                            var lienHes = new List<ThongTinLienHe>();
                            while (true)
                            {
                                var loai = GetInPut("Nhập loại thông tin liên hệ, 0 để thôi nhập:");
                                if (loai == "0")
                                {
                                    break;
                                }

                                var lienHe = GetInPut("Nhập thông tin:");
                                lienHes.Add(new ThongTinLienHe(loai,lienHe));
                            }

                            var congTy = new CongTy(ma, ten, diaChi, lienHes);
                            if (svc.AddCongTy(congTy))
                            {
                                Console.WriteLine("Thêm mới công ty thành công!");
                            }
                            else
                            {
                                Console.WriteLine("Thêm mới công ty không thành công!");
                            }
                        }
                        break;
                    }
                    case "5":
                    {
                        var slStr = GetInPut("Nhập số lượng sản phẩm cần thêm: ");
                        int sl = int.Parse(slStr);
                        for (int i = 0; i < sl; i++)
                        {
                            var ma = GetInPut("Mã sản phẩm: ");
                            var ten = GetInPut("Tên sản phẩm: ");
                            var mau = GetInPut("Màu sắc: ");
                            var gia = GetInPut("Giá bán: ");
                            var soluong = GetInPut("Số lượng: ");
                       

                            var sanPham = new SanPham(ma, ten,mau , int.Parse(soluong), float.Parse(gia));
                            if (svc.AddSanPham(sanPham))
                            {
                                Console.WriteLine("Thêm mới sản phẩm thành công!");
                            }
                            else
                            {
                                Console.WriteLine("Thêm mới sản phẩm không thành công!");
                            }
                        }
                        break;
                    }
                    case "6":
                    {
                        var slStr = GetInPut("Nhập số lượng cung ứng cần thêm: ");
                        int sl = int.Parse(slStr);
                        for (int i = 0; i < sl; i++)
                        {
                            var maCt = GetInPut("Mã công ty: ");
                            var maSp = GetInPut("Mã sản phẩm: ");
                            var slCCStr = GetInPut("Số lượng cung cấp: ");
                            var ngayCCStr = GetInPut("Ngày cung cấp: ");

                            var slCC = int.Parse(slCCStr);
                            var ngayCC = DateTime.ParseExact(ngayCCStr, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture);
                       

                            var cungUng = new CungUng(maCt, maSp,slCC , ngayCC);
                            if (svc.AddCungUng(cungUng))
                            {
                                Console.WriteLine("Thêm mới cung ứng thành công!");
                            }
                            else
                            {
                                Console.WriteLine("Thêm mới cung ứng không thành công!");
                            }
                        }
                        break;
                    }
                    case "7":
                    {
                        svc.GetCongTyWithContact();
                    
                        break;
                    }
                    case "0":
                    {
                        Console.WriteLine("Goodbye!");
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("Vui lòng nhập lại!");
                        break;
                    }
                }
            }
        }

        public static string GetInPut(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
