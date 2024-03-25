using DOANWINFORM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace DOANWINFORM.DAL
{
    public class TAIKHOANDAL
    {
        //======= Thêm ========
        public static void AddNewTK(string manv, string macv, string tennv, string account, string matkhau, string diachi, string email, string dienthoai, string chucvu, string gioitinh)
        {
            string hashpass = MaHoa(matkhau);
            QLBHDataContext data = new QLBHDataContext();
            NhanVien nv = new NhanVien();
            nv.MaNV = manv;
            nv.MaCV = macv;
            nv.TenNV = tennv;
            nv.account = account;
            nv.matkhau = hashpass;
            nv.DiaChi = diachi;
            nv.Email = email;
            nv.DienThoai = dienthoai;
            nv.ChucVu = chucvu;
            nv.GioiTinh = gioitinh;
            nv.TrangThai = true;

            data.NhanViens.InsertOnSubmit(nv);
            data.SubmitChanges();
        }
        //====== Mã hóa =======
        public static string MaHoa(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashdata = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashpass = "";
            foreach (byte item in hashdata)
            {
                hashpass += item;
            }
            return hashpass;
        }
        //======= Xóa ========
        public static void DeleteSelectTK(string manv)
        {
            QLBHDataContext data = new QLBHDataContext();
            NhanVien nv = (from nhanvien in data.NhanViens
                           where nhanvien.MaNV == manv.Trim()
                           select nhanvien).SingleOrDefault<NhanVien>();
            nv.TrangThai = false;
            data.SubmitChanges();

        }
        //======= Sửa ========
        public static void EditSelectTK(string manv, string macv, string tennv, string account, string matkhau, string diachi, string email, string dienthoai, string chucvu, string gioitinh)
        {
            string hashpass = MaHoa(matkhau);
            QLBHDataContext data = new QLBHDataContext();
            NhanVien nv = (from nhanvien in data.NhanViens
                           where nhanvien.MaNV == manv.Trim()
                           select nhanvien).SingleOrDefault<NhanVien>();
            nv.MaNV = manv;
            nv.MaCV = macv;
            nv.TenNV = tennv;
            nv.account = account;
            nv.matkhau = hashpass;
            nv.DiaChi = diachi;
            nv.Email = email;
            nv.DienThoai = dienthoai;
            nv.ChucVu = chucvu;
            nv.GioiTinh = gioitinh;
            nv.TrangThai = true;
            data.SubmitChanges();
        }
    }
}
