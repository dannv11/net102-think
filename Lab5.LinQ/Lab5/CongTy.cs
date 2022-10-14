using System;
using System.Collections.Generic;

namespace Lab5
{
    public class CongTy
    {
        private string _maCongTy;
        private string _tenCongTy;
        private string _diaChi;
        private List<ThongTinLienHe> _lienHes;

        public CongTy()
        {
        }

        public CongTy(string maCongTy, string tenCongTy, string diaChi,List<ThongTinLienHe> lienHes)
        {
            _maCongTy = maCongTy;
            _tenCongTy = tenCongTy;
            _diaChi = diaChi;
            _lienHes = lienHes;
        }

        public string MaCongTy
        {
            get => _maCongTy;
            set => _maCongTy = value;
        }
        public string DiaChi
        {
            get => _diaChi;
            set => _diaChi = value;
        }

        public string TenCongTy
        {
            get => _tenCongTy;
            set => _tenCongTy = value;
        }

        public List<ThongTinLienHe> LienHes
        {
            get => _lienHes;
            set => _lienHes = value;
        }

        public void InRaManHinh()
        {
            Console.WriteLine($"Công ty: {_tenCongTy}, Địa chỉ: {_diaChi}");
            foreach (var thongTinLienHe in _lienHes)
            {
                Console.WriteLine($"{thongTinLienHe.Loai} {thongTinLienHe.ThongTin}");
            }
            Console.WriteLine("");
        }
    }
}