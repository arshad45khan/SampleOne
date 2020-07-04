using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class Promotions
    {
        public int PromotionID { get; set; }
        public string PromotionTypeName { get; set; }
        public string PromotionTypeDescription { get; set; }
        public DateTime PromotionStartTime { get; set; }
        public DateTime PromotionEndTime { get; set; }
        public List<Product> Products { get; set; }
        public PromotionType PromotionType { get; set; }
        public int? QuantityForQuantityPromo { get; set; }
        public int? ProductCountForCombinationPromo { get; set; }
        public decimal? FlatPercentagePromo { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
