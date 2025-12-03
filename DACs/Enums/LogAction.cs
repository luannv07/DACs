using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Enums
{
    public enum LogAction
    {
        Login,

        CreateSupplier,

        CreateOrder,
        DeleteOrder,

        CreateProduct,
        UpdateProduct,
        DeleteProduct,

        ImportStock,

        CreateCustomer,
        UpdateCustomer,

        UpdateUser,
        CreateUser,
        DeleteUser,

        DeleteGRN,

        ExportCSV
    }
}

