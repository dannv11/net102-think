using System;

namespace Lab5
{
    public class CungUng
    {
        private string _maCongTy;
        private string _maSanPham;
        private int _soLuongCungUng;
        private DateTime _ngayCungUng;

        public CungUng()
        {
        }

        public CungUng(string maCongTy, string maSanPham, int soLuongCungUng, DateTime ngayCungUng)
        {
            _maCongTy = maCongTy;
            _maSanPham = maSanPham;
            _soLuongCungUng = soLuongCungUng;
            _ngayCungUng = ngayCungUng;
        }

        public string MaCongTy
        {
            get => _maCongTy;
            set => _maCongTy = value;
        }

        public string MaSanPham
        {
            get => _maSanPham;
            set => _maSanPham = value;
        }

        public int SoLuongCungUng
        {
            get => _soLuongCungUng;
            set => _soLuongCungUng = value;
        }

        public DateTime NgayCungUng
        {
            get => _ngayCungUng;
            set => _ngayCungUng = value;
        }
        public void InRaManHinh()
        {
            Console.WriteLine("");
        }
    }
}