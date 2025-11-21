using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class ProductCombination
    {
        public int ProductId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public ProductCombination(int productId, string color, string size)
        {
            ProductId = productId;
            Color = color;
            Size = size;
        }
    }
}
