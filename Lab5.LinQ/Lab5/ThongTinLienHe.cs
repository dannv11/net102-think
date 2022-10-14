using System;

namespace Lab5
{
    public class ThongTinLienHe
    {
        private string _loai;
        private string _thongTin;

        public ThongTinLienHe()
        {
        }

        public ThongTinLienHe(string loai, string thongTin)
        {
            _loai = loai;
            _thongTin = thongTin;
        }

        public string Loai
        {
            get => _loai;
            set => _loai = value;
        }

        public string ThongTin
        {
            get => _thongTin;
            set => _thongTin = value;
        }
        public void InRaManHinh()
        {
            Console.WriteLine("");
        }
    }
}