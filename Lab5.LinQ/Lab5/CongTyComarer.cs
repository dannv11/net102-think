using System;
using System.Collections.Generic;

namespace Lab5
{
    public class CongTyComarer :IEqualityComparer<CongTy>
    {
        public bool Equals(CongTy x, CongTy y)
        {
            ////Nếu null hoặc giống nhau, trả true
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            // 1 trong 2 null trả về false
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            //đề bài chỉ yêu cầu kiểm tra trùng công ty và địa chỉ
            //nên ta chỉ kiểm tra 2 trường này, trong các trường hợp
            //khác phải kiểm tra tất cả các properties của class
            return x.TenCongTy == y.TenCongTy
                   && x.DiaChi == y.DiaChi;
        }

        public int GetHashCode(CongTy obj)
        {
            //đề bài chỉ yêu cầu kiểm tra trùng công ty và địa chỉ
            //nên ta chỉ get haskh trường này, trong các trường hợp
            //khác phải hash tất cả các properties của class
            var a = new HashCode();
            a.Add(obj.TenCongTy);
            a.Add(obj.DiaChi);
            return a.ToHashCode();
        }
    }
}