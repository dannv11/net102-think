using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Lab5
{
    public class Services
    {
        private List<CongTy> _congTy;
        private List<SanPham> _sanPhams;
        private List<CungUng> _cungUngs;

        public Services()
        {
            _congTy = new List<CongTy>()
            {
                new CongTy("ct1","Cong Ty 1","Dia chi 1",new List<ThongTinLienHe>()
                {
                    new ThongTinLienHe("email","info@ct1.com"),
                    new ThongTinLienHe("phone","0123123123"),
                    new ThongTinLienHe("tax","0123123123"),
                }),
                new CongTy("ct2","Cong Ty 2","Dia chi 1",new List<ThongTinLienHe>()
                {
                    new ThongTinLienHe("email","info@ct1.com"),
                    new ThongTinLienHe("phone","0123456789"),
                    new ThongTinLienHe("tax","0123456789"),
                }),
                new CongTy("ct3","Cong Ty 3","Dia chi 1",new List<ThongTinLienHe>()
                {
                    new ThongTinLienHe("email","info@ct1.com"),
                    new ThongTinLienHe("phone","0123456123"),
                    new ThongTinLienHe("website","CongTy3.com"),
                }),
            };
            _sanPhams = new List<SanPham>()
            {
                new SanPham("sp1","San Pham 1","Xanh",    12,12000),
                new SanPham("sp2","San Pham 2","Xanh",2,12000),
                new SanPham("sp3","San Pham 3","Xanh",3,12000),
                new SanPham("sp4","San Pham 4","Xanh",23,12000),
                new SanPham("sp5","San Pham 5","Xanh",23,12000),
            };
            _cungUngs = new List<CungUng>()
            {
                new CungUng("ct1","sp1",123,new DateTime(2022,10,10)),
                new CungUng("ct1","sp2",123,new DateTime(2022,12,10)),
                new CungUng("ct2","sp3",123,new DateTime(2022,3,10)),
                new CungUng("ct2","sp2",123,new DateTime(2022,5,10)),
                new CungUng("ct3","sp1",123,new DateTime(2022,10,10)),
            };
            
        }

        public List<CongTy> GetCongTy()
        {
            return _congTy;
        }
        public List<SanPham> GetSanPham()
        {
            return _sanPhams;
        }
        public List<CungUng> GetCungUng()
        {
            return _cungUngs;
        }

        public void GetCungUng(string tenCongTy, DateTime ngayCungCap)
        {
           // var ct = _congTy.Where(x => x.TenCongTy.Equals(tenCongTy)).FirstOrDefault();
           // var cungUng = _cungUngs.Where(x => x.MaCongTy.Equals(ct.MaCongTy) && x.NgayCungUng.Equals(ngayCungCap));
           // Nếu thực hiện từng truy vấn thì khi thao tác với database có nhiều bản ghi sẽ bị chậm
            //đầu vào tên công ty ở bảng công ty, ngày cung ứng ở bảng cung ứng
            // các thông tin sản phẩm ở bảng sản phẩm
            // => join 3 bảng với nhau theo mã công ty, mã sản phẩm (primary key)

           var rs = from _cu in _cungUngs
               join _sp in _sanPhams on _cu.MaSanPham equals _sp.MaSanPham
               join _ct in _congTy on _cu.MaCongTy equals _ct.MaCongTy
               where _ct.TenCongTy.Equals(tenCongTy) && _cu.NgayCungUng.Equals(ngayCungCap)
               select new // chỉ select ra những trường cần sử dụng
               {
                   TenSanPham = _sp.TenSanPham,
                   MauSac = _sp.MauSac,
                   SoLuong = _cu.SoLuongCungUng,
                   GiaBan = _sp.GiaBan
               };
           if (!rs.Any())
           {
               Console.WriteLine($"Công ty {tenCongTy} khoong cung cap san pham nao vao ngay {ngayCungCap.ToString("dd/MM/yyyy")}");
           }
           foreach (var x in rs)
           {
               Console.WriteLine($"{x.TenSanPham} {x.MauSac} {x.SoLuong} {x.GiaBan}");
           }
        }

        public void GetCongTyWithContact()
        {
            var rs = _congTy.SelectMany(x => x.LienHes,
                (_congTy, _lienHe) =>
                    new
                    {
                        TenCongTy = _congTy.TenCongTy,
                        DiaChi = _congTy.DiaChi,
                        LoaiLienHe = _lienHe.Loai,
                        ThongTin = _lienHe.ThongTin
                    }
            );
            foreach (var x in rs)
            {
                Console.WriteLine($"Công ty: {x.TenCongTy}  , Địa chỉ: {x.DiaChi}");
                Console.WriteLine($"{x.LoaiLienHe}: {x.ThongTin}");
                Console.WriteLine();
            }
        }

        public bool AddCongTy(CongTy congTy)
        {
            // cach 1
            // var isExists = _congTy.Where(x => x.TenCongTy.Equals(congTy.TenCongTy)
            //                                   && x.DiaChi.Equals(congTy.DiaChi)).Any();
            
            // Cach 2
            var isExists = _congTy.Contains(congTy, new CongTyComarer());
            if (isExists)
            {
                return false;
            }
            else
            {
                _congTy.Add(congTy);
                return true;
            }
            
        }
        public bool AddSanPham(SanPham sanPham)
        {
            // cach 1
             // var isExists = _sanPhams.Where(x => x.TenSanPham.Equals(sanPham.TenSanPham)
             //                                 && x.MauSac.Equals(sanPham.MauSac)
             //                                    && x.GiaBan == sanPham.GiaBan).Any();
            
            // Cach 2
            var isExists = _sanPhams.Contains(sanPham, new SanPhamComparer());
            if (isExists)
            {
                return false;
            }
            else
            {
                _sanPhams.Add(sanPham);
                return true;
            }
            
        }
        
        public bool AddCungUng(CungUng cungUng)
        {
            _cungUngs.Add(cungUng);
                return true;
        }
    }
}