using Checkout.Services;
using Checkout.SpecialPricesRules;
using CheckOutTests;

namespace CheckOutServiceTests
{
    public class CheckoutServiceTests
    {
        public CheckoutServiceTests()
        {
        }

        protected CheckoutService GetCheckoutService()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            List<SpecialPriceRuleBase> rules = new List<SpecialPriceRuleBase>() {
                new SpecialPriceRuleMultiBuy("A", 130, 3),
                new SpecialPriceRuleMultiBuy("B", 45, 2)
            };

            CheckoutService checkoutService = new CheckoutService(rules, mockProductRepository);
            return checkoutService;
        }
    }
}