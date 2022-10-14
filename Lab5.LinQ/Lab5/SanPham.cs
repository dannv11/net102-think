using System;

namespace Lab5
{
    public class SanPham
    {
        private string _maSanPham;
        private string _tenSanPham;
        private string _mauSac;
        private int _soLuong;
        private float _giaBan;

        public SanPham()
        {
        }

        public SanPham(string maSanPham, string tenSanPham, string mauSac, int soLuong, float giaBan)
        {
            _maSanPham = maSanPham;
            _tenSanPham = tenSanPham;
            _mauSac = mauSac;
            _soLuong = soLuong;
            _giaBan = giaBan;
        }

        public string MaSanPham
        {
            get => _maSanPham;
            set => _maSanPham = value;
        }

        public string TenSanPham
        {
            get => _tenSanPham;
            set => _tenSanPham = value;
        }

        public string MauSac
        {
            get => _mauSac;
            set => _mauSac = value;
        }

        public int SoLuong
        {
            get => _soLuong;
            set => _soLuong = value;
        }

        public float GiaBan
        {
            get => _giaBan;
            set => _giaBan = value;
        }
        public void InRaManHinh()
        {
            Console.WriteLine($"{_tenSanPham} {_mauSac} {_giaBan} {_soLuong}");
            Console.WriteLine("");
        }
    }
}