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
        public List<SanPham> GetAllProducts(bool needProductID = false)
        {
            string query = @"
                select pd.mabienthe, p.masanpham, p.tensanpham,
                pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
                pd.trangthaibienthe, p.ngaytao, p.mancc from san_pham as p
                inner join bien_the_san_pham as pd on pd.masanpham = p.masanpham
                where pd.xoabienthe = 0
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            List<SanPham> products = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                products.Add(MapProductWithVariant(row, needProductID));
            }

            return products;
        }
        public List<SanPham> getOnlyProductFromSpecSupplier(int ncc)
        {
            string query = @"select distinct pd.mabienthe, p.masanpham, p.tensanpham,
                pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
                pd.trangthaibienthe, p.ngaytao, p.mancc from san_pham as p
                left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
                where pd.xoabienthe = 0 and p.mancc=@ncc";
            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@ncc", ncc)
            });
            List<SanPham> products = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(MapProductWithVariant(row, false));
            }
            return products;
        }
        public List<SanPham> getOnlyProductNameFromSpecSupplier(int ncc)
        {
            string query = @"select distinct s.masanpham, s.tensanpham from san_pham as s
                join bien_the_san_pham as b on b.masanpham=s.masanpham 
                where s.mancc= @ncc and b.xoabienthe=0";
            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@ncc", ncc)
            });
            List<SanPham> products = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(MapProductWithVariant(row, true));
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
                products.Add(MapProductWithVariant(row, false));
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
            SanPham sanpham = MapProductWithVariant(dt.Rows[0], false);

            return sanpham;

        }
        private SanPham MapProductWithVariant(DataRow row, bool needProductId)
        {
            var sp = new SanPham
            {
                MaSanPham = row.Table.Columns.Contains("MaSanPham") && row["MaSanPham"] != DBNull.Value
                    ? Convert.ToInt32(row["MaSanPham"]) : 0,

                TenSanPham = row.Table.Columns.Contains("TenSanPham")
                    ? (needProductId ? row["TenSanPham"]?.ToString() + " (M" + Convert.ToInt32(row["MaSanPham"]) + ")" : row["TenSanPham"]?.ToString()) : string.Empty,

                MaNCC = row.Table.Columns.Contains("MaNCC") && row["MaNCC"] != DBNull.Value
                    ? Convert.ToInt32(row["MaNCC"]) : 0,

                NgayTao = row.Table.Columns.Contains("NgayTao") && row["NgayTao"] != DBNull.Value
                    ? Convert.ToDateTime(row["NgayTao"]) : DateTime.MinValue,

                BienThes = new List<BienTheSanPham>()
            };

            if (row.Table.Columns.Contains("MaBienThe") && row["MaBienThe"] != DBNull.Value)
            {
                sp.BienThes.Add(new BienTheSanPham
                {
                    MaBienThe = Convert.ToInt32(row["MaBienThe"]),
                    MaSanPham = sp.MaSanPham,

                    MauSac = row.Table.Columns.Contains("MauSac")
                        ? row["MauSac"]?.ToString() : null,

                    GiamGia = row.Table.Columns.Contains("GiamGia") && row["GiamGia"] != DBNull.Value
                        ? Convert.ToDecimal(row["GiamGia"]) : 0,

                    KichCo = row.Table.Columns.Contains("KichCo")
                        ? row["KichCo"]?.ToString() : null,

                    SoLuong = row.Table.Columns.Contains("SoLuong") && row["SoLuong"] != DBNull.Value
                        ? Convert.ToInt32(row["SoLuong"]) : 0,

                    DonGia = row.Table.Columns.Contains("DonGia") && row["DonGia"] != DBNull.Value
                        ? Convert.ToDecimal(row["DonGia"]) : 0,

                    TrangThaiBienThe = row.Table.Columns.Contains("TrangThaiBienThe") && row["TrangThaiBienThe"] != DBNull.Value
                        ? Convert.ToByte(row["TrangThaiBienThe"]) : (byte)0
                });
            }

            return sp;
        }

        public List<string> GetAllColorByProductId(int id)
        {
            var colors = new List<string>();
            string query = "select b.mausac from san_pham p\r\nleft join bien_the_san_pham b on b.masanpham = p.masanpham\r\nwhere p.masanpham = @id and b.xoabienthe=0";

            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@id", id)
            });
            foreach (DataRow row in dt.Rows)
            {
                string color = row["MauSac"].ToString();
                if (!string.IsNullOrWhiteSpace(color))
                    colors.Add(color);
            }

            return colors;
        }

        public List<string> GetAllSizeByProductIdAndColor(int id, string color)
        {
            var sizes = new List<string>();
            string query = @"
                SELECT b.KichCo 
                FROM San_Pham p
                LEFT JOIN Bien_The_San_Pham b ON b.MaSanPham = p.MaSanPham
                WHERE p.MaSanPham = @id AND b.MauSac LIKE @color AND b.XoaBienThe = 0
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@color", "%" + color + "%")
            });

            foreach (DataRow row in dt.Rows)
            {
                string size = row["KichCo"].ToString();
                if (!string.IsNullOrWhiteSpace(size))
                    sizes.Add(size);
            }

            return sizes;
        }

        public decimal getPriceByProductIdAndColorAndSize(int id, string color, string size)
        {
            decimal price = 0;
            string query = @"
                select b.dongia from san_pham p
                left join bien_the_san_pham b on b.masanpham = p.masanpham
                where p.masanpham = @id and b.MauSac like @color and b.kichco like @size and b.xoabienthe=0
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@color", "%" + color + "%"),
                new SqlParameter("@size", "%" + size + "%")
            });

            foreach (DataRow row in dt.Rows)
            {
                price = Convert.ToDecimal(row["DonGia"].ToString());
            }

            return price;
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
                return false;
            }

            return rowsAffected > 0;
        }
        public bool UpdateProductVariant(int maBt, string tenSp, byte trangthai, decimal dongia, decimal giamgia, string mausac, string kichco)
        {
            int rowsAffected = 0;

            //MessageBox.Show($"maBt={maBt}, tenSp={tenSp}, trangthai={trangthai}, dongia={dongia}, giamgia={giamgia}");


            string querySanPham = @"
                UPDATE s
                SET 
                    s.TenSanPham = @TenSanPham
                FROM SAN_PHAM s
                JOIN BIEN_THE_SAN_PHAM b ON s.MaSanPham = b.MaSanPham
                WHERE b.MaBienThe = @MaBt and b.xoabienthe = 0;
            ";

            string queryBienThe = @"
                UPDATE BIEN_THE_SAN_PHAM
                SET 
                    TrangThaiBienThe = @TrangThai,
                    DonGia = @DonGia,
                    GiamGia = @GiamGia,
                    mausac = @mausac,
                    kichco = @kichco
                WHERE MaBienThe = @MaBt and xoabienthe = 0;
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
                new SqlParameter("@GiamGia", giamgia),
                new SqlParameter("@mausac", mausac),
                new SqlParameter("@kichco", kichco)
            };

            try
            {
                rowsAffected += DbUtils.ExecuteNonQuery(querySanPham, parametersSanPham);
                rowsAffected += DbUtils.ExecuteNonQuery(queryBienThe, parametersBienThe);
            }
            catch (SqlException ex)
            {
                string message = "Đã xảy ra lỗi không xác định.";

                switch (ex.Number)
                {
                    case 2627: // Violate UNIQUE KEY
                    case 2601: // Duplicate index
                        message = "Dữ liệu bị trùng. Vui lòng kiểm tra lại.";
                        break;

                    case 547: // Foreign key
                        message = "Không thể xóa hoặc cập nhật do dữ liệu đang được sử dụng ở bảng khác.";
                        break;

                    case 515: // Cannot insert NULL
                        message = "Một trường bắt buộc đang bị thiếu dữ liệu.";
                        break;

                    default:
                        message = "Lỗi SQL: " + ex.Message;
                        break;
                }
                MessageBox.Show(message, "Lỗi xử lý dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi trong quá trình sửa sản phẩm: " + e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return rowsAffected > 0;
        }
        public bool AddProductVariantForNewProduct(int productId, BienTheSanPham bienThe)
        {
            string insertBienThe = @"
        INSERT INTO Bien_The_San_Pham 
            (MaSanPham, MauSac, KichCo, SoLuong, DonGia, GiamGia, TrangThaiBienThe)
        VALUES
            (@MaSanPham, @MauSac, @KichCo, @SoLuong, @DonGia, @GiamGia, @TrangThaiBienThe);";

            SqlParameter[] parametersBienThe = new SqlParameter[]
            {
                new SqlParameter("@MaSanPham", productId),
                new SqlParameter("@MauSac", bienThe.MauSac),
                new SqlParameter("@KichCo", bienThe.KichCo),
                new SqlParameter("@SoLuong", bienThe.SoLuong),
                new SqlParameter("@DonGia", bienThe.DonGia),
                new SqlParameter("@GiamGia", bienThe.GiamGia),
                new SqlParameter("@TrangThaiBienThe", bienThe.TrangThaiBienThe)
            };

            try
            {
                return DbUtils.ExecuteNonQuery(insertBienThe, parametersBienThe) > 0;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Biến thể sản phẩm đã tồn tại.",
                        "Lỗi trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Number == 547)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ.\nVui lòng kiểm tra lại.",
                        "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message,
                        "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
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

            // 2. Gọi hàm mới để thêm biến thể
            return AddProductVariantForNewProduct(newProductId, bienThe);
        }


        public BienTheSanPham GetBienTheSanPhamByUniqueFieldsGroup(int masp, string mausac, string kichco)
        {
           string query = @"
                select mabienthe, masanpham, mausac, kichco, soluong, dongia, giamgia, trangthaibienthe 
                from bien_the_san_pham 
                where xoabienthe = 0 and masanpham = @masp and mausac = @mausac and kichco = @kichco
            ";
            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@masp", masp),
                new SqlParameter("@mausac", mausac),
                new SqlParameter("@kichco", kichco)
            });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            BienTheSanPham bienThe = new BienTheSanPham
            {
                MaBienThe = Convert.ToInt32(row["MaBienThe"]),
                MaSanPham = Convert.ToInt32(row["MaSanPham"]),
                MauSac = row["MauSac"].ToString(),
                KichCo = row["KichCo"].ToString(),
                SoLuong = Convert.ToInt32(row["SoLuong"]),
                DonGia = Convert.ToDecimal(row["DonGia"]),
                GiamGia = Convert.ToDecimal(row["GiamGia"]),
                TrangThaiBienThe = Convert.ToByte(row["TrangThaiBienThe"])
            };
            return bienThe;
        }

        public void UpdateProductVariantQuantity(List<ChiTietPhieuNhap> chiTietPhieuNhaps)
        {
            string query = @"
                UPDATE Bien_The_San_Pham
                SET SoLuong = SoLuong + @SoLuongNhap
                WHERE MaBienThe = @MaBienThe AND XoaBienThe = 0";

            foreach (var chiTiet in chiTietPhieuNhaps)
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@SoLuongNhap", chiTiet.SoLuong),
                    new SqlParameter("@MaBienThe", chiTiet.MaBienThe)
                };

                DbUtils.ExecuteNonQuery(query, sqlParameter);
            }
        }


    }
}
