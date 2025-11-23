using DACs.Models;
using DACs.Enums;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DACs.Services
{
    public class LogService
    {
        public void WriteLog(int? userId, LogAction action, string message)
        {
            string query = @"
                INSERT INTO Log_He_Thong (MaNhanVien, HanhDong, NoiDung)
                VALUES (@uid, @action, @msg)
            ";

            SqlParameter[] pr =
            {
                new SqlParameter("@uid", (object)userId ?? DBNull.Value),
                new SqlParameter("@action", action.ToString()),
                new SqlParameter("@msg", message)
            };

            DbUtils.ExecuteNonQuery(query, pr);
        }

        public List<LogHeThong> GetLogs(int? limit = null)
        {
            string query = @"
                SELECT TOP (@limit) *
                FROM Log_He_Thong
                ORDER BY ThoiGian DESC
            ";

            if (limit == null)
            {
                query = "SELECT * FROM Log_He_Thong ORDER BY ThoiGian DESC";
            }

            SqlParameter[] pr =
            {
                new SqlParameter("@limit", limit ?? 0)
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, pr);

            List<LogHeThong> list = new List<LogHeThong>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new LogHeThong
                {
                    MaLog = Convert.ToInt32(row["MaLog"]),
                    MaNhanVien = row["MaNhanVien"] == DBNull.Value ? -1 : Convert.ToInt32(row["MaNhanVien"]),
                    ThoiGian = Convert.ToDateTime(row["ThoiGian"]),
                    HanhDong = row["HanhDong"].ToString(),
                    NoiDung = row["NoiDung"].ToString()
                });
            }

            return list;
        }

    }
}
