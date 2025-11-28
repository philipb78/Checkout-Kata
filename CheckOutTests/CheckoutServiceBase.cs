using Checkout.Constants;
using Checkout.Services;
using Checkout.SpecialPricesRules;
using CheckOutTests;
using System;

namespace CheckOutServiceTests
{
    public class CheckoutServiceBase
    {
        public CheckoutServiceBase()
        {
        }

        protected CheckoutService GetCheckoutService()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            List<SpecialPriceRuleBase> rules = new List<SpecialPriceRuleBase>() {
                new SpecialPriceRuleMultiBuy("A", 130, 3),
                new SpecialPriceRuleMultiBuy("B", 45, 2)
            };

            BagPricingService bagPricingService = new BagPricingService(0, 0);

            CheckoutService checkoutService = new CheckoutService(rules, mockProductRepository, bagPricingService);
             
            return checkoutService;
        }


    }
}