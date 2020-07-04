using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public static class DataSource
    {
        private static IList<Product> products { get; set; }
        private static IList<Promotions> promotions { get; set; }

        public static IList<Product> GetProducts()
        {
            if (products != null)
                return products;
            products = new List<Product>();

            Product product = new Product
            {
                ProductID = 'A',
                ProductName  = "AAA",
                ProductDescription = "A Product Desc",
                ProductPrice = 50.00M
            };
            products.Add(product);

            product = new Product
            {
                ProductID = 'B',
                ProductName = "BBB",
                ProductDescription = "B Product Desc",
                ProductPrice = 30.00M
            };
            products.Add(product);

            product = new Product
            {
                ProductID = 'C',
                ProductName = "CCC",
                ProductDescription = "C Product Desc",
                ProductPrice = 20.00M
            };
            products.Add(product);

            product = new Product
            {
                ProductID = 'D',
                ProductName = "DDD",
                ProductDescription = "D Product Desc",
                ProductPrice = 15.00M
            };
            products.Add(product);
            return products;
        }

        public static Product GetProductByID(char prodID)
        {
            return GetProducts().Where(w => w.ProductID == prodID).FirstOrDefault();
        }

        public static IList<Product> GetProducts(char prodID)
        {
            return GetProducts().Where(w => w.ProductID == prodID).ToList();
        }

        public static IList<Promotions> GetPromotions()
        {
            if (promotions != null)
                return promotions;

            promotions = new List<Promotions>();

            Promotions promotion = new Promotions {
                PromotionID = 1,
                PromotionTypeName = "Promo1",
                PromotionTypeDescription = "Promo1 DESC",
                PromotionStartTime = DateTime.Now.AddMonths(-5),
                PromotionEndTime = DateTime.Now.AddMonths(2),
                Products = new List<Product>() { GetProductByID('A') },
                PromotionType = PromotionType.QuantityPromo,
                ProductCountForCombinationPromo = null,
                FlatPercentagePromo = null,
                QuantityForQuantityPromo = 3,
                DiscountPrice = 130.00M
            };
            promotions.Add(promotion);

            promotion = new Promotions
            {
                PromotionID = 2,
                PromotionTypeName = "Promo2",
                PromotionTypeDescription = "Promo2 DESC",
                PromotionStartTime = DateTime.Now.AddMonths(-5),
                PromotionEndTime = DateTime.Now.AddMonths(2),
                Products = new List<Product>() { GetProductByID('B') },
                PromotionType = PromotionType.QuantityPromo,
                ProductCountForCombinationPromo = null,
                FlatPercentagePromo = null,
                QuantityForQuantityPromo = 2,
                DiscountPrice = 45.00M
            };
            promotions.Add(promotion);

            promotion = new Promotions
            {
                PromotionID = 3,
                PromotionTypeName = "Promo3",
                PromotionTypeDescription = "Promo3 DESC",
                PromotionStartTime = DateTime.Now.AddMonths(-5),
                PromotionEndTime = DateTime.Now.AddMonths(2),
                Products = new List<Product>() { GetProductByID('C'), GetProductByID('D') },
                PromotionType = PromotionType.CombinationPromo,
                ProductCountForCombinationPromo = 2,
                FlatPercentagePromo = null,
                QuantityForQuantityPromo = null,
                DiscountPrice = 30.00M
            };
            promotions.Add(promotion);

            return promotions;
        }

        public static Cart AddtoCart(IList<Product> products)
        {
            try
            {
                var cart = new Cart
                {
                    CartProducts = products,
                    TotalCartPrice = products.Sum(s=> s.ProductPrice),
                    ErrorMesaage = string.Empty,
                    IsvalidCart = true
                };
                return cart;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
