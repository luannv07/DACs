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
    }
}
