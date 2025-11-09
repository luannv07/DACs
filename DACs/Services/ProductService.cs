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
                SELECT 
                    p.MaSanPham, p.TenSanPham, p.MaNCC, p.GiamGia, p.NgayTao,
                    pp.MaBienThe, pp.MauSac, pp.KichCo, pp.SoLuong, pp.DonGia, pp.TrangThaiBienThe
                FROM SAN_PHAM p
                LEFT JOIN BIEN_THE_SAN_PHAM pp ON p.MaSanPham = pp.MaSanPham
                where pp.xoabienthe=0                
                ORDER BY p.MaSanPham ";

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
                SELECT 
                    p.MaSanPham, p.TenSanPham, p.MaNCC, p.GiamGia, p.NgayTao,
                    pp.MaBienThe, pp.MauSac, pp.KichCo, pp.SoLuong, pp.DonGia, pp.TrangThaiBienThe
                FROM SAN_PHAM p
                LEFT JOIN BIEN_THE_SAN_PHAM pp ON p.MaSanPham = pp.MaSanPham
                where pp.xoabienthe=0 and p.TenSanPham LIKE @name        
                ORDER BY p.MaSanPham ";

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

        // Mapper mỗi dòng -> SanPham + biến thể
        private SanPham MapProductWithVariant(DataRow row)
        {
            var sp = new SanPham
            {
                MaSanPham = row["MaSanPham"] != DBNull.Value ? Convert.ToInt32(row["MaSanPham"]) : 0,
                TenSanPham = row["TenSanPham"]?.ToString(),
                MaNCC = row["MaNCC"] != DBNull.Value ? Convert.ToInt32(row["MaNCC"]) : 0,
                GiamGia = row["GiamGia"] != DBNull.Value ? Convert.ToDecimal(row["GiamGia"]) : 0,
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
                    KichCo = row["KichCo"]?.ToString(),
                    SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                    DonGia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0,
                    TrangThaiBienThe = row["TrangThaiBienThe"] != DBNull.Value ? Convert.ToByte(row["TrangThaiBienThe"]) : (byte)0
                });
            }

            return sp;
        }

        // Các phương thức CRUD khác giữ nguyên
        public int AddProduct(SanPham sp)
        {
            string query = @"
                INSERT INTO SAN_PHAM (TenSanPham, MaNCC, GiamGia, NgayTao)
                VALUES (@TenSanPham, @MaNCC, @GiamGia, @NgayTao)";

            SqlParameter[] param = {
                new SqlParameter("@TenSanPham", sp.TenSanPham),
                new SqlParameter("@MaNCC", sp.MaNCC),
                new SqlParameter("@GiamGia", sp.GiamGia),
                new SqlParameter("@NgayTao", sp.NgayTao)
            };

            return DbUtils.ExecuteNonQuery(query, param);
        }

        public int UpdateProduct(SanPham sp)
        {
            

            string query = @"
                UPDATE san_pham
                SET GiamGia = @GiamGia
                WHERE MaSanPham = @MaSanPham
                ";

            SqlParameter[] param = {
                new SqlParameter("@GiamGia", sp.GiamGia),
                new SqlParameter("@MaSanPham", sp.MaSanPham)
            };

            int rowAffected = DbUtils.ExecuteNonQuery(query, param);

            if (rowAffected == 0)
                MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string queryVariant = @"
                UPDATE BIEN_THE_SAN_PHAM
                SET DonGia = @DonGia, TrangThaiBienThe = @TrangThaiBienThe
                WHERE MaBienThe = @MaBienThe
                ";
            SqlParameter[] parameters = {
                new SqlParameter("@DonGia", sp.BienThes[0].DonGia),
                new SqlParameter("@TrangThaiBienThe", sp.BienThes[0].TrangThaiBienThe),
                new SqlParameter("@MaBienThe", sp.BienThes[0].MaBienThe)
            };
            return DbUtils.ExecuteNonQuery(queryVariant, parameters);
        }

        public int DeleteProduct(int maBienThe)
        {
            string query = @"
        UPDATE BIEN_THE_SAN_PHAM
        SET xoaBienThe = 1
        WHERE maBienThe = @maBienThe";

            SqlParameter[] param = {
                new SqlParameter("@maBienThe", maBienThe),
            };

            int affected = DbUtils.ExecuteNonQuery(query, param);

            if (affected == 0)
                MessageBox.Show("Không tìm thấy biến thể sản phẩm để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return affected;
        }

        public SanPham GetProductById(int maSanPham)
        {
            string query = @"
                SELECT 
                    p.MaSanPham, p.TenSanPham, p.MaNCC, p.GiamGia, p.NgayTao,
                    pp.MaBienThe, pp.MauSac, pp.KichCo, pp.SoLuong, pp.DonGia, pp.TrangThaiBienThe
                FROM SAN_PHAM p
                LEFT JOIN BIEN_THE_SAN_PHAM pp ON p.MaSanPham = pp.MaSanPham
                WHERE p.MaSanPham = @MaSanPham and pp.xoabienthe=0";

            SqlParameter[] param = { new SqlParameter("@MaSanPham", maSanPham) };
            DataTable dt = DbUtils.ExecuteSelectQuery(query, param);

            if (dt.Rows.Count == 0) return null;

            var sp = new SanPham
            {
                MaSanPham = Convert.ToInt32(dt.Rows[0]["MaSanPham"]),
                TenSanPham = dt.Rows[0]["TenSanPham"]?.ToString(),
                MaNCC = dt.Rows[0]["MaNCC"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["MaNCC"]) : 0,
                GiamGia = dt.Rows[0]["GiamGia"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["GiamGia"]) : 0,
                NgayTao = dt.Rows[0]["NgayTao"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["NgayTao"]) : DateTime.MinValue,
                BienThes = new List<BienTheSanPham>()
            };

            foreach (DataRow row in dt.Rows)
            {
                if (row["MaBienThe"] != DBNull.Value)
                {
                    sp.BienThes.Add(new BienTheSanPham
                    {
                        MaBienThe = Convert.ToInt32(row["MaBienThe"]),
                        MaSanPham = sp.MaSanPham,
                        MauSac = row["MauSac"]?.ToString(),
                        KichCo = row["KichCo"]?.ToString(),
                        SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                        DonGia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : 0,
                        TrangThaiBienThe = row["TrangThaiBienThe"] != DBNull.Value ? Convert.ToByte(row["TrangThaiBienThe"]) : (byte)0
                    });
                }
            }

            return sp;
        }

        public List<string> GetAllSizes()
        {

            var sizes = new List<string>();
            string query = "SELECT DISTINCT KichCo FROM Bien_The_San_Pham ORDER BY KichCo";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            foreach (DataRow row in dt.Rows)
                sizes.Add(row["KichCo"].ToString());

            return sizes;
        }

        public List<string> GetAllColors()
        {
            var colors = new List<string>();
            string query = "SELECT DISTINCT MauSac FROM Bien_The_San_Pham ORDER BY MauSac";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            foreach (DataRow row in dt.Rows)
                colors.Add(row["MauSac"].ToString());

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
    }
}
