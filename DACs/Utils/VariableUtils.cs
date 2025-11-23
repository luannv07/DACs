using DACs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Utils
{
    internal class VariableUtils
    {
        public static int currentPN = 1;
        public const int maxPN = 10;
        public static List<ProductCombination> SelectedCombinations = new List<ProductCombination>();
        public static Dictionary<int, string> filterProductSearch = new Dictionary<int, string>
        {
            { 0, "Không sắp xếp" },
            { 1, "Giá tăng dần" },
            { 2, "Giá giảm dần" },
            { 3, "Tồn kho cao -> thấp" },
            { 4, "Tồn kho thấp -> cao" }
        };
        public const int VIP_PERCENTAGE = 5;
        public const int MAX_LOGS_COUNT = 8;
    }
}
