using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.BLL.Test
{
    [TestClass]
    public class PromotionEngineUnitTest
    {
        [TestMethod]
        public void ScenerioA()
        {
            var controller = new PromotionController();
            var cart = controller.AddtoCart('A');
            controller.UpdateCart('B', cart);
            controller.UpdateCart('C', cart);
            var results = controller.GetCart(cart);
            Assert.IsTrue(results.TotalCartPrice == 100);

        }

        [TestMethod]
        public void ScenerioB()
        {
            var controller = new PromotionController();
            var cart = controller.AddtoCart('A');
            controller.UpdateCart('A', cart); controller.UpdateCart('A', cart);
            controller.UpdateCart('A', cart); controller.UpdateCart('A', cart);
            controller.UpdateCart('B', cart);
            controller.UpdateCart('B', cart); controller.UpdateCart('B', cart);
            controller.UpdateCart('B', cart); controller.UpdateCart('B', cart);
            controller.UpdateCart('C', cart);
            var results = controller.GetCart(cart);
            Assert.IsTrue(results.TotalCartPrice == 370);

        }

        [TestMethod]
        public void ScenerioC()
        {
            var controller = new PromotionController();
            var cart = controller.AddtoCart('A');
            controller.UpdateCart('A', cart); controller.UpdateCart('A', cart);
            controller.UpdateCart('B', cart);
            controller.UpdateCart('B', cart); controller.UpdateCart('B', cart);
            controller.UpdateCart('B', cart); controller.UpdateCart('B', cart);
            controller.UpdateCart('C', cart);
            controller.UpdateCart('D', cart);
            var results = controller.GetCart(cart);
            Assert.IsTrue(results.TotalCartPrice == 280);

        }
    }
}
