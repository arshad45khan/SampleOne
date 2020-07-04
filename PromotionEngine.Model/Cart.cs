using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class Cart
    {
        public IList<Product> CartProducts { get; set; }
        public bool IsvalidCart { get; set; }
        public decimal TotalCartPrice { get; set; }
        public string ErrorMesaage { get; set; }
    }
}
