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
            DataTable products = DbUtils.ExecuteSelectQuery('SELECT * FROM SAN_PHAM', null);
        return products;
                }
    }
}
