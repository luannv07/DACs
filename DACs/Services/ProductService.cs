using DACs.Models;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DACs.Services
{
    internal class ProductService
    {
        // Trả về danh sách "flat", mỗi dòng là 1 sản phẩm + 1 biến thể
        public List<SanPham> GetAllProducts()
        {
            string query = @"
                select pd.mabienthe, p.masanpham, p.tensanpham,
                pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
                pd.trangthaibienthe, p.ngaytao, p.mancc from san_pham as p
                left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
                where pd.xoabienthe = 0
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            List<SanPham> products = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                products.Add(MapProductWithVariant(row));
            }

            return products;
        }

        public List<SanPham> FindByName(string name)
        {
            string query = @"
                select pd.mabienthe, p.masanpham, p.tensanpham,
                pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
                pd.trangthaibienthe, p.ngaytao, p.mancc from san_pham as p
                left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
                where pd.xoabienthe = 0 and p.TenSanPham like @name  
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@name", "%" + name + "%")
            });
            List<SanPham> products = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                products.Add(MapProductWithVariant(row));
            }

            return products;
        }
        public SanPham GetProductByPDId(int id)
        {
            string query = @"
            select pd.mabienthe, p.masanpham, p.tensanpham, p.mancc,
            pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
            pd.trangthaibienthe, p.ngaytao from san_pham as p
            left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
            where pd.xoabienthe = 0 and pd.mabienthe = @mabienthe
            ";
            SqlParameter[] paramaters = {
                new SqlParameter("@MaBienThe", id)
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, paramaters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy biến thể sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            SanPham sanpham = MapProductWithVariant(dt.Rows[0]);

            return sanpham;

        }
        private SanPham MapProductWithVariant(DataRow row)
        {
            var sp = new SanPham
            {
                MaSanPham = row["MaSanPham"] != DBNull.Value ? Convert.ToInt32(row["MaSanPham"]) : 0,
                TenSanPham = row["TenSanPham"].ToString(),
                MaNCC = row["MaNCC"] != DBNull.Value ? Convert.ToInt32(row["MaNCC"]) : 0,
                NgayTao = row["NgayTao"] != DBNull.Value ? Convert.ToDateTime(row["NgayTao"]) : DateTime.MinValue,
                BienThes = new List<BienTheSanPham>()
            };

            if (row["MaBienThe"] != DBNull.Value)
            {
                sp.BienThes.Add(new BienTheSanPham
                {
                    MaBienThe = Convert.ToInt32(row["MaBienThe"]),
                    MaSanPham = sp.MaSanPham,
                    MauSac = row["MauSac"]?.ToString(),
                    GiamGia = row["GiamGia"] != DBNull.Value ? Convert.ToDecimal(row["GiamGia"]) : 0,
                    KichCo = row["KichCo"]?.ToString(),
                    SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                    DonGia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0,
                    TrangThaiBienThe = row["TrangThaiBienThe"] != DBNull.Value ? Convert.ToByte(row["TrangThaiBienThe"]) : (byte)0
                });
            }

            return sp;
        }

        public List<string> GetAllSizes()
        {

            var sizes = new List<string>();
            string query = "SELECT DISTINCT KichCo FROM Bien_The_San_Pham ORDER BY KichCo";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                string size = row["KichCo"].ToString();
                if (!string.IsNullOrWhiteSpace(size))
                    sizes.Add(size);
            }

            return sizes;
        }

        public List<string> GetAllColors()
        {
            var colors = new List<string>();
            string query = "SELECT DISTINCT MauSac FROM Bien_The_San_Pham ORDER BY MauSac";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                string color = row["MauSac"].ToString();
                if (!string.IsNullOrWhiteSpace(color))
                    colors.Add(color);
            }

            return colors;
        }

        public List<NhaCungCap> GetAllSuppliers()
        {
            var suppliers = new List<NhaCungCap>();
            string query = "SELECT MaNhaCungCap, Ten FROM Nha_Cung_Cap ORDER BY Ten";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                suppliers.Add(new NhaCungCap
                {
                    MaNhaCungCap = Convert.ToInt32(row["MaNhaCungCap"]),
                    Ten = row["Ten"].ToString()
                });
            }

            return suppliers;
        }

        public bool DeleteProductVariant(int maBt)
        {
            string query = @"
            update Bien_the_san_pham
            set xoabienthe = 1 
            where mabienthe = @MaBienThe
            ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaBienThe", maBt)
            };

            int rowsAffected = -1;
            try
            {
                rowsAffected = DbUtils.ExecuteNonQuery(query, parameters);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi trong quá trình xoá sản phẩm: " + e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected > 0;
        }
        public bool UpdateProductVariant(int maBt, string tenSp, byte trangthai, decimal dongia, decimal giamgia)
        {
            int rowsAffected = 0;

            //MessageBox.Show($"maBt={maBt}, tenSp={tenSp}, trangthai={trangthai}, dongia={dongia}, giamgia={giamgia}");


            string querySanPham = @"
                UPDATE s
                SET 
                    s.TenSanPham = @TenSanPham
                FROM SAN_PHAM s
                JOIN BIEN_THE_SAN_PHAM b ON s.MaSanPham = b.MaSanPham
                WHERE b.MaBienThe = @MaBt;
            ";

            string queryBienThe = @"
                UPDATE BIEN_THE_SAN_PHAM
                SET 
                    TrangThaiBienThe = @TrangThai,
                    DonGia = @DonGia,
                    GiamGia = @GiamGia
                WHERE MaBienThe = @MaBt;
            ";

            SqlParameter[] parametersSanPham = new SqlParameter[]
            {
                new SqlParameter("@MaBt", maBt),
                new SqlParameter("@TenSanPham", tenSp)
            };

            SqlParameter[] parametersBienThe = new SqlParameter[]
            {
                new SqlParameter("@MaBt", maBt),
                new SqlParameter("@TrangThai", trangthai),
                new SqlParameter("@DonGia", dongia),
                new SqlParameter("@GiamGia", giamgia)
            };

            try
            {
                rowsAffected += DbUtils.ExecuteNonQuery(querySanPham, parametersSanPham);
                rowsAffected += DbUtils.ExecuteNonQuery(queryBienThe, parametersBienThe);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi trong quá trình sửa sản phẩm: " + e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rowsAffected > 0;
        }

        public bool AddNewProductWithVariant(SanPham sanPham, BienTheSanPham bienThe)
        {
            // 1. Thêm sản phẩm và lấy ID
            string insertSanPham = @"
                INSERT INTO San_Pham (TenSanPham, MaNCC, NgayTao)
                VALUES (@TenSanPham, @MaNCC, @NgayTao);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametersSanPham = new SqlParameter[]
            {
                new SqlParameter("@TenSanPham", sanPham.TenSanPham),
                new SqlParameter("@MaNCC", sanPham.MaNCC),
                new SqlParameter("@NgayTao", DateTime.Now)
            };

            object result = DbUtils.ExecuteScalar(insertSanPham, parametersSanPham);
            if (result == null)
                return false;

            int newProductId = Convert.ToInt32(result);

            // 2. Thêm biến thể
            string insertBienThe = @"
                INSERT INTO Bien_The_San_Pham 
                    (MaSanPham, MauSac, KichCo, SoLuong, DonGia, GiamGia, TrangThaiBienThe)
                VALUES
                    (@MaSanPham, @MauSac, @KichCo, @SoLuong, @DonGia, @GiamGia, @TrangThaiBienThe);";

            SqlParameter[] parametersBienThe = new SqlParameter[]
            {
                new SqlParameter("@MaSanPham", newProductId),
                new SqlParameter("@MauSac", bienThe.MauSac),
                new SqlParameter("@KichCo", bienThe.KichCo),
                new SqlParameter("@SoLuong", bienThe.SoLuong),
                new SqlParameter("@DonGia", bienThe.DonGia),
                new SqlParameter("@GiamGia", bienThe.GiamGia),
                new SqlParameter("@TrangThaiBienThe", bienThe.TrangThaiBienThe)
            };

            int rows = DbUtils.ExecuteNonQuery(insertBienThe, parametersBienThe);

            return rows > 0;
        }


    }
}
