using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Services
{
    internal class ProductService
    {
        public ProductService() { }
        public DataTable getAllProducts() {
            DataTable products = 
                DbUtils.ExecuteSelectQuery(
                    "SELECT " +
                    "p.[TenSanPham]\r\n " +
                    ",p.[MaSanPham]\r\n " +
                    ", pp.[MauSac]\r\n      " +
                    ",pp.[KichCo]\r\n" +
                    " ,pp.[SoLuong]\r\n" +
                    " ,p.[MaNCC]\r\n" +
                    " ,p.[GiamGia]\r\n  " +
                    ",p.[NgayTao]\r\n  " +
                    ",pp.[DonGia]\r\n    " +
                    ",pp.[TrangThaiBienThe]\r\n" +
                    "FROM [YODY_LTAT_DB].[dbo].[SAN_PHAM] as p\r\n" +
                    "left join [YODY_LTAT_DB].[dbo].[BIEN_THE_SAN_PHAM] as pp " +
                    "on pp.MaSanPham = p.MaSanPham", null);
            
            return products;
        }
    }
}
