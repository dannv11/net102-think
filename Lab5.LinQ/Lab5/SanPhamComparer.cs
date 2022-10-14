using System.Collections.Generic;

namespace Lab5
{
    public class SanPhamComparer:IEqualityComparer<SanPham>
    {
        public bool Equals(SanPham x, SanPham y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x.TenSanPham == y.TenSanPham
                   && x.MauSac == y.MauSac
                   && x.GiaBan == y.GiaBan;
        }

        public int GetHashCode(SanPham obj)
        {
            var h1 = obj.TenSanPham.GetHashCode();
            var h2 = obj.MauSac.GetHashCode();
            var h3 = obj.GiaBan.GetHashCode();
            return h1 ^ h2 ^ h3;
        }
    }
}