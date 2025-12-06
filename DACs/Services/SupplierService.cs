using DACs.Models;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Services
{
    internal class SupplierService
    {
        public List<NhaCungCap> GetAllSuppliers()
        {
            string query = @"
                select * from Nha_Cung_Cap
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);
            List<NhaCungCap> suppliers = new List<NhaCungCap>();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có nhà cung cấp nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            foreach (DataRow row in dt.Rows)
            {
                suppliers.Add(new NhaCungCap
                {
                    MaNhaCungCap = int.Parse(row["MaNhaCungCap"].ToString()),
                    Ten = row["Ten"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return suppliers;
        }

        public bool IsSupplierExists(string ten, string email)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Nha_Cung_Cap 
                WHERE Ten = @Ten OR Email = @Email
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Ten", ten),
        new SqlParameter("@Email", email)
            };

            object result = DbUtils.ExecuteScalar(query, parameters);

            int count = 0;
            if (result != null && int.TryParse(result.ToString(), out count))
            {
                return count > 0;
            }

            return false;
        }


        public bool AddSupplier(NhaCungCap supplier)
        {
            if (IsSupplierExists(supplier.Ten, supplier.Email))
            {
                MessageBox.Show("Nhà cung cấp với tên hoặc email đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string query = @"
                INSERT INTO Nha_Cung_Cap (Ten, Email)
                VALUES (@Ten, @Email);
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Ten", supplier.Ten),
                new SqlParameter("@Email", supplier.Email)
            };

            int rows = DbUtils.ExecuteNonQuery(query, parameters);

            return rows > 0;
        }



    }
}
