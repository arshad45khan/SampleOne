using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.BLL
{
    public class PromotionController
    {
        public IList<Product> GetProducts()
        {
            try
            {
                return DataSource.GetProducts();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IList<Promotions> GetPromotions()
        {
            try
            {
                return DataSource.GetPromotions();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsPromoExistsforProduct(char productID)
        {
            try
            {
                return DataSource.GetPromotions().Any(w=> w.Products.Any(a=>a.ProductID == productID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Promotions> GetPromotions(char productID)
        {
            try
            {
                return DataSource.GetPromotions().Where(w => w.Products.Any(a => a.ProductID == productID)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cart AddtoCart(char prodID)
        {
            try
            {
                var prod = DataSource.GetProducts(prodID);
                return DataSource.AddtoCart(prod);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Cart UpdateCart(char prodID, Cart cart)
        {
            try
            {
                var prod = DataSource.GetProducts(prodID).First();
                cart.CartProducts.Add(prod);
                cart.TotalCartPrice = cart.CartProducts.Sum(s => s.ProductPrice);
                return cart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cart GetCart(Cart cart)
        {
            try
            {
                decimal totalPrice = 0.00M;
                bool appliedDiscount = false;
                var uniqueProd = cart.CartProducts.Distinct().ToList();
                foreach(var p in uniqueProd)
                {
                    var product = cart.CartProducts.Where(w => w.ProductID == p.ProductID).FirstOrDefault();
                    var promos = DataSource.GetPromotions().Where(w => w.Products.Any(a => a.ProductID == p.ProductID)).ToList();

                    foreach(var promo in promos)
                    {
                        switch(promo.PromotionType)
                        {
                            case PromotionType.CombinationPromo:
                                {
                                    var anotherProducts = promo.Products.Where(w => w.ProductID != product.ProductID).First();
                                    if(cart.CartProducts.Where(w=> w.ProductID == anotherProducts.ProductID).Count() > 0 && !appliedDiscount)
                                    {
                                        totalPrice += promo.DiscountPrice;
                                        appliedDiscount = true;
                                    }
                                    else
                                    {
                                        if (!appliedDiscount)
                                            totalPrice += p.ProductPrice;
                                        break;
                                    }
                                    break;
                                }
                            case PromotionType.FlatPercentagePromo:
                                {
                                    break;
                                }
                            case PromotionType.QuantityPromo:
                                {
                                    var prodCount = cart.CartProducts.Count(c => c.ProductID == p.ProductID);
                                    if(prodCount >= promo.QuantityForQuantityPromo)
                                    {
                                        int reminder;
                                        var q = Quotient(prodCount, promo.QuantityForQuantityPromo.Value, out reminder);
                                        totalPrice += (promo.DiscountPrice * q) + (p.ProductPrice * reminder);
                                    }
                                    else
                                    {
                                        totalPrice += p.ProductPrice;
                                        break;
                                    }
                                    break;
                                }
                        }
                    }
                }
                cart.TotalCartPrice = (totalPrice != 0.0M) ? totalPrice : cart.TotalCartPrice;
                return cart;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private int Quotient(int val, int div, out int reminder)
        {
            reminder = val % div;
            return val / div;
        }
    }
}
